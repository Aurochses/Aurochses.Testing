using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Aurochses.Testing
{
    /// <summary>
    /// Class ObjectHelpers.
    /// </summary>
    public static class ObjectHelpers
    {
        /// <summary>
        /// Equals the specified object to other object.
        /// </summary>
        /// <param name="obj">The current object.</param>
        /// <param name="objTo">The object to compare.</param>
        /// <returns><c>true</c> if objects are equal, <c>false</c> otherwise.</returns>
        public static bool Equal(this object obj, object objTo)
        {
            if (obj == null && objTo == null) return true;

            if (obj == null) return false;
            if (objTo == null) return false;

            var objType = obj.GetType();
            var objToType = objTo.GetType();

            if (objType != objToType && !string.IsNullOrWhiteSpace(objToType.Namespace)) return false;

            if (objType.GetTypeInfo().IsValueType || objType == typeof(string))
            {
                return obj.Equals(objTo);
            }

            if (objType.IsArray || objType.GetInterfaces().Contains(typeof(IEnumerable)))
            {
                var enumerableObj = ((IEnumerable<object>) obj).ToList();
                var enumerableobjTo = ((IEnumerable<object>) objTo).ToList();

                for (var i = 0; i < enumerableObj.Count; i++)
                {
                    if (!enumerableObj[i].Equal(enumerableobjTo[i]))
                    {
                        return false;
                    }
                }

                return true;
            }

            var objProperties = objType.GetProperties();
            var objToProperties = objToType.GetProperties();

            if (objProperties.Length != objToProperties.Length) return false;

            foreach (var objToProperty in objToProperties)
            {
                var objProperty = objProperties.FirstOrDefault(x => x.Name == objToProperty.Name);

                if (objProperty == null) return false;

                var objPropertyValue = objProperty.GetValue(obj);
                var objToPropertyValue = objToProperty.GetValue(objTo);

                if (objPropertyValue == null)
                {
                    if (objToPropertyValue != null) return false;

                    continue;
                }

                if (!objPropertyValue.Equal(objToPropertyValue)) return false;
            }

            return true;
        }
    }
}