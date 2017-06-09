﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Linq;

namespace X.Core.Utility
{
    public class Secret
    {
        #region Xc
        static byte[] getXcKey(string k)
        {
            var key = Core.Utility.Secret.MD5(Encoding.UTF8.GetString(new byte[] { 43, 56, 48, 120, 99, 46, 99, 111, 109, 43 }) + k);
            Console.WriteLine("key->" + key);
            return Encoding.UTF8.GetBytes(key);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="data"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static byte[] XcDecode(byte[] data, string k)
        {
            var k1 = getXcKey(k);
            var k2 = data.Take(32);
            if (!Enumerable.SequenceEqual(k1, k2)) throw new Exception("Decode Error");

            var dt = data.Skip(32).ToArray();

            var i = 0;
            for (var j = 0; j < dt.Length; j++) dt[j] = (byte)(dt[j] ^ k1[i++ % k1.Length]);

            return dt;
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="data"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static byte[] XcEncode(byte[] data, string k)
        {
            var key = getXcKey(k);
            var i = 0;
            var dts = data.ToList();
            for (var j = 0; j < dts.Count; j++) dts[j] = (byte)(dts[j] ^ key[i++ % key.Length]);
            dts.InsertRange(0, key.ToList());
            return dts.ToArray();
        }

        #endregion

        #region AES
        private static byte[] AesKeys = new byte[] { 0x41, 0x72, 0x65, 0x79, 0x6f, 0x75, 0x6d, 0x79, 0x53, 110, 0x6f, 0x77, 0x6d, 0x61, 110, 0x3f };
        public static string AesDecode(string decryptString, string decryptKey)
        {
            if (decryptString == string.Empty)
            {
                return string.Empty;
            }
            try
            {
                decryptKey = decryptKey.Substring(0, 0x20);
                decryptKey = decryptKey.PadRight(0x20, ' ');
                byte[] inputBuffer = Convert.FromBase64String(decryptString);
                byte[] bytes = new RijndaelManaged { Key = Encoding.UTF8.GetBytes(decryptKey), IV = AesKeys }.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
                return Encoding.UTF8.GetString(bytes);
            }
            catch
            {
                return "";
            }
        }

        public static string AesEncode(string encryptString, string encryptKey)
        {
            encryptKey = encryptKey.Substring(0, 0x20);
            encryptKey = encryptKey.PadRight(0x20, ' ');
            byte[] bytes = Encoding.UTF8.GetBytes(encryptString);
            return Convert.ToBase64String(new RijndaelManaged { Key = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 0x20)), IV = AesKeys }.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length));
        }
        #endregion

        #region DES
        private static byte[] DesKeys = new byte[] { 0x12, 0x34, 0x56, 120, 0x90, 0xab, 0xcd, 0xef };
        public static string DesDecode(string decryptString, string decryptKey)
        {

            try
            {
                if (decryptString == string.Empty || decryptKey.Length < 8)
                {
                    decryptKey = DesKeys.ToString();
                }
                else
                {
                    decryptKey = decryptKey.Substring(0, 8);
                    decryptKey = decryptKey.PadRight(8, ' ');
                }
                byte[] bytes = Encoding.UTF8.GetBytes(decryptKey);
                byte[] keys = DesKeys;
                byte[] buffer = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(bytes, keys), CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                return Encoding.UTF8.GetString(stream.ToArray());
            }
            catch
            {
                return "";
            }
        }

        public static string DesEncode(string encryptString, string encryptKey)
        {
            encryptKey = encryptKey.Substring(0, 8);
            encryptKey = encryptKey.PadRight(8, ' ');
            byte[] bytes = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
            byte[] keys = DesKeys;
            byte[] buffer = Encoding.UTF8.GetBytes(encryptString);
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(bytes, keys), CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            return Convert.ToBase64String(stream.ToArray());
        }
        #endregion

        #region Md5
        /// <summary>
        /// MD5函数
        /// </summary>/// <param name="str">原始字符串</param>/// <returns>MD5结果</returns>
        public static string MD5(string str)
        {
            return MD5(str, 3);
        }
        public static string MD5(string str, int c)
        {
            if (c > 0) str += "zkmj_xcms_love";
            if (string.IsNullOrEmpty(str)) return "";
            byte[] b = Encoding.UTF8.GetBytes(str);
            using (MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider())
            {
                b = mD5CryptoServiceProvider.ComputeHash(b);
            }
            string ret = "";
            for (int i = 0; i < b.Length; i++) ret += b[i].ToString("x").PadLeft(2, '0');
            c--;
            if (c <= 0) return ret;
            return MD5(ret, c);
        }
        #endregion

