using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace DAL
{
    [Serializable]
    public static class Encryption
    {


        // Encryption

        public static void encryption(object ob, string path)
        {
            byte[] key = { 1, 2, 3, 4, 5, 6, 7, 8 }; // Where to store these keys is the tricky part, 
            // you may need to obfuscate them or get the user to input a password each time
            byte[] iv = { 1, 2, 3, 4, 5, 6, 7, 8 };

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            using (var cryptoStream = new CryptoStream(fs, des.CreateEncryptor(key, iv), CryptoStreamMode.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // This is where you serialize the class

                formatter.Serialize(cryptoStream, ob);
            }
        }

        public static object Decryption(string path)
        {
            byte[] key = { 1, 2, 3, 4, 5, 6, 7, 8 }; // Where to store these keys is the tricky part, 
            // you may need to obfuscate them or get the user to input a password each time
            byte[] iv = { 1, 2, 3, 4, 5, 6, 7, 8 };

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            // Decryption
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (var cryptoStream = new CryptoStream(fs, des.CreateDecryptor(key, iv), CryptoStreamMode.Read))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // This is where you deserialize the class
                object deserialized = (object)formatter.Deserialize(cryptoStream);
                return deserialized;
            }
        }

        public static void checkEncryption(object ob, string path)
        {
            try
            {
                // Read in non-existent file.
                using (StreamReader reader = new StreamReader(path))
                {
                    reader.ReadToEnd();
                }
            }
            catch (FileNotFoundException ex)
            {
                Encryption.encryption(ob, path);
            }

        }
    }
}
