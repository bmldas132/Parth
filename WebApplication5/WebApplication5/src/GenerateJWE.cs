using Jose;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace GenJwt
{
    public static class GenerateJWE
    {
        public static string Generate(Dictionary<string, object> payload, string publicKeyPem, string merchantId, string publicKeyId)
        {
            var rsa = RSA.Create();
            rsa.ImportFromPem(publicKeyPem.ToCharArray());

            var header = Helper.GenerateJWEHeaderObject(merchantId, publicKeyId);
            var payloadJson = JsonConvert.SerializeObject(payload);
            var payloadBytes = Encoding.UTF8.GetBytes(payloadJson);

            var jweToken = JWT.Encode(payloadBytes, rsa, JweAlgorithm.RSA_OAEP_256, JweEncryption.A128CBC_HS256, extraHeaders: header);
            return jweToken;
        }
    }
}
