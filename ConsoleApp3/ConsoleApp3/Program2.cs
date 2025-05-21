using System;
using System.Collections.Generic;

namespace GenJwt
{
   
class Program2
{
    public static void Main(string[] args)
    {
        var payload = new Dictionary<string, object>
        {
            { "merchantTxnId", "test123" },
            { "paymentData", new Dictionary<string, object>
                {
                    { "totalAmount", 100 },
                    { "txnCurrency", "INR" },
                    { "billingData", new Dictionary<string, object>
                        {
                            { "emailId", "test@example.com" }
                        }
                    }
                }
            },
            { "merchantCallbackURL", "https://yourcallback.url" }
        };


const string publicKey = @"
-----BEGIN PUBLIC KEY-----
MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA1ADDx9Hvg2c3I6uFYy2Q
v1i34OxSI7MY/woni1DkkKjTpZJ+Sv+iHJP62fop9/RxOwrVH6zTorAPcYlRdEuh
bxB6Q1G/GYgfR3Fz0g4z+gIGNucB7AubWWyTkhM40YkdBVojjMBYiwpN1JBYKzws
xDe/MJssS0D5SXIWZKfqaIR3xVa2rW3uUsomM82rPj5btDEx68YDhkOzuxTLeqOj
pLEuJMOIw5X1KGHq0Cl8YSwwClnfQd9OcwM3fvHKtlkA2CdcFcmgihGGmooYSP7V
HJJSD9nyREShJO8kCQmIPDa8/5JdvcT7QD3yGtD5H4L7o1l2G2i/VblFVggT0nVN
YwIDAQAB
-----END PUBLIC KEY-----";

const string privateKey = @"
-----BEGIN PRIVATE KEY-----
MIIEvAIBADANBgkqhkiG9w0BAQEFAASCBKYwggSiAgEAAoIBAQDOzVfR3SDHxTVi
dOkS3WWZCuwgSzJe1Z9E3NGItA6zFANghD5++dlsSm1b+LjajRk/t0a1LqweEk+s
5GLfT61ljtdTqIW1K66zmGM3Bt+ZYgbyBbpLnTf0E+K5UvJYbIzg223iYyaUEFgd
BvMPo1qxa2piQmlycWYikWTw5UG7+Scb4PM2K8SLdRZzUHNj8zn7SMSip4lsRn9l
4NSxy3/0v0b7TDj4WL6rPDEZBMmQcx5hd2hZx7uU9E8GPEVD972XmMbMEma++xSS
r2QCwSbbbN13Etvo0MIuZn6qgbSONCy76Z85BnM4DWuysY+vYwSlIjw+oGG+MT8P
ad+iAVM3AgMBAAECggEAXoeEnhyLMGXX2jKAm6vyFfvlJXnaA3l4fRzG9sr/cSIz
zPmGK7p/hT2cMY9GyDf5E6PuQUGdUX2jR+95toQQSbz6dnYw8DiQee2tZGjS6qTh
cd3mY0vxWLOCTp44wuyTlPEYkIQsDUBPVq1ni31rJnBoR5P96V8mhaSaVHcnDgmp
0Fm8c5WKcplJss9K5iAW4LUh9evsLvMQ1AjMqlXotCuLVqsaog8tmT0DypQ2/cdS
UYCCrS9A9i3U7DVCcjcDg2ajfpGJcoU55DHLN/K8POt8GjpALfSHbeQwGQbwnFMq
J5uVMWMW/Dq3yffVaewEeN0N75psMh+cakytogPWGQKBgQD3IQSD7SUjbijqJ5N4
j60u6eLOTmobgaxAiKyfhfI0WopY5rU1JNh0gI3tb67g4VvpwsyoeSCnBhQSPn+V
t/isRovMflMi/X3FCTRa843BnmouG457mWQs8HOkCHQGNbLBKKcFQumXzi/OSuhU
8G/N64vxEXgyoyrUw5Y4ENNZIwKBgQDWOb5Jn0SaBToWibgpnwjkGhJsZyTPAy1v
wtOwG1wGefqwAOWoSNVl6SGAUBxxjM/H3scES8w6CQua+lNJmBE85UFjga/ZKpGa
WZo29bw+KY34ICXd/QWHTPDc7hDqE7uNPPx4MrLP0IArNHbqSGS9C6Dzo2y9BqMP
Ryj7lwMg3QKBgGRl/JCgSmM/gM3IMEhdjo0tpeAMyVzNbK53GDJi14hfdC8z41Bo
3KtQAtkAc3qW86Ffa4fSVeqlNIhI7cpkiFls+6SjeaEQfQUMfUGqCuArPJXoyhT6
t1DuivyMFp7jN/DzVA92JLJwqMlVc1f2qmVtGVhhsYRY97CimSfD5ikjAoGAdPQT
Wdg0uK1v2AwZ2cc0MGu3cS0iYE4IyUIhFbzqEbMYVGw49RXGQxvyqT2TOb65VRHf
rw2+klSL3HEbdUsq5gb3Gt8bZMEjupN+aNDhk0JWeob6hWX0VbiAquzhmRlqxCHu
Z6SuEFxxDKVY4nDhZn/pv/mRjOUJsnaT/j6ke5UCgYBJzqsbziDN5hh9/hOjtc1I
kDuzxP+TswgKm1GcxWOyfXAdmm1cdLpLqhsR1kN+Iwee431DPnt83texAXGW4lq5
wAJzQ42JkYXa6zRGDriZWucavXD/Lri05mM6DkvLWdUVM3dljpYkAUL718LS0uez
qrveXQv5tQO9i7lCyyro3w==
-----END PRIVATE KEY-----";



        string merchantId = "testnewgcc26";
        string publicKeyId = "kId-yLtRky48X2HqW30k";
        string privateKeyId = "kId-vU6e8l6bWtXK8oOK";

        try
        {
            var tokens = GenJwt.GenerateJWEAndJWS.Generate(payload, publicKey, privateKey, merchantId, publicKeyId, privateKeyId);

            Console.WriteLine("JWE Token:");
            Console.WriteLine(tokens.jweToken);
            Console.WriteLine("\nJWS Token:");
            Console.WriteLine(tokens.jwsToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error generating tokens: " + ex.Message);
        }
    }
} 
}




























