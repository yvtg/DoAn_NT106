using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Models
{
    public class AES
    {
        // Khóa AES tĩnh (32 byte - 256-bit key)
        private static readonly byte[] aesKey = HexStringToByteArray("2b7e151628aed2a6abf7158809cf4f3c");

        public static byte[] EncryptAES(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = aesKey;
                aes.GenerateIV(); // Tạo IV ngẫu nhiên mới

                using (ICryptoTransform encryptor = aes.CreateEncryptor())
                {
                    byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                    byte[] encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

                    // Kết hợp IV và dữ liệu mã hóa
                    byte[] result = new byte[aes.IV.Length + encryptedBytes.Length];
                    Buffer.BlockCopy(aes.IV, 0, result, 0, aes.IV.Length);
                    Buffer.BlockCopy(encryptedBytes, 0, result, aes.IV.Length, encryptedBytes.Length);

                    return result;
                }
            }
        }

        public static string DecryptAES(byte[] encryptedData)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = aesKey;

                // Tách IV và dữ liệu mã hóa
                byte[] iv = new byte[16];
                byte[] encryptedMessage = new byte[encryptedData.Length - iv.Length];

                Buffer.BlockCopy(encryptedData, 0, iv, 0, iv.Length);
                Buffer.BlockCopy(encryptedData, iv.Length, encryptedMessage, 0, encryptedMessage.Length);

                aes.IV = iv;

                using (ICryptoTransform decryptor = aes.CreateDecryptor())
                {
                    byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedMessage, 0, encryptedMessage.Length);
                    return Encoding.UTF8.GetString(decryptedBytes);
                }
            }
        }

        // Chuyển đổi chuỗi hex sang mảng byte
        private static byte[] HexStringToByteArray(string hex)
        {
            int length = hex.Length;
            byte[] bytes = new byte[length / 2];
            for (int i = 0; i < length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }
    }
}
