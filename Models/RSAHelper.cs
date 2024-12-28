using System;
using System.Security.Cryptography;
using System.Text;

public class RSAHelper
{
    private RSACryptoServiceProvider rsa;

    public RSAHelper()
    {
        rsa = new RSACryptoServiceProvider();
    }

    // Tạo khóa công khai
    public string GetPublicKey()
    {
        return rsa.ToXmlString(false);
    }

    // Tạo khóa riêng tư
    public string GetPrivateKey()
    {
        return rsa.ToXmlString(true);
    }

    // Mã hóa văn bản bằng khóa công khai
    public string Encrypt(string plainText, string publicKey)
    {
        rsa.FromXmlString(publicKey);
        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
        byte[] encryptedBytes = rsa.Encrypt(plainBytes, false);
        return Convert.ToBase64String(encryptedBytes);
    }

    // Giải mã văn bản bằng khóa riêng tư
    public string Decrypt(string encryptedText, string privateKey)
    {
        rsa.FromXmlString(privateKey);
        byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
        byte[] decryptedBytes = rsa.Decrypt(encryptedBytes, false);
        return Encoding.UTF8.GetString(decryptedBytes);
    }
}
