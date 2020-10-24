using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;

namespace Kidregs.Libraries.Class
{
    public static class SafeCrypto
    {
        private static readonly ICryptoTransform Encryptor;
        private static readonly ICryptoTransform Decryptor;

        static SafeCrypto()
        {
            var aesObj = Aes.Create();
            //必须是16个字符，因为密码默认128位
            aesObj.Key = Encoding.UTF8.GetBytes("amRoSktTREpqMDk4");
            aesObj.Mode = CipherMode.ECB;
            aesObj.Padding = PaddingMode.PKCS7;

            Encryptor = aesObj.CreateEncryptor();
            Decryptor = aesObj.CreateDecryptor();
        }

        public static string Encrypt(string source)
        {
            byte[] toEncrypt = Encoding.UTF8.GetBytes(source);
            byte[] output = Encryptor.TransformFinalBlock(toEncrypt, 0, toEncrypt.Length);
            return Convert.ToBase64String(output);
        }
 
        public static string Decrypt(string source)
        {
            byte[] toDecrypt = Convert.FromBase64String(source);
            byte[] output = Decryptor.TransformFinalBlock(toDecrypt,0,toDecrypt.Length);
            return Encoding.UTF8.GetString(output);
        }
    }
}
