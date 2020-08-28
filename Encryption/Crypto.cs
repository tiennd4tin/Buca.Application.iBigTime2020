// ***********************************************************************
// Assembly         : Encryption
// Author           : thangnd
// Created          : 09-27-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-18-2010
// ***********************************************************************
// <copyright file="Crypto.cs" company="Data & Object Factory, LLC.">
//     Copyright © Data & Object Factory, LLC. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Globalization;

namespace Encryption
{
    /// <summary>
    /// Cryptographic utility class for encryption and decryption of string values.
    /// </summary>
    public static class Crypto
    {
        // Arbitrary key and iv vector. 
        // You will want to generate (and protect) your own Key and Iv when using encryption.
        private static string actionKey = "000102030405060708090A0B0C0D0E0F1011121314151617";
        private static string actionIv = "0001020304050607";

        private static TripleDESCryptoServiceProvider des3;

        /// <summary>
        /// Default constructor. Initializes the DES3 encryption provider. 
        /// </summary>
        static Crypto()
        {
            des3 = new TripleDESCryptoServiceProvider { Mode = CipherMode.CBC };
        }

        /// <summary>
        /// Generates a 24 byte Hex key.
        /// </summary>
        /// <returns>Generated Hex key.</returns>
        public static string GenerateKey()
        {
            // Length is 24
            des3.GenerateKey();
            return BytesToHex(des3.Key);
        }

        /// <summary>
        /// Generates an 8 byte Hex IV (Initialization Vector).
        /// </summary>
        /// <returns>Initialization vector.</returns>
        public static string GenerateIV()
        {
            // Length = 8
            des3.GenerateIV();
            return BytesToHex(des3.IV);
        }

        /// <summary>
        /// Converts a hex string to a byte array.
        /// </summary>
        /// <param name="hex">Hex string.</param>
        /// <returns>Byte array.</returns>
        private static byte[] HexToBytes(string hex)
        {
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length / 2; i++)
            {
                string code = hex.Substring(i * 2, 2);
                bytes[i] = byte.Parse(code, NumberStyles.HexNumber);
            }
            return bytes;
        }

        /// <summary>
        /// Converts a byte array to a hex string.
        /// </summary>
        /// <param name="bytes">Byte array.</param>
        /// <returns>Converted hex string</returns>
        private static string BytesToHex(byte[] bytes)
        {
            var hex = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
                hex.AppendFormat("{0:X2}", i);
            return hex.ToString();
        }

        /// <summary>
        /// Encrypts a memory string (i.e. variable).
        /// </summary>
        /// <param name="data">String to be encrypted.</param>
        /// <param name="key">Encryption key.</param>
        /// <param name="iv">Encryption initialization vector.</param>
        /// <returns>Encrypted string.</returns>
        public static string Encrypt(string data, string key, string iv)
        {
            byte[] bdata = Encoding.ASCII.GetBytes(data);
            byte[] bkey = HexToBytes(key);
            byte[] biv = HexToBytes(iv);

            var stream = new MemoryStream();
            var encStream = new CryptoStream(stream, des3.CreateEncryptor(bkey, biv), CryptoStreamMode.Write);
            encStream.Write(bdata, 0, bdata.Length);
            encStream.FlushFinalBlock();
            encStream.Close();

            return BytesToHex(stream.ToArray());
        }

        /// <summary>
        /// Decrypts a memory string (i.e. variable).
        /// </summary>
        /// <param name="data">String to be decrypted.</param>
        /// <param name="key">Original encryption key.</param>
        /// <param name="iv">Original initialization vector.</param>
        /// <returns>Decrypted string.</returns>
        public static string Decrypt(string data, string key, string iv)
        {
            byte[] bdata = HexToBytes(data);
            byte[] bkey = HexToBytes(key);
            byte[] biv = HexToBytes(iv);

            var stream = new MemoryStream();
            var encStream = new CryptoStream(stream, des3.CreateDecryptor(bkey, biv), CryptoStreamMode.Write);

            encStream.Write(bdata, 0, bdata.Length);
            encStream.FlushFinalBlock();
            encStream.Close();

            return Encoding.ASCII.GetString(stream.ToArray());
        }

        /// <summary>
        /// Standard encrypt method for Patterns in Action.
        /// Uses the predefined key and iv.
        /// </summary>
        /// <param name="data">String to be encrypted.</param>
        /// <returns>Encrypted string</returns>
        public static string ActionEncrypt(string data)
        {
            return Encrypt(data, actionKey, actionIv);
        }

        /// <summary>
        /// Standard decrypt method for Patterns in Action.
        /// Uses the predefined key and iv.
        /// </summary>
        /// <param name="data">String to be decrypted.</param>
        /// <returns>Decrypted string.</returns>
        public static string ActionDecrypt(string data)
        {
            return Decrypt(data, actionKey, actionIv);
        }
    }
}