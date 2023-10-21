using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Helpers
{
    public static class DictionaryHelper
    {
        public static string ToString<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, string sepChar)
        {
            if (dictionary.Keys == null || !dictionary.Keys.Any()) return string.Empty;
            else
            {
                string value = string.Empty;
                foreach (var item in dictionary)
                {
                    value += string.Format("{0}: {1}{2}", item.Key.ToString(), item.Value.ToString(), sepChar);
                }
                return value;
            }
        }
    }
}
