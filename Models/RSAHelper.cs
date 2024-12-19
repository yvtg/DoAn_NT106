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
