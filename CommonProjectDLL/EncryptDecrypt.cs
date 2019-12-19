using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CommonProjectDLL
{
    public class EncryptDecrypt
    {
        string key = "jhdgloeuo@09385g";

        public string EncryptData(string str_to_encrypt)
        {
            try
            {
                string encrypt_pwd;
                // Create a new instance of the AesCryptoServiceProvider
                // class.  This generates a new key and initialization 
                // vector (IV).
                using (AesCryptoServiceProvider myAes = new AesCryptoServiceProvider())
                {
                    myAes.Key = ASCIIEncoding.ASCII.GetBytes(key);
                    myAes.IV = ASCIIEncoding.ASCII.GetBytes(key);
                    // Encrypt the string to an array of bytes.
                    byte[] encrypted = EncryptStringToBytes_Aes(str_to_encrypt, myAes.Key, myAes.IV);

                    encrypt_pwd = ByteArrayToString(encrypted);

                    //  string str_to_decrypt = DecryptData(encrypt_pwd);

                    //byte[] encrypted1 = StringToByteArray(encrypt_pwd);

                    // Decrypt the bytes to a string.
                    // string roundtrip = DecryptStringFromBytes_Aes(encrypted1, myAes.Key, myAes.IV);
                }
                return encrypt_pwd;
            }
            catch (Exception ex)
            {
                return "false";

            }

        }

        public string DecryptData(string str_to_decrypt)
        {
            try
            {
                string decrypt_pwd;
                // Create a new instance of the AesCryptoServiceProvider
                // class.  This generates a new key and initialization 
                // vector (IV).
                using (AesCryptoServiceProvider myAes = new AesCryptoServiceProvider())
                {
                    myAes.Key = ASCIIEncoding.ASCII.GetBytes(key);
                    myAes.IV = ASCIIEncoding.ASCII.GetBytes(key);
                    // Encrypt the string to an array of bytes.
                    byte[] encrypted = StringToByteArray(str_to_decrypt);

                    // Decrypt the bytes to a string.
                    decrypt_pwd = DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);

                    //Display the original data and the decrypted data.
                    // Console.WriteLine("Original:   {0}", original);
                    //Console.WriteLine("Round Trip: {0}", roundtrip);
                }
                return decrypt_pwd;
            }
            catch (Exception ex)
            {
                return "false";

            }

        }

        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("Key");
            byte[] encrypted;
            // Create an AesCryptoServiceProvider object
            // with the specified key and IV.
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

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
            return encrypted;

        }

        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("Key");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an AesCryptoServiceProvider object
            // with the specified key and IV.
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

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

        static string ByteArrayToString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }

        static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }


    }
}
