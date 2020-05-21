using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AtlusScriptLib;
using AtlusTableLib.Serialization;
using TGELib.Reflection;

namespace AtlusRandomizer
{
    public class TableRandomizer
    {
        protected static Random Random = new Random();

        protected static T GetRandom<T>(IList list)
        {
            return (T)list[Random.Next(list.Count)];
        }

        protected static Dictionary<string, List<object>> GetTableDistinctValues(object value)
        {
            return GetTableDistinctValues(new[] { value });
        }

        protected static Dictionary<string, List<object>> GetTableDistinctValues(IList instances)
        {
            var membernameToDistinctValueMap = new Dictionary<string, List<object>>();
            var type = instances[0].GetType();
            var members = type.GetMembers(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.GetCustomAttribute<TableMemberAttribute>() != null);

            foreach (var member in members)
            {
                var memberType = member.GetMemberType();
                var distinctValues = new List<object>();

                if (memberType.IsPrimitive || memberType.IsEnum)
                {
                    foreach (var instance in instances)
                    {
                        var value = member.GetValue(instance);
                        if (!distinctValues.Contains(value))
                            distinctValues.Add(value);
                    }
                }
                else if (memberType.IsArray)
                {
                    var distinctValues2 = new List<object>();
                    var elementType = memberType.GetElementType();

                    if (elementType.IsPrimitive || elementType.IsEnum)
                    {
                        foreach (var instance in instances)
                        {
                            foreach (var item in member.GetValue<Array>(instance))
                            {
                                if (!distinctValues2.Contains(item))
                                    distinctValues2.Add(item);
                            }
                        }
                    }
                    else if (elementType.IsClass || elementType.IsValueType)
                    {
                        var arrayElements = new List<object>();

                        foreach (var instance in instances)
                        {
                            var array = member.GetValue<Array>(instance);
                            foreach (var element in array)
                            {
                                arrayElements.Add(element);
                            }
                        }

                        var memberDistinctValues = GetTableDistinctValues(arrayElements);

                        distinctValues2.Add(memberDistinctValues);
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }

                    distinctValues.AddRange(distinctValues2);

                }

                membernameToDistinctValueMap[member.Name] = distinctValues;
            }

            return membernameToDistinctValueMap;
        }
    }
}
