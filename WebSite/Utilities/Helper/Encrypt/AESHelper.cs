namespace WebToolService
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;

    public class AESHelper
    {
        private Encoding byteEncoder = Encoding.UTF8;
        private byte[] rijnKey = null; 
        private byte[] rijnIv = null;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = "Justification")]
        public byte[] RijnKey
        {
            get
            {
                this.rijnKey = this.rijnKey ?? this.byteEncoder.GetBytes("0dJlBKX_Ai4Ff2g_3yuZh5n_ao3onWb_");

                return this.rijnKey;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = "Justification")]
        public byte[] RijnIv
        {
            get
            {
                this.rijnIv = this.rijnIv ?? this.byteEncoder.GetBytes("0dJlBKX_Ai4Ff2g_");

                return this.rijnIv;
            }
        }

        public string EncryptStringToBytes(string plaintext)
        {
            // Check arguments. 
            if (plaintext == null || plaintext.Length <= 0)
            {
                throw new ArgumentNullException("plaintext");
            }

            if (this.RijnKey == null || this.RijnKey.Length <= 0)
            {
                throw new ArgumentNullException("Key");
            }

            if (this.RijnIv == null || this.RijnIv.Length <= 0)
            {
                throw new ArgumentNullException("Key");
            }

            byte[] encrypted;
            /*Create an RijndaelManaged object 
               with the specified key and IV. */
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = this.RijnKey;
                rijAlg.IV = this.RijnIv;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption. 
                using (MemoryStream memoryStreamEncrypt = new MemoryStream())
                {
                    using (CryptoStream cryptoStreamEncrypt = new CryptoStream(memoryStreamEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriterEncrypt = new StreamWriter(cryptoStreamEncrypt))
                        {
                            // Write all data to the stream.
                            streamWriterEncrypt.Write(plaintext);
                        }

                        encrypted = memoryStreamEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream. 
            return Convert.ToBase64String(encrypted);
        }

        public string DecryptStringFromBytes(string s)
        {
            byte[] cipherText = Convert.FromBase64String(s);

            ////Check arguments

            if (cipherText == null || cipherText.Length <= 0)
            {
                throw new ArgumentNullException("cipherText");
            }

            if (this.RijnKey == null || this.RijnKey.Length <= 0)
            {
                throw new ArgumentNullException("Key");
            }

            if (this.RijnIv == null || this.RijnIv.Length <= 0)
            {
                throw new ArgumentNullException("Key");
            }

            // Declare the string used to hold 
            // the decrypted text. 
            string plaintext = null;

            // Create an RijndaelManaged object 
            // with the specified key and IV. 
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = this.RijnKey;
                rijAlg.IV = this.RijnIv;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption. 
                using (MemoryStream memoryStreamEncrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream cryptoStreamEncrypt = new CryptoStream(memoryStreamEncrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamWriterEncrypt = new StreamReader(cryptoStreamEncrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream 
                            // and place them in a string.
                            plaintext = streamWriterEncrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}