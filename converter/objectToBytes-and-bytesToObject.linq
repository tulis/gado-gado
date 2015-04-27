<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Namespace>System.Runtime.Serialization.Formatters.Binary</Namespace>
</Query>

void Main()
{
	IFooBar foo = new Foo();
	IFooBar bar = new Bar();
	
	var serializedFoo = foo.ToBytes();
	var serializedBar = bar.ToBytes();
	
	var deserializedFoo = serializedFoo.ToObject();
	var deserializedBar = serializedBar.ToObject();
	
	(deserializedFoo is Foo).Dump();
	(deserializedBar is Bar).Dump();
	(deserializedFoo is IFooBar).Dump();
	
	(deserializedFoo is Bar).Dump();
	(deserializedBar is Foo).Dump();
}

// Define other methods and classes here

interface IFooBar
{
	void FooBar();
}

[Serializable()]
class Foo : IFooBar
{
	public void FooBar()
	{
		"Foo".Dump();
	}
}

[Serializable()]
class Bar : IFooBar
{
	public void FooBar()
	{
		"Bar".Dump();
	}
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