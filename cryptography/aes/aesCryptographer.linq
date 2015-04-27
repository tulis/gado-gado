<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Namespace>System.Runtime.Serialization</Namespace>
  <Namespace>System.Runtime.Serialization.Configuration</Namespace>
  <Namespace>System.Runtime.Serialization.Formatters.Binary</Namespace>
  <Namespace>System.Runtime.Serialization.Json</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
  <Namespace>System.Security.Cryptography.Pkcs</Namespace>
  <Namespace>System.Security.Cryptography.X509Certificates</Namespace>
  <Namespace>System.Security.Cryptography.Xml</Namespace>
  <Namespace>System.Security.Permissions</Namespace>
  <Namespace>System.Xml</Namespace>
</Query>

void Main()
{
	var key = GenerateKey();
	var initializationVector = GenerateInitializationVector();
	var person = new Person("Aang", 10);
	var personBytes = person.ToBytes();
	personBytes.Dump();
	
	"-----Encrypting----".Dump();
	var personEncrypted = Encrypt(personBytes, key, initializationVector);
	personEncrypted.Dump();
	//(personEncrypted.ToObject() is Person).Dump();
	//personEncrypted.Dump();	
	
	"----Decrypting-----".Dump();	
	var personDecrypted = Decrypt(personEncrypted, key, initializationVector);	
	//personDecrypted.Dump();
	((Person) personDecrypted.ToObject()).Dump();
}

// Define other methods and classes here
byte[] Encrypt(byte[] item, byte[] key, byte[] initializationVector)
{
	using(var aesCryptoServiceProvider = new AesCryptoServiceProvider())
	{
		aesCryptoServiceProvider.Key = key;
		aesCryptoServiceProvider.IV = initializationVector;
		
		var cryptoTransform = aesCryptoServiceProvider.CreateEncryptor();
		
		using(var memoryStream = new MemoryStream())
		using(var cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))		
		{
			cryptoStream.Write(item, 0, item.Length);
			cryptoStream.FlushFinalBlock();
			return memoryStream.ToArray();
		}
	}
}

byte[] Decrypt(byte[] item, byte[]key, byte[] initializationVector)
{
	using(var aesCryptoServiceProvider = new AesCryptoServiceProvider())
	{
		aesCryptoServiceProvider.Key = key;
		aesCryptoServiceProvider.IV = initializationVector;
		
		var cryptoTransform = aesCryptoServiceProvider.CreateDecryptor();
		
		using(var memoryStream = new MemoryStream())
		using(var cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
		{
			cryptoStream.Write(item, 0, item.Length);
			cryptoStream.FlushFinalBlock();
			return memoryStream.ToArray();
		}
	}
}

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

[Serializable]
public class Person
{
	public Person(string name, int age)
	{
		this.Name = name;
		this.Age = age;
	}
	
	public string Name {get; set;}
	public int Age {get; set;}
}

    internal static class BytesConverter
    {
        internal static byte[] ToBytes(this object value)
        {
            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, value);
                return memoryStream.ToArray();
            }
        }

        internal static object ToObject(this byte[] bytes)
        {
            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                memoryStream.Write(bytes, 0, bytes.Length);
                memoryStream.Seek(0, SeekOrigin.Begin);
                var value = binaryFormatter.Deserialize(memoryStream);
                return value;
            }
        }
    }