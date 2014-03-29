using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebToolService
{
    public class AESHelper
    {
        private Encoding byteEncoder = Encoding.UTF8;
        #region RijnKey
        private byte[] rijnKey = null;
        public byte[] RijnKey
        {
            get
            {
                rijnKey = rijnKey ?? byteEncoder.GetBytes("0dJlBKX_Ai4Ff2g_3yuZh5n_ao3onWb_");
                return rijnKey;
            }
        } 
        #endregion
        #region RijnIV
        private byte[] rijnIV = null;
        public byte[] RijnIV
        {
            get
            {
                rijnIV = rijnIV ?? byteEncoder.GetBytes("0dJlBKX_Ai4Ff2g_");
                return rijnIV;
            }
        }
        #endregion


        public string EncryptStringToBytes(string plainText)
        {
            // Check arguments. 
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (RijnKey == null || RijnKey.Length <= 0)
                throw new ArgumentNullException("Key");
            if (RijnIV == null || RijnIV.Length <= 0)
                throw new ArgumentNullException("Key");
            byte[] encrypted;
            // Create an RijndaelManaged object 
            // with the specified key and IV. 
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = RijnKey;
                rijAlg.IV = RijnIV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption. 
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream. 
            return Convert.ToBase64String(encrypted);

        }
        public string DecryptStringFromBytes(string s)
        {
            byte[] cipherText = Convert.FromBase64String(s);
            // Check arguments. 
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (RijnKey == null || RijnKey.Length <= 0)
                throw new ArgumentNullException("Key");
            if (RijnIV == null || RijnIV.Length <= 0)
                throw new ArgumentNullException("Key");

            // Declare the string used to hold 
            // the decrypted text. 
            string plaintext = null;

            // Create an RijndaelManaged object 
            // with the specified key and IV. 
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = RijnKey;
                rijAlg.IV = RijnIV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption. 
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream 
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }
    }
}