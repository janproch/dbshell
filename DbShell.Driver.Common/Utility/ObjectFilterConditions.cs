using Antlr.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DbShell.Driver.Common.Utility
{
    public class FilterableObjectData
    {
        public string Schema;
        public string Name;
        public List<string> Content;
        public string ContentText
        {
            set { Content = SplitContentText(value); }
        }

        public static List<string> SplitContentText(string s)
        {
            List<string> res = new List<string>();

            foreach (Match match in Regex.Matches(s, @"'([^']+)'"))
            {
                res.Add(match.Groups[1].Value);
            }
            foreach (Match match in Regex.Matches(s, "\"([^\"]+)\""))
            {
                res.Add(match.Groups[1].Value);
            }
            foreach (Match match in Regex.Matches(s, @"\[([^\]]+)\]"))
            {
                res.Add(match.Groups[1].Value);
            }
            foreach (Match match in Regex.Matches(s, @"\>([^\<]+)\<"))
            {
                res.Add(match.Groups[1].Value);
            }

            res.AddRange(s.Split(' ', ',', '\r', '\n').Select(x => x.Trim()).Where(x => !String.IsNullOrEmpty(x)));
            return res;
        }
    }

    public enum ObjectFilterContextEnum
    {
        Schema,
        Name,
        Content,
    }

    public abstract class ObjectFilterConditionBase
    {
        public abstract bool Match(FilterableObjectData obj);

        public static ObjectFilterConditionBase Parse(string s)
        {
            var lexer = new ObjectFilterLexer(new ANTLRReaderStream(new StringReader(s)));
            var tokens = new CommonTokenStream(lexer);
            var parser = new ObjectFilterParser(tokens);
            try
            {
                parser.expr();
            }
            catch
            {
                return null;
            }
            return parser.Condition;
        }
    }

    public class ObjectFilterNotCondition: ObjectFilterConditionBase
    {
        public ObjectFilterConditionBase Condition;
        public override bool Match(FilterableObjectData obj) => !Condition.Match(obj);
    }

    public abstract class ObjectFilterCompoudCondition : ObjectFilterConditionBase
    {
        public List<ObjectFilterConditionBase> Conditions = new List<ObjectFilterConditionBase>();
    }

    public class ObjectFilterAndCondition : ObjectFilterCompoudCondition
    {
        public override bool Match(FilterableObjectData obj) => Conditions.All(x => x.Match(obj));
    }

    public class ObjectFilterOrCondition : ObjectFilterCompoudCondition
    {
        public override bool Match(FilterableObjectData obj) => Conditions.Any(x => x.Match(obj));
    }

    public abstract class ObjectFilterStringTextCondition : ObjectFilterConditionBase
    {
        public string Filter;
        public ObjectFilterContextEnum Context;

        public override bool Match(FilterableObjectData obj)
        {
            switch (Context)
            {
                case ObjectFilterContextEnum.Name:
                    return obj.Name != null && Match(obj.Name);
                case ObjectFilterContextEnum.Schema:
                    return obj.Schema != null && Match(obj.Schema);
                case ObjectFilterContextEnum.Content:
                    return obj.Content != null && obj.Content.Any(x => Match(x));
            }
            return false;
        }

        public bool Match(string value)
        {
            if (String.IsNullOrEmpty(Filter)) return false;
            if (String.IsNullOrEmpty(value)) return true;

            var camelVariants = new HashSet<string>();
            camelVariants.Add(new String(Filter.Where(Char.IsUpper).ToArray()));
            if (value.All(x => Char.IsUpper(x) || x == '_'))
            {
                var sb = new StringBuilder();
                for (int i = 0; i < value.Length; i++)
                {
                    if (Char.IsUpper(value[i]) && (i == 0 || value[i - 1] == '_')) sb.Append(value[i]);
                }
                camelVariants.Add(sb.ToString());
            }
            else
            {
                string s = value, s0;
                do
                {
                    s0 = s;
                    s = Regex.Replace(s, "([A-Z])([A-Z])([A-Z])", "$1$3");
                } while (s0 != s);
                camelVariants.Add(new String(s.Where(Char.IsUpper).ToArray()));
            }

            bool camelMatch = camelVariants.Any(x => DoMatch(Filter, x));
            if (Filter.All(Char.IsUpper)) return camelMatch;
            return DoMatch(Filter, value) || camelMatch;
        }

        public abstract bool DoMatch(string filter, string value);
    }

    public class ObjectFilterContainsTextCondition: ObjectFilterStringTextCondition
    {
        public override bool DoMatch(string filter, string value) => value.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0;
    }

    public class ObjectFilterStartsWithCondition: ObjectFilterStringTextCondition
    {
        public override bool DoMatch(string filter, string value) => value.StartsWith(filter, StringComparison.OrdinalIgnoreCase);
    }

    public class ObjectFilterEndsWithCondition : ObjectFilterStringTextCondition
    {
        public override bool DoMatch(string filter, string value) => value.EndsWith(filter, StringComparison.OrdinalIgnoreCase);
    }

    public class ObjectFilterEqualsCondition : ObjectFilterStringTextCondition
    {
        public override bool DoMatch(string filter, string value) => String.Compare(value, filter, StringComparison.OrdinalIgnoreCase) == 0;
    }
}
