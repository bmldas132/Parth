using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace GenJwt
{
    public static class Helper
    {
        public static Dictionary<string, object> GenerateDigestObject(string payload)
        {
            using (var sha256 = SHA256.Create())
            {
                var digestBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(payload));
                var digestBase64 = Convert.ToBase64String(digestBytes);
                return new Dictionary<string, object>
                {
                    { "digest", digestBase64 },
                    { "digestAlgorithm", Constants.DIGEST_ALGORITHM },
                    { "exp", Constants.TOKEN_EXPIRY_TIME_IN_MILLISECONDS },
                    { "iat", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString() }
                };
            }
        }

        public static Dictionary<string, object> GenerateJWSHeaderObject(string merchantId, string kid)
        {
            return new Dictionary<string, object>
            {
                { "alg", Constants.JWS_ALGORITHM },
                { "kid", kid },
                { "x-gl-merchantId", merchantId },
                { "issued-by", merchantId },
                { "is-digested", "true" },
                { "x-gl-enc", "true" }
            };
        }

        public static Dictionary<string, object> GenerateJWEHeaderObject(string merchantId, string kid)
        {
            return new Dictionary<string, object>
            {
                { "issued-by", merchantId },
                //{ "enc", Constants.JWE_ENCRYPTION_METHOD },
                { "exp", Constants.TOKEN_EXPIRY_TIME_IN_MILLISECONDS },
                { "iat", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString() },
                //{ "alg", Constants.JWE_ALGORITHM },
                { "kid", kid }
            };
        }
    }
}
