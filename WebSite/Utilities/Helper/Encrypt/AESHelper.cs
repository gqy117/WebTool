namespace Utilities
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    public class AESHelper
    {
        private Encoding byteEncoder = Encoding.UTF8;

        private byte[] rijnIv = null;

        private byte[] rijnKey = null;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = "Justification")]
        public byte[] RijnIv
        {
            get
            {
                this.rijnIv = this.rijnIv ?? this.byteEncoder.GetBytes("0dJlBKX_Ai4Ff2g_");

                return this.rijnIv;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = "Justification")]
        public byte[] RijnKey
        {
            get
            {
                this.rijnKey = this.rijnKey ?? this.byteEncoder.GetBytes("0dJlBKX_Ai4Ff2g_3yuZh5n_ao3onWb_");

                return this.rijnKey;
            }
        }

        public string DecryptStringFromBytes(string s)
        {
            byte[] cipherText = Convert.FromBase64String(s);

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

        public string EncryptStringToBytes(string plaintext)
        {
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
    }
}