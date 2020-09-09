using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using ContactProfile.App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using ContactProfile.App.WebCore;

namespace ContactProfile.App.Extensions
{
    public static class RoutValueExtensions
    {
        /// <summary>
        /// Convert RouteValueDictionaryModel to RouteValueDictionary and in to a single key
        /// </summary>
        /// <param name="routeValues"></param>
        /// <returns></returns>
        public static RouteValueDictionary ToRouteValueDictionary(this RouteValueDictionaryModel routeValues, string areaName = "")
        {
            string hex = JsonConvert.SerializeObject(routeValues).ToCompressString();
            object toBeConverted = new object();
            if (!string.IsNullOrEmpty(areaName))
            {
                routeValues.AreaName = areaName;
            }
            if (string.IsNullOrEmpty(routeValues.AreaName))
            {
                toBeConverted = new
                {
                    id = hex,
                };
            }
            else
            {
                toBeConverted = new
                {
                    id = hex,
                    area = routeValues.AreaName
                };
            }           
            var result = new RouteValueDictionary(toBeConverted);
            return result;
        }

        /// <summary>
        /// Convert routeValues string to RouteValueDictionaryModel
        /// </summary>
        /// <param name="routeValues"></param>
        /// <returns></returns>
        public static RouteValueDictionaryModel ToRouteValueDictionaryModel(this string routeValues)
        {
            if (string.IsNullOrEmpty(routeValues))
                return new RouteValueDictionaryModel();
            try
            {               
                var tt = routeValues.ToDecompressString();
                return JsonConvert.DeserializeObject<RouteValueDictionaryModel>(tt);
            }
            catch (System.Exception)
            {
                return new RouteValueDictionaryModel();
            }           
        }

        /// <summary>
        /// Encrypt RouteValueDictionary to ToRouteValueDictionary and in to a single key
        /// </summary>
        /// <param name="routeValues"></param>
        /// <returns></returns>
        public static RouteValueDictionary ToRouteValueDictionary(this object routeValues)
        {
            string areaName = "";
            var dic = routeValues.ToDictionary();

            if (dic.ContainsKey("area"))
            {
                areaName = dic["area"].ToString();
                dic.Remove("area");
            }          
            string hex = JsonConvert.SerializeObject(dic).ToCompressString();
            object toBeConverted = new object();

            if (string.IsNullOrEmpty(areaName))
            {
                toBeConverted = new
                {
                    id = hex,
                };
            }
            else
            {
                toBeConverted = new
                {
                    id = hex,
                    area = areaName
                };
            }
            var result = new RouteValueDictionary(toBeConverted);
            return result;
        }

        /// <summary>
        /// ToDictionary
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IDictionary<string, object> ToDictionary(this object source)
        {
            return source.ToDictionary<object>();
        }
        /// <summary>
        /// ToDictionary => IDictionary<string, T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IDictionary<string, T> ToDictionary<T>(this object source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var dictionary = new Dictionary<string, T>();

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
            {
                AddPropertyToDictionary(property, source, dictionary);
            }
            return dictionary;
        }

        private static void AddPropertyToDictionary<T>(PropertyDescriptor property, object source, Dictionary<string, T> dictionary)
        {
            object value = property.GetValue(source);
            if (value != null)
            {
                if (value is DateTime)
                {
                    value = string.Format("{0:dd/MM/yyyy}", value);
                    dictionary.Add(property.Name, (T)value);
                }
                else if (value is T)
                {
                    dictionary.Add(property.Name, (T)value);
                }
            }
        }
    }
}
