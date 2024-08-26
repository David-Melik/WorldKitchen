namespace WorldKitchen.Helpers // Change the namespace to fit your project structure
{
    public static class StringExtensions
    {
        // Extension method to capitalize the first letter
        public static string FirstCharToUpper(this string input)
        {
            return input switch
            {
                null => throw new ArgumentNullException(nameof(input)),
                "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
            };
        }
    }
}

