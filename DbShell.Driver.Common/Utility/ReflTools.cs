using System;
using System.Collections.Generic;
using System.Reflection;

namespace DbShell.Driver.Common.Utility
{
    public struct MethodAttribute<T> where T : System.Attribute
    {
        public MethodInfo Method;
        public T Attribute;
        public MethodAttribute(MethodInfo method, T attribute)
        {
            Method = method;
            Attribute = attribute;
        }
    }

    public static class ReflTools
    {
        public static IEnumerable<MethodAttribute<T>> GetMethods<T>(object obj) where T : System.Attribute
        {
            foreach (MethodInfo mtd in obj.GetType().GetMethods())
            {
                T[] attr = (T[])mtd.GetCustomAttributes(typeof(T), true);
                if (attr.Length > 0)
                {
                    yield return new MethodAttribute<T>(mtd, attr[0]);
                }
            }
        }

        public static object CallGet(this PropertyInfo prop, object obj)
        {
            MethodInfo mtd = prop.GetGetMethod();
            return mtd.Invoke(obj, new object[] { });
        }

        public static void CallSet(this PropertyInfo prop, object obj, object value)
        {
            MethodInfo mtd = prop.GetSetMethod();
            if (mtd != null) mtd.Invoke(obj, new object[] { value });
        }

        public static object CreateNewInstance(this Type type)
        {
            ConstructorInfo con = type.GetConstructor(new Type[] { });
            if (con == null) throw new InternalError("DAE-00071 Type " + type.FullName + " has no parameter-less constructor");
            return con.Invoke(new object[] { });
        }

        //public static object CallStaticMethod<T>(this Type type, string mtdname, T arg)
        //{
        //    return type.InvokeMember(mtdname, BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.FlattenHierarchy, null, type, new object[] { arg });
        //    //MethodInfo mtd = type.GetMethod(mtdname, new Type[] { typeof(T) }, BindingFlags.Static);
        //    //return mtd.Invoke(null, new object[] { arg });
        //}

        public static bool IsIndexProperty(this PropertyInfo prop)
        {
            MethodInfo mtd = prop.GetGetMethod();
            return mtd.GetParameters().Length > 0;
        }

        public static object GetStaticPropertyOrField(this Type type, string fldname)
        {
            PropertyInfo pi = type.GetProperty(fldname);
            if (pi != null) return pi.GetValue(null, new object[] { });
            FieldInfo fld = type.GetField(fldname);
            if (fld != null) return fld.GetValue(null);
            throw new Exception(String.Format("DAE-00311 Type {0} has not property nor field {1}", type.FullName, fldname));
        }
    }
}
