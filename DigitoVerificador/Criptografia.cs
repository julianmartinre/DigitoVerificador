using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DigitoVerificador
{
    public static class Criptografia
    {
        public static string Hash(string input)
        {
            MD5 mMD5Hash = MD5.Create();
            byte[] mBytes = mMD5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder mStringBuilder = new StringBuilder();
            for (int i = 0; i <= mBytes.Length - 1; i++)
            {
                mStringBuilder.Append(mBytes[i].ToString("X2"));
            }
            return mStringBuilder.ToString();
        }
    }
}
