using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Web.Razor.Text;
using Microsoft.Internal.Web.Utils;
using System.Diagnostics;

namespace System.Web.Razor.Parser.SyntaxTree {
    public class Block : SyntaxTreeNode {
        [SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods", Justification = "Type is the most appropriate name for this property and there is little chance of confusion with GetType")]
        public BlockType Type { get; private set; }
        public IEnumerable<SyntaxTreeNode> Children { get; private set; }
        public string Name { get; private set; }

        public override bool IsBlock {
            get { return true; }
        }

        public override SourceLocation Start {
            get {
                SyntaxTreeNode child = Children.FirstOrDefault();
                if (child == null) {
                    return SourceLocation.Zero;
                }
                else {
                    return child.Start;
                }
            }
        }

        public override int Length {
            get { return Children.Sum(child => child.Length); }
        }

        public Block(BlockType type, IEnumerable<SyntaxTreeNode> contents)
            : this(type, contents, null) {
        }

        public Block(BlockType type, IEnumerable<SyntaxTreeNode> contents, string name) {
            if (type < BlockType.Statement || type > BlockType.Comment) {
                throw new ArgumentOutOfRangeException("type", String.Format(CultureInfo.CurrentCulture, CommonResources.Argument_Must_Be_Enum_Member, typeof(BlockType).Name));
            }
            if (contents == null) { throw new ArgumentNullException("contents"); }

            foreach (SyntaxTreeNode node in contents) {
                node.Parent = this;
            }

            Type = type;
            Children = contents;
            Name = name;
        }

        public Span FindFirstDescendentSpan() {
            SyntaxTreeNode current = this;
            while (current != null && current.IsBlock) {
                current = ((Block)current).Children.FirstOrDefault();
            }
            return current as Span;
        }

        public Span FindLastDescendentSpan() {
            SyntaxTreeNode current = this;
            while (current != null && current.IsBlock) {
                current = ((Block)current).Children.LastOrDefault();
            }
            return current as Span;
        }

        public override void Accept(ParserVisitor visitor) {
            visitor.VisitStartBlock(Type);
            foreach (SyntaxTreeNode element in Children) {
                element.Accept(visitor);
            }
            visitor.VisitEndBlock(Type);
        }

        public override string ToString() {
            return String.Format(CultureInfo.CurrentCulture, "{0} Block at {1}::{2}", Type, Start, Length);
        }

        public override bool Equals(object obj) {
            Block other = obj as Block;
            return other != null &&
                   Type == other.Type &&
                   ChildrenEqual(Children, other.Children);
        }

        public override int GetHashCode() {
            return (int)Type;
        }

        public IEnumerable<Span> Flatten() {
            // Create an enumerable that flattens the tree for use by syntax highlighters, etc.
            foreach (SyntaxTreeNode element in Children) {
                Span span = element as Span;
                if (span != null) {
                    yield return span;
                }
                else {
                    Block block = element as Block;
                    foreach (Span childSpan in block.Flatten()) {
                        yield return childSpan;
                    }
                }
            }
        }

        public Span LocateOwner(TextChange change) {
            // Ask each child recursively
            Span owner = null;
            foreach (SyntaxTreeNode element in Children) {
                Span span = element as Span;
                if (span == null) {
                    owner = ((Block)element).LocateOwner(change);
                }
                else {
                    if (change.OldPosition < span.Start.AbsoluteIndex) {
                        // Early escape for cases where changes overlap multiple spans
                        // In those cases, the span will return false, and we don't want to search the whole tree
                        // So if the current span starts after the change, we know we've searched as far as we need to
                        break;
                    }
                    owner = span.OwnsChange(change) ? span : owner;
                }

                if (owner != null) {
                    break;
                }
            }
            return owner;
        }

        private static bool ChildrenEqual(IEnumerable<SyntaxTreeNode> left, IEnumerable<SyntaxTreeNode> right) {
            IEnumerator<SyntaxTreeNode> leftEnum = left.GetEnumerator();
            IEnumerator<SyntaxTreeNode> rightEnum = right.GetEnumerator();
            while (leftEnum.MoveNext()) {
                if (!rightEnum.MoveNext() || // More items in left than in right
                    !Equals(leftEnum.Current, rightEnum.Current)) { // Nodes are not equal
                    return false;
                }
            }
            if (rightEnum.MoveNext()) { // More items in right than left
                return false;
            }
            return true;
        }
    }
}