        #region SHA
        /// <summary>
        /// SHA256函数
        /// </summary>
        /// /// <param name="str">原始字符串</param>/// <returns>SHA256结果</returns>
        public static string SHA256(string str)
        {
            byte[] SHA256Data = Encoding.UTF8.GetBytes(str);
            SHA256Managed Sha256 = new SHA256Managed();
            byte[] Result = Sha256.ComputeHash(SHA256Data);
            return BitConverter.ToString(Result).Replace("-", "");
        }
        public static string SHA348(string str)
        {
            byte[] SHA256Data = Encoding.UTF8.GetBytes(str);
            SHA384Managed Sha256 = new SHA384Managed();
            byte[] Result = Sha256.ComputeHash(SHA256Data);
            return BitConverter.ToString(Result).Replace("-", "");
        }
        public static string SHA512(string str)
        {
            byte[] SHA256Data = Encoding.UTF8.GetBytes(str);
            SHA512Managed Sha256 = new SHA512Managed();
            byte[] Result = Sha256.ComputeHash(SHA256Data);
            return BitConverter.ToString(Result).Replace("-", "");
        }
        public static string SHA1(string str)
        {
            byte[] SHA256Data = Encoding.UTF8.GetBytes(str);
            SHA1Managed Sha256 = new SHA1Managed();
            byte[] Result = Sha256.ComputeHash(SHA256Data);
            return BitConverter.ToString(Result).Replace("-", "");
        }
        #endregion

        #region Base64
        public static string ToBase64(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(bytes);
        }

        public static string FormBase64(string code)
        {
            var bytes = Convert.FromBase64String(code);
            return Encoding.UTF8.GetString(bytes);
        }
        #endregion

        public class Rc4
        {
            static string key = "MmPSJmom2RSvDfBUAZZsMP4IFeIaHyUb9uZiu5alFfRjrwTxJ06XIeWTKlG49Cxz";

            public static string Encrypt(string data, string k)
            {
                if (string.IsNullOrEmpty(data)) return "";
                return ByteToHex(EncryptEx(Encoding.UTF8.GetBytes(data), k));
            }
            public static string Encrypt(string data)
            {
                return Encrypt(data, key);
            }
            public static string Decrypt(string data, string k)
            {
                if (string.IsNullOrEmpty(data)) return "";
                return Encoding.UTF8.GetString(EncryptEx(HexToByte(data.ToUpper()), k));
            }
            public static string Decrypt(string data)
            {
                return Decrypt(data, key);
            }
            static byte[] EncryptEx(byte[] data, string k)
            {
                if (data == null) return null;
                byte[] output = new byte[data.Length];
                long i = 0;
                long j = 0;
                byte[] mBox = GetKey(Encoding.UTF8.GetBytes(k), 256);
                for (long offset = 0; offset < data.Length; offset++)
                {
                    i = (i + 1) % mBox.Length;
                    j = (j + mBox[i]) % mBox.Length;
                    byte temp = mBox[i];
                    mBox[i] = mBox[j];
                    mBox[j] = temp;
                    byte a = data[offset];
                    byte b = mBox[(mBox[i] + mBox[j]) % mBox.Length];
                    output[offset] = (byte)((int)a ^ (int)b);
                }

                return output;
            }
            static string ByteToHex(byte[] vByte)
            {
                if (vByte == null || vByte.Length < 1) return null;
                var sb = new StringBuilder(vByte.Length * 2);
                for (int i = 0; i < vByte.Length; i++)
                {
                    if ((uint)vByte[i] < 0) return null;
                    var k = (uint)vByte[i] / 16;
                    sb.Append((char)(k + ((k > 9) ? 'A' - 10 : '0')));
                    k = (uint)vByte[i] % 16;
                    sb.Append((char)(k + ((k > 9) ? 'A' - 10 : '0')));
                }
                return sb.ToString().ToLower();
            }
            static byte[] HexToByte(string szHex)
            {
                int iLen = szHex.Length;
                if (iLen <= 0 || 0 != iLen % 2)
                {
                    return null;
                }
                int dwCount = iLen / 2;
                uint tmp1, tmp2;
                byte[] pbBuffer = new byte[dwCount];
                for (int i = 0; i < dwCount; i++)
                {
                    tmp1 = szHex[i * 2] - (((uint)szHex[i * 2] >= 'A') ? (uint)'A' - 10 : '0');
                    if (tmp1 >= 16) return null;
                    tmp2 = szHex[i * 2 + 1] - (szHex[i * 2 + 1] >= (uint)'A' ? (uint)'A' - 10 : '0');
                    if (tmp2 >= 16) return null;
                    pbBuffer[i] = (byte)(tmp1 * 16 + tmp2);
                }
                return pbBuffer;
            }
            static byte[] GetKey(byte[] pass, int kLen)
            {
                byte[] mBox = new byte[kLen];

                for (long i = 0; i < kLen; i++) mBox[i] = (byte)i;
                long j = 0;
                for (long i = 0; i < kLen; i++)
                {
                    j = (j + mBox[i] + pass[i % pass.Length]) % kLen;
                    byte temp = mBox[i];
                    mBox[i] = mBox[j];
                    mBox[j] = temp;
                }
                return mBox;
            }
        }
    }
}