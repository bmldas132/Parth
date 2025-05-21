namespace GenJwt
{
    public static class Errors
    {
        public static void InvalidType(string name, string type)
        {
            throw new ArgumentException($"{name} should be a {type}.");
        }

        public static void NullError(string name)
        {
            throw new ArgumentNullException(name, $"Please provide {name}");
        }

        public static void EmptyError(string name)
        {
            throw new ArgumentException($"{name} cannot be empty.");
        }
    }
}
