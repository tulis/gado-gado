<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Namespace>System.Security.Cryptography</Namespace>
  <Namespace>System.Security.Cryptography.Pkcs</Namespace>
  <Namespace>System.Security.Cryptography.X509Certificates</Namespace>
  <Namespace>System.Security.Cryptography.Xml</Namespace>
  <Namespace>System.Security.Permissions</Namespace>
</Query>

void Main()
{
	"------Key------".Dump();
	var keyBytes = GenerateKey();
	keyBytes.Dump();
	
	var keyString = ConvertBytesToUnicode(keyBytes);
	keyString.Dump();
	
	ConvertUnicodeToBytes(keyString).Dump();
	
	"------Initialization Vector------".Dump();
	var initializationVectorBytes = GenerateInitializationVector();
	initializationVectorBytes.Dump();
	
	var initializationVectorString = ConvertBytesToUnicode(initializationVectorBytes);
	initializationVectorString.Dump();
	
	ConvertUnicodeToBytes(initializationVectorString).Dump();
}

// Define other methods and classes here
byte[] GenerateKey()
{
	using(var aesCryptoServiceProvider = new AesCryptoServiceProvider())
	{
		return aesCryptoServiceProvider.Key;
	}
}

byte[]GenerateInitializationVector()
{
	using(var aesCryptoServiceProvider = new AesCryptoServiceProvider())
	{
		return aesCryptoServiceProvider.IV;
	}
}

string ConvertBytesToUnicode(byte[] bytes)
{
	var unicodeEncoding = new UnicodeEncoding();
	return unicodeEncoding.GetString(bytes);
}

byte[] ConvertUnicodeToBytes(string unicode)
{
	var unicodeEncoding = new UnicodeEncoding();
	return unicodeEncoding.GetBytes(unicode);
}