using System.Security.Cryptography;
using System.Text;

namespace uPhoto.Common;

public static class Helpers
{
	public static string CalculateHash(string input)
	{
		return Encoding.ASCII.GetString(SHA512.HashData(Encoding.ASCII.GetBytes(input)));
	}
}
