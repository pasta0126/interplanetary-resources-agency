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
    }
}
