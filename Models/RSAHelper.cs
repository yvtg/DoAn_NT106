using System;
using System.Security.Cryptography;
using System.Text;

public class RSAHelper
{
    private RSACryptoServiceProvider rsa;

    public RSAHelper()
    {
        rsa = new RSACryptoServiceProvider(2048);
    }

    public string GetPublicKey()
    {
        return rsa.ToXmlString(false); // Chỉ chứa khóa công khai
    }

    public string GetPrivateKey()
    {
        return rsa.ToXmlString(true); // Chứa cả khóa công khai và khóa riêng tư
    }

    public string Encrypt(string plainText, string publicKey)
    {
        rsa.FromXmlString(publicKey);
        byte[] dataToEncrypt = Encoding.UTF8.GetBytes(plainText);
        byte[] encryptedData = rsa.Encrypt(dataToEncrypt, false);
        return Convert.ToBase64String(encryptedData);
    }

    public string Decrypt(string encryptedText, string privateKey)
    {
        rsa.FromXmlString(privateKey);
        byte[] dataToDecrypt = Convert.FromBase64String(encryptedText);
        byte[] decryptedData = rsa.Decrypt(dataToDecrypt, false);
        return Encoding.UTF8.GetString(decryptedData);
    }
}

//public class RsaEncryption
//{
//    private static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
//    private RSAParameters _privatekey;
//    private RSAParameters _publickey;

//    public RsaEncryption()
//    {
//        _privatekey = csp.ExportParameters(true);
//        _publickey = csp.ExportParameters(false);
//    }

//    public string GetPublickey()
//    {
//        var sw = new StringWriter();
//        var xs = new XmlSerializer(typeof(RSAParameters));
//        xs.Serialize(sw, _publickey);
//        return sw.ToString();
//    }

//    public string Encrypt(string plainText)
//    {
//        csp = new RSACryptoServiceProvider();
//        csp.ImportParameters(_publickey);
//        var data = Encoding.Unicode.GetBytes(plainText);
//        var cypher = csp.Encrypt(data, false);
//        return Convert.ToBase64String(cypher);
//    }

//    public string Decrypt(string cypherText)
//    {
//        var dataBytes = Convert.FromBase64String(cypherText);
//        csp.ImportParameters(_privatekey);
//        var plainText = csp.Decrypt(dataBytes, false);
//        return Encoding.Unicode.GetString(plainText);
//    }
//}