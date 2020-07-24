using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaASPNET.Models
{
    public static class myExtensions
    {
        public static object GetPropert<T>(this T obj, string name) where T : Student
        {
            Type t = typeof(T);
            return t.GetProperty(name).GetValue(obj, null);
        }

        
    }
}
