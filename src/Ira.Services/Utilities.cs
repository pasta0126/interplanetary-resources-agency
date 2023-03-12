using FakerDotNet;

namespace Ira.Services
{
    public static class Utilities
    {
        public static T RandomFromEnum<T>()
        {
            Array values = Enum.GetValues(typeof(T));
            var random = Faker.Number.Between(0, values.Length);
            T element = (T)values.GetValue(Convert.ToInt32(random));

            return element;
        }

        public static List<string> GetEnumValues<T>()
        {
            var result = new List<string>();
            var list =  Enum.GetValues(typeof(T)).Cast<T>();

            foreach ( var value in list)
            {
                result.Add(value.ToString());
            }

            return result;
        }
    }
}
