namespace GenJwt
{
    public static class Constants
    {
        public const string TYPE_OBJECT = "object";
        public const string TYPE_STRING = "string";
        public const string JWE_ALGORITHM = "RSA-OAEP-256";
        public const string JWS_ALGORITHM = "RS256";
        public const string DIGEST_ALGORITHM = "SHA-256";
        public const string JWE_ENCRYPTION_METHOD = "A128CBC-HS256";
        public const int TOKEN_EXPIRY_TIME_IN_MILLISECONDS = 300000;
    }
}
