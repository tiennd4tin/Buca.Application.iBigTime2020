/***********************************************************************
 * <copyright file="FileHelper.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Monday, June 16, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace BuCA.Option
{
    public class FileHelper
    {
        #region Encryption

        public const string passPhrase = "abigtimegralzxcv"; // can be any string
        private const string saltValue = "sALtValue"; // can be any string
        private const string hashAlgorithm = "SHA1"; // can be "MD5"
        private const int passwordIterations = 7; // can be any number
        private const string initVector = "~1B2c3D4e5F6g7H8"; // must be 16 bytes
        private const int keySize = 256; // can be 192 or 128

        /// <summary>
        /// Encrypts the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string Encrypt(string data)
        {
            var bytes = Encoding.ASCII.GetBytes(initVector);
            var rgbSalt = Encoding.ASCII.GetBytes(saltValue);
            var buffer = Encoding.UTF8.GetBytes(data);
#pragma warning disable 618
            var rgbKey = new PasswordDeriveBytes(passPhrase, rgbSalt, hashAlgorithm, passwordIterations).GetBytes(keySize / 8);
#pragma warning restore 618
            var managed = new RijndaelManaged { Mode = CipherMode.CBC };
            var transform = managed.CreateEncryptor(rgbKey, bytes);
            var stream = new MemoryStream();
            var stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            byte[] inArray = stream.ToArray();
            stream.Close();
            stream2.Close();
            return Convert.ToBase64String(inArray);
        }

        /// <summary>
        /// Decrypts the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string Decrypt(string data)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(initVector);
            byte[] rgbSalt = Encoding.ASCII.GetBytes(saltValue);
            byte[] buffer = Convert.FromBase64String(data);
#pragma warning disable 618
            byte[] rgbKey = new PasswordDeriveBytes(passPhrase, rgbSalt, hashAlgorithm, passwordIterations).GetBytes(keySize / 8);
#pragma warning restore 618
            var managed = new RijndaelManaged { Mode = CipherMode.CBC };
            ICryptoTransform transform = managed.CreateDecryptor(rgbKey, bytes);
            var stream = new MemoryStream(buffer);
            var stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
            var buffer5 = new byte[buffer.Length];
            int count = stream2.Read(buffer5, 0, buffer5.Length);
            stream.Close();
            stream2.Close();
            return Encoding.UTF8.GetString(buffer5, 0, count);
        }

        public static string EncryptDataServer(string data)
        {
            var bytes = Encoding.ASCII.GetBytes(initVector);
            var rgbSalt = Encoding.ASCII.GetBytes(saltValue);
            var buffer = Encoding.UTF8.GetBytes(data);
#pragma warning disable 618
            var rgbKey = new PasswordDeriveBytes(passPhrase, rgbSalt, hashAlgorithm, passwordIterations).GetBytes(keySize / 8);
#pragma warning restore 618
            var managed = new RijndaelManaged { Mode = CipherMode.CBC };
            var transform = managed.CreateEncryptor(rgbKey, bytes);
            var stream = new MemoryStream();
            var stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            byte[] inArray = stream.ToArray();
            stream.Close();
            stream2.Close();
            return Convert.ToBase64String(inArray).Replace("=", "~").Replace('+', '-').Replace('/', '_');
        }

        /// <summary>
        /// Decrypts the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string DecryptDataServer(string data)
        {
            data = data.Replace('~', '=').Replace('-', '+').Replace('_', '/');

            byte[] bytes = Encoding.ASCII.GetBytes(initVector);
            byte[] rgbSalt = Encoding.ASCII.GetBytes(saltValue);
            byte[] buffer = Convert.FromBase64String(data);
#pragma warning disable 618
            byte[] rgbKey = new PasswordDeriveBytes(passPhrase, rgbSalt, hashAlgorithm, passwordIterations).GetBytes(keySize / 8);
#pragma warning restore 618
            var managed = new RijndaelManaged { Mode = CipherMode.CBC };
            ICryptoTransform transform = managed.CreateDecryptor(rgbKey, bytes);
            var stream = new MemoryStream(buffer);
            var stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
            var buffer5 = new byte[buffer.Length];
            int count = stream2.Read(buffer5, 0, buffer5.Length);
            stream.Close();
            stream2.Close();
            return Encoding.UTF8.GetString(buffer5, 0, count);
        }
        #endregion

        /// <summary>
        /// Writes to file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="content">The content.</param>
        public static void WriteToFile(string fileName, string content)
        {
            TextWriter tw = new StreamWriter(fileName);
            tw.Write(content);
        }

        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public static string ReadFile(string fileName)
        {
            TextReader tr = new StreamReader(fileName);
            return tr.ReadToEnd();
        }

        /// <summary>
        /// Creates the XML schema.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public static string CreateXmlSchema(string content)
        {
            var head = @"<?xml version='1.0' encoding='utf-8'?>";
            head = head + @"<BUCALicense>";
            head = head + "<License>";

            head = head + content;

            head = head + "</License>";
            head = head + "</BUCALicense>";
            return head;
        }

        /// <summary>
        /// Encrypts the file.
        /// </summary>
        /// <param name="inputFile">The input file.</param>
        /// <param name="outputFile">The output file.</param>
        public static void EncryptFile(string inputFile, string outputFile)
        {
            try
            {
                const string password = @"zxcvbnma";
                var UE = new UnicodeEncoding();
                var key = UE.GetBytes(password);
                var cryptFile = outputFile;
                var fsCrypt = new FileStream(cryptFile, FileMode.Create);
                var RMCrypto = new RijndaelManaged();
                var cs = new CryptoStream(fsCrypt, RMCrypto.CreateEncryptor(key, key), CryptoStreamMode.Write);
                var fsIn = new FileStream(inputFile, FileMode.Open);
                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);

                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Decrypts the file.
        /// </summary>
        /// <param name="inputFile">The input file.</param>
        /// <param name="outputFile">The output file.</param>
        public static void DecryptFile(string inputFile, string outputFile)
        {
            const string password = @"zxcvbnma";

            var UE = new UnicodeEncoding();
            byte[] key = UE.GetBytes(password);
            var fsCrypt = new FileStream(inputFile, FileMode.Open);
            var RMCrypto = new RijndaelManaged();
            var cs = new CryptoStream(fsCrypt, RMCrypto.CreateDecryptor(key, key), CryptoStreamMode.Read);

            var fsOut = new FileStream(outputFile, FileMode.Create);
            int data;

            while ((data = cs.ReadByte()) != -1)
            {
                fsOut.WriteByte((byte)data);
            }

            fsOut.Close();
            cs.Close();
            fsCrypt.Close();
        }

        /// <summary>
        /// Encrypts the string to file.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="outputFile">The output file.</param>
        public static void EncryptStringToFile(string content, string outputFile)
        {
            try
            {
                const string password = @"zxcvbnma";
                var UE = new UnicodeEncoding();
                var key = UE.GetBytes(password);
                var cryptFile = outputFile;
                var fsCrypt = new FileStream(cryptFile, FileMode.Create);
                var RMCrypto = new RijndaelManaged();
                var cs = new CryptoStream(fsCrypt, RMCrypto.CreateEncryptor(key, key), CryptoStreamMode.Write);

                var abData = Encoding.UTF8.GetBytes(content);
                foreach (byte t in abData)
                {
                    cs.WriteByte(t);
                }

                cs.Close();
                fsCrypt.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Decrypts the file.
        /// </summary>
        /// <param name="inputFile">The input file.</param>
        /// <returns></returns>
        public static string DecryptFile(string inputFile)
        {
            try
            {
                const string password = @"zxcvbnma";
                var UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);
                var fsCrypt = new FileStream(inputFile, FileMode.Open);
                var RMCrypto = new RijndaelManaged();
                var cs = new CryptoStream(fsCrypt, RMCrypto.CreateDecryptor(key, key), CryptoStreamMode.Read);
                var reader = new StreamReader(cs);
                var read = reader.ReadToEnd();

                cs.Close();
                fsCrypt.Close();
                return read;
            }
            catch (Exception)
            {
                MessageBox.Show("Thông tin bản quyền không đúng, vui lòng kiểm tra lại!", "Cảnh báo",
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return "";
            }
        }

        public static void CopyFileStream(string inputFile, string outputFile)
        {
            using (Stream inStream = File.Open(inputFile, FileMode.Open))
            {
                using (Stream outStream = File.Create(outputFile))
                {
                    while (inStream.Position < inStream.Length)
                    {
                        outStream.WriteByte((byte)inStream.ReadByte());
                    }
                }
            }
        }

        /// <summary>
        /// Gen lại file license
        /// </summary>
        /// <param name="companyCode"></param>
        /// <param name="companyName"></param>
        /// <param name="companyAddress"></param>
        /// <param name="parentCompanyName"></param>
        /// <param name="directorName"></param>
        /// <param name="outputLicenseFileName"></param>
        /// <param name="path"></param>
        /// <param name="expriedTime"></param>
        /// <param name="licenseNumber"></param>
        /// <returns></returns>
        public static bool CreateFileLicense(string companyCode, string companyName, string companyAddress, string parentCompanyName,
            string directorName, string outputLicenseFileName, string path, DateTime expriedTime, string licenseNumber)
        {
            try
            {
                var oCrypto = new Crypto(Crypto.SymmProvEnum.Rijndael);
                var sEncrypt = companyName.Trim().Replace("&", " và ") + "@" + companyAddress.Trim().Replace("&", " và ") + "@" + parentCompanyName.Trim().Replace("&", " và ") + "@" + directorName.Trim() + "@" + licenseNumber.Trim() + "@" + expriedTime.ToString("dd/MM/yyyy").Trim();
                var signature = oCrypto.Encrypting(sEncrypt, FileHelper.passPhrase);

                var content = "<CustomerName>" + companyName.Trim().Replace("&", " và ") + "</CustomerName>";
                content = content + "<CustomerAddress>" + companyAddress.Trim().Replace("&", " và ") + "</CustomerAddress>";
                content = content + "<CustomerParent>" + parentCompanyName.Trim().Replace("&", " và ") + "</CustomerParent>";
                content = content + "<DirectoryName>" + directorName.Trim() + "</DirectoryName>";
                content = content + "<Signature>" + signature + "</Signature>";
                content = content + "<CompanyCode>" + companyCode.Trim() + "</CompanyCode>";
                content = content + "<LicenseNumber>" + licenseNumber + "</LicenseNumber>";
                content = content + "<ExpriedDate>" + (expriedTime.ToString("dd/MM/yyyy")) + "</ExpriedDate>";
                //content = content + "<LicenseNumber>" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + "</LicenseNumber>";

                var xmlContent = FileHelper.CreateXmlSchema(content);

                var savePath = Path.Combine(System.Windows.Forms.Application.StartupPath, System.Windows.Forms.Application.StartupPath);
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }

                //var savePath = "";//Edit path

                FileHelper.EncryptStringToFile(xmlContent, savePath + @"\" + outputLicenseFileName.Trim());
                return true;
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message);
                return false;
            }
            return false;

        }
    }
}
