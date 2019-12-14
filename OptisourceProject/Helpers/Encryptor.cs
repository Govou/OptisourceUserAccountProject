using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace OptisourceProject.WebApi.Helpers
{
    public class Encryptor
    {
        public static string EncryptAesManaged(string raw)
        {
            byte[] encrypted1 = null;
            try
            {
                // Create Aes that generates a new key and initialization vector (IV).    
                // Same key must be used in encryption and decryption    
                using (AesManaged aes = new AesManaged())
                {
                    // Encrypt string    
                    encrypted1 = Encrypt(raw, aes.Key, aes.IV).ToArray();


                }

            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

            return Encoding.UTF8.GetString(encrypted1, 0, encrypted1.Length);
        }
        static byte[] Encrypt(string plainText, byte[] Key, byte[] IV)
        {
            byte[] encrypted;

            string ClientSecretKey = "g33I8mkdaVlZ8hN2ny2p0hjs9oJFMe8NMK4q1XKQdgI=";
            string ClientIVKey = "IrJNjuXuKev9VgAWvjS24A==";

            //  Key = Encoding.ASCII.GetBytes(ClientSecretKey);
            Key = Convert.FromBase64String(ClientSecretKey);
            //  IV = Encoding.ASCII.GetBytes(ClientIVKey);
            IV = Convert.FromBase64String(ClientIVKey);
            // Create a new AesManaged.    
            using (AesManaged aes = new AesManaged())
            {

                // Create encryptor    
                ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
                // Create MemoryStream    
                using (MemoryStream ms = new MemoryStream())
                {

                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        // Create StreamWriter and write data to a stream    
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(plainText);
                        encrypted = ms.ToArray();
                    }
                }
            }
            // Return encrypted data    
            return encrypted;
        }
    }
}