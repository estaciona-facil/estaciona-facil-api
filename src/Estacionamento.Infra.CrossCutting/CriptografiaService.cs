using System.Security.Cryptography;

namespace Estacionamento.Infra.CrossCutting
{
    internal static class CriptografiaService
    {
        static readonly byte[] Key =
        {
            36, 119, 22, 41, 107, 142, 29, 251, 155, 116, 105, 88, 86, 189, 181, 79, 152, 39, 81, 216, 216, 141, 130, 81,
            31, 177, 130, 63, 184, 252, 248, 87
        };

        static readonly byte[] Iv = { 109, 231, 35, 51, 239, 131, 188, 74, 182, 91, 176, 189, 240, 105, 43, 253 };

        public static string Criptografar(string value)
        {
            // Check arguments.
            if (value == null || value.Length <= 0)
                throw new ArgumentNullException(nameof(value));

            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = Iv;

                // Create a decrytor to perform the stream transform.
                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(value);
                        }

                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return Convert.ToBase64String(encrypted);
        }

        public static string Descriptografar(string value)
        {
            // Check arguments.
            if (value == null || value.Length <= 0)
                throw new ArgumentNullException(nameof(value));

            // Declare the string used to hold the decrypted text.

            // Create an Aes object with the specified key and IV.
            using var aesAlg = Aes.Create();
            aesAlg.Key = Key;
            aesAlg.IV = Iv;

            // Create a decrytor to perform the stream transform.
            var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            // Create the streams used for decryption.
            using var msDecrypt = new MemoryStream(Convert.FromBase64String(value));
            using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            using var srDecrypt = new StreamReader(csDecrypt);
            // Read the decrypted bytes from the decrypting stream and place them in a string.
            var plaintext = srDecrypt.ReadToEnd();

            return plaintext;
        }
    }
}
