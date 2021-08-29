using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropTransaction.Common
{
    public static class CommonUtil
    {
		public static readonly string LogPath = @".\Logs\PTrans_.log";

		public static readonly string DBPath = @"DataSource=.\Resources\Properties.db;Version=3;";

		public static string GetHashedString(string input)
		{
			// Use input string to calculate MD5 hash
			using (var md5 = System.Security.Cryptography.MD5.Create())
			{
				byte[] inputBytes = Encoding.ASCII.GetBytes(input);
				byte[] hashBytes = md5.ComputeHash(inputBytes);

				// Convert the byte array to hexadecimal string
				var sb = new StringBuilder();
				for (int i = 0; i < hashBytes.Length; i++) {
					sb.Append(hashBytes[i].ToString("X2"));
				}
				return sb.ToString();
			}
		}
	}
}
