<Query Kind="Program">
  <Namespace>System.ComponentModel</Namespace>
</Query>

void Main()
{
	Helper.ToEnumDescriptions<Days>().Dump();
	Helper.ToEnumNames<Days>().Dump();
}

// Define other methods and classes here
public enum Days
{
	Monday = 0,
	Tuesday,
	Wednesday,
	Thursday,
	Friday,
	Saturday,
	Sunday
}

public static class Helper
{
	public static string GetEnumDescriptionAttributeValues(Enum value)
	{
		var fi = value.GetType().GetField(value.ToString());
		
		var attributes =
			(DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
		
		return attributes.Length > 0 ? attributes[0].Description : value.ToString();
	}
	
	public static IEnumerable<string> ToEnumDescriptions<TEnum>()
		where TEnum : struct, IConvertible, IComparable, IFormattable
	{
		Type type = typeof (TEnum);
		if (!type.IsEnum)
		{
		    throw new ArgumentException("Type must be Enum");
		}
				
		return Enum.GetValues(typeof (TEnum))
			.Cast<Enum>()
			.Select(day => GetEnumDescriptionAttributeValues(day))
			.ToList();		
	}
	
	public static IEnumerable<string> ToEnumNames<TEnum>()
		where TEnum : struct, IConvertible, IComparable, IFormattable
	{
		Type type = typeof (TEnum);
		if (!type.IsEnum)
		{
		    throw new ArgumentException("Type must be Enum");
		}
				
		return Enum.GetValues(typeof (TEnum))
			.Cast<Enum>()
			.Select(tEnum => tEnum.ToString())
			.ToList();		
	}
}