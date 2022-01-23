using System;

namespace ExcelApp.Apis
{
    public class ConversionUtility
    {
        public T getEnumFromString<T>(string code) where T : struct, IConvertible
        {
            Type enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new Exception("T must be an Enumeration type.");
            }
            return Enum.TryParse(code, true, out T val) ? val : default;
        }
    }
}