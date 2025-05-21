using System;
using System.Collections.Generic;

namespace GenJwt
{
    public static class Validate
    {
        public static void ValidatePayload(Dictionary<string, object> payload)
        {
            if (payload == null) Errors.NullError("transaction payload");
            if (payload.Count < 1) Errors.EmptyError("Transaction payload");
        }

        public static void ValidatePublicKey(string publicKey)
        {
            if (string.IsNullOrWhiteSpace(publicKey)) Errors.NullError("public key");
        }

        public static void ValidatePrivateKey(string privateKey)
        {
            if (string.IsNullOrWhiteSpace(privateKey)) Errors.NullError("private key");
        }

        public static void ValidateMerchantId(string merchantId)
        {
            if (string.IsNullOrWhiteSpace(merchantId)) Errors.NullError("merchant ID");
        }

        public static void ValidatePublicKeyId(string kid)
        {
            if (string.IsNullOrWhiteSpace(kid)) Errors.NullError("public key id");
        }

        public static void ValidatePrivateKeyId(string kid)
        {
            if (string.IsNullOrWhiteSpace(kid)) Errors.NullError("private key id");
        }

        public static void ValidateJwsPayload(string payload)
        {
            if (string.IsNullOrWhiteSpace(payload)) Errors.NullError("payload");
        }

        public static void ValidateParams(Dictionary<string, object> payload, string publicKey, string privateKey, string merchantId, string publicKeyId, string privateKeyId)
        {
            ValidatePayload(payload);
            ValidatePublicKey(publicKey);
            ValidatePrivateKey(privateKey);
            ValidateMerchantId(merchantId);
            ValidatePublicKeyId(publicKeyId);
            ValidatePrivateKeyId(privateKeyId);
        }
    }
}
