using Jose;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace GenJwt
{
    public static class GenerateJWS
    {
        public static string Generate(string payload, string privateKeyPem, string merchantId, string privateKeyId)
        {
            var rsa = RSA.Create();
            rsa.ImportFromPem(privateKeyPem.ToCharArray());

            var digestObject = Helper.GenerateDigestObject(payload);
            var digestJson = JsonConvert.SerializeObject(digestObject);
            var digestBytes = Encoding.UTF8.GetBytes(digestJson);

            var header = Helper.GenerateJWSHeaderObject(merchantId, privateKeyId);

            var jwsToken = JWT.Encode(digestBytes, rsa, JwsAlgorithm.RS256, extraHeaders: header);
            return jwsToken;
        }
    }
}
