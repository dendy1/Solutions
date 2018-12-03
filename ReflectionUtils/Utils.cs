using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ReflectionUtils
{
    public class Utils
    {
        /// <summary>
        /// Возвращает список неабстрактных классов из сборки
        /// </summary>
        /// <param name="path">путь к сборке</param>
        public static List<Type> GetClasses(string path)
        {
            List<Type> types = new List<Type>();
            Assembly asm = Assembly.LoadFrom(path);

            Type[] typesq = asm.GetTypes();

            foreach (Type baseType in typesq)
            {
                if (baseType.IsClass && !baseType.IsAbstract)
                    types.Add(baseType);
            }

            return types;
        }       
    }
}
