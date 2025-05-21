using System;
using System.Collections.Generic;


namespace GenJwt
{
    
public static class GenerateJWEAndJWS
{
    public static (string jweToken, string jwsToken) Generate(Dictionary<string, object> payload, string publicKey, string privateKey, string merchantId, string publicKeyId, string privateKeyId)
    {
        Validate.ValidateParams(payload, publicKey, privateKey, merchantId, publicKeyId, privateKeyId);

        var jweToken = GenerateJWE.Generate(payload, publicKey, merchantId, publicKeyId);
        var jwsToken = GenerateJWS.Generate(jweToken, privateKey, merchantId, privateKeyId);

        return (jweToken, jwsToken);
    }
}


}