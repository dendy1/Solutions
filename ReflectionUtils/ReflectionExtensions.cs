using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ReflectionUtils
{
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Возвращает сигнатуру метода
        /// </summary>
        /// <param name="modificators">включать модификаторы в сигнатуру метода</param>
        /// <param name="types">включать типы в сигнатуру метода</param>
        public static string GetSignature(this MethodInfo method, bool modificators = true, bool types = true)
        {
            var firstParam = true;
            var sigBuilder = new StringBuilder();

            if (modificators)
            {
                if (method.IsPublic)
                    sigBuilder.Append("public ");
                else if (method.IsPrivate)
                    sigBuilder.Append("private ");
                else if (method.IsAssembly)
                    sigBuilder.Append("internal ");
                if (method.IsFamily)
                    sigBuilder.Append("protected ");
                if (method.IsStatic)
                    sigBuilder.Append("static ");
                sigBuilder.Append(TypeName(method.ReturnType));
                sigBuilder.Append(' ');
            }
            sigBuilder.Append(method.Name);

            // Add method generics
            if (method.IsGenericMethod)
            {
                sigBuilder.Append("<");
                foreach (var g in method.GetGenericArguments())
                {
                    if (firstParam)
                        firstParam = false;
                    else
                        sigBuilder.Append(", ");
                    sigBuilder.Append(TypeName(g));
                }
                sigBuilder.Append(">");
            }

            sigBuilder.Append("(");
            firstParam = true;
            var secondParam = false;
            foreach (var param in method.GetParameters())
            {
                if (firstParam)
                {
                    firstParam = false;
                    if (method.IsDefined(typeof(System.Runtime.CompilerServices.ExtensionAttribute), false))
                    {
                        if (modificators)
                        {
                            secondParam = true;
                            continue;
                        }
                        sigBuilder.Append("this ");
                    }
                }
                else if (secondParam == true)
                    secondParam = false;
                else
                    sigBuilder.Append(", ");
                if (param.ParameterType.IsByRef)
                    sigBuilder.Append("ref ");
                else if (param.IsOut)
                    sigBuilder.Append("out ");
                if (types)
                {
                    sigBuilder.Append(TypeName(param.ParameterType));
                    sigBuilder.Append(' ');
                }
                sigBuilder.Append(param.Name);
            }
            sigBuilder.Append(")");
            return sigBuilder.ToString();
        }

        /// <summary>
        /// Возвращает сигнатуру конструктора
        /// </summary>
        /// <param name="modificators">включать модификаторы в сигнатуру конструктора</param>
        /// <param name="types">включать типы в сигнатуру конструктора</param>
        public static string TypeName(Type type)
        {
            var nullableType = Nullable.GetUnderlyingType(type);
            if (nullableType != null)
                return nullableType.Name + "?";

            if (!(type.IsGenericType && type.Name.Contains('`')))
                switch (type.Name)
                {
                    case "String": return "string";
                    case "Int32": return "int";
                    case "Int64": return "long";
                    case "Float": return "float";
                    case "Double": return "double";
                    case "Decimal": return "decimal";
                    case "Boolean": return "bool";
                    case "Object": return "object";
                    case "Void": return "void";
                    default:
                        {
                            return string.IsNullOrWhiteSpace(type.FullName) ? type.Name : type.FullName;
                        }
                }

            var sb = new StringBuilder(type.Name.Substring(0,
            type.Name.IndexOf('`'))
            );
            sb.Append('<');
            var first = true;
            foreach (var t in type.GetGenericArguments())
            {
                if (!first)
                    sb.Append(',');
                sb.Append(TypeName(t));
                first = false;
            }
            sb.Append('>');
            return sb.ToString();
        }

        /// <summary>
        /// Get full signature of some constructor
        /// </summary>
        /// <param name="callable">Get with parameters</param>
        /// <returns>Full signature of some constructor</returns>
        public static string GetSignature(this ConstructorInfo constructor, bool callable = false)
        {
            StringBuilder sigBuilder = new StringBuilder();

            if (callable == false)
            {
                if (constructor.IsPublic)
                    sigBuilder.Append("public ");
                else if (constructor.IsPrivate)
                    sigBuilder.Append("private ");
                else if (constructor.IsAssembly)
                    sigBuilder.Append("internal ");
                if (constructor.IsFamily)
                    sigBuilder.Append("protected ");
                if (constructor.IsStatic)
                    sigBuilder.Append("static ");
            }

            sigBuilder.Append(constructor.ReflectedType.Name);

            var firstParam = true;
            if (constructor.IsGenericMethod)
            {
                sigBuilder.Append("<");
                foreach (var g in constructor.GetGenericArguments())
                {
                    if (firstParam)
                        firstParam = false;
                    else
                        sigBuilder.Append(", ");
                    sigBuilder.Append(TypeName(g));
                }
                sigBuilder.Append(">");
            }

            sigBuilder.Append("(");
            firstParam = true;
            var secondParam = false;
            foreach (var param in constructor.GetParameters())
            {
                if (firstParam)
                {
                    firstParam = false;
                    if (constructor.IsDefined(typeof(System.Runtime.CompilerServices.ExtensionAttribute), false))
                    {
                        if (callable)
                        {
                            secondParam = true;
                            continue;
                        }
                        sigBuilder.Append("this ");
                    }
                }
                else if (secondParam == true)
                    secondParam = false;
                else
                    sigBuilder.Append(", ");
                if (param.ParameterType.IsByRef)
                    sigBuilder.Append("ref ");
                else if (param.IsOut)
                    sigBuilder.Append("out ");
                if (!callable)
                {
                    sigBuilder.Append(TypeName(param.ParameterType));
                    sigBuilder.Append(' ');
                }
                sigBuilder.Append(param.Name);
            }
            sigBuilder.Append(")");

            return sigBuilder.ToString();
        }
    }
}
