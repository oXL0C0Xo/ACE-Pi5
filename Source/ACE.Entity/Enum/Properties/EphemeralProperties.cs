using System.Collections.Generic;
using System.Linq;

namespace ACE.Entity.Enum.Properties
{
    /// <summary>
    /// Static selection of client enums that are [Ephemeral]
    /// </summary>
    public static class EphemeralProperties
    {
        /// <summary>
        /// Method to return a list of enums by attribute type - in this case [Ephemeral] using generics to enhance code reuse.
        /// </summary>
        /// <typeparam name="T">Enum to list by [Ephemeral]</typeparam>
        /// <typeparam name="TResult">Type of the results</typeparam>
        private static List<TResult> GetValues<T, TResult>()
        {
            return typeof(T).GetFields().Select(x => new
            {
                att = x.GetCustomAttributes(false).OfType<EphemeralAttribute>().FirstOrDefault(),
                member = x
            }).Where(x => x.att != null && x.member.Name != "value__").Select(x => (TResult)x.member.GetValue(null)).ToList();
        }

        /// <summary>
        /// returns a list of values for PropertyInt that are [Ephemeral]
        /// </summary
        public static List<ushort> PropertiesInt = GetValues<PropertyInt, ushort>();

        /// <summary>
        /// returns a list of values for PropertyInt that are [Ephemeral]
        /// </summary>
        public static List<ushort> PropertiesInt64 = GetValues<PropertyInt64, ushort>();

        /// <summary>
        /// returns a list of values for PropertyInt that are [Ephemeral]
        /// </summary>
        public static List<ushort> PropertiesBool = GetValues<PropertyBool, ushort>();

        /// <summary>
        /// returns a list of values for PropertyInt that are [Ephemeral]
        /// </summary>
        public static List<ushort> PropertiesString = GetValues<PropertyString, ushort>();

        /// <summary>
        /// returns a list of values for PropertyInt that are [Ephemeral]
        /// </summary>
        public static List<ushort> PropertiesDouble = GetValues<PropertyFloat, ushort>();

        /// <summary>
        /// returns a list of values for PropertyInt that are [Ephemeral]
        /// </summary>
        public static List<ushort> PropertiesDataId = GetValues<PropertyDataId, ushort>();

        /// <summary>
        /// returns a list of values for PropertyInt that are [Ephemeral]
        /// </summary>
        public static List<ushort> PropertiesInstanceId = GetValues<PropertyInstanceId, ushort>();
    }
}
