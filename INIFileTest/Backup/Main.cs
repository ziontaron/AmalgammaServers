// *** INIFile class test ***
using System;
using System.IO;
using System.Text;
using STA.Settings;

namespace INIFileTest
{
	class MainClass
	{
		private static string PrintByteArray(byte[] Value)
		{
			StringBuilder sb = new StringBuilder();
			if (Value != null)
			{
				if (Value.Length > 0)
				{
					sb.Append(Value[0].ToString());
					for (int i=1; i<Value.Length; i++)
					{
						sb.Append(", ");
						sb.Append(Value[i].ToString());
					}
				}
			}
			return sb.ToString();
		}

		public static void Main(string[] args)
		{
			StreamReader sr = null;
			try	
			{
				Console.WriteLine("Creating INIFile object for \"test.ini\"...");
			
				INIFile MyINIFile = new INIFile("test.ini");
			
				Console.WriteLine("\nGetting values...\n");

				int Value1 = MyINIFile.GetValue("Section1","Value1",0);
				bool Value2 = MyINIFile.GetValue("Section1","Value2",false);
				double Value3 = MyINIFile.GetValue("Section1","Value3",(double)0);
				byte[] Value4 = MyINIFile.GetValue("Section1","Value4",(byte[])null);

				Console.Write("(int) Value1=");
				Console.WriteLine(Value1.ToString());

				Console.Write("(bool) Value2=");
				Console.WriteLine(Value2.ToString());

				Console.Write("(double) Value3=");
				Console.WriteLine(Value3.ToString());

				Console.Write("(byte[]) Value4=");
				Console.WriteLine(PrintByteArray(Value4));

				Console.WriteLine("\nSetting values...\n");

				Value1++;
				Value2 = !Value2;
				Value3 += 0.75;
				Value4 = new byte[] { 10, 20, 30, 40 };
				
				MyINIFile.SetValue("Section1","Value1", Value1);
				MyINIFile.SetValue("Section1","Value2", Value2);
				MyINIFile.SetValue("Section1","Value3", Value3);
				MyINIFile.SetValue("Section1","Value4", Value4);

				Console.Write("(int) Value1=");
				Console.WriteLine(Value1.ToString());

				Console.Write("(bool) Value2=");
				Console.WriteLine(Value2.ToString());

				Console.Write("(double) Value3=");
				Console.WriteLine(Value3.ToString());

				Console.Write("(byte[]) Value4=");
				Console.WriteLine(PrintByteArray(Value4));

				Console.WriteLine("\nFlushing cache...");

				MyINIFile.Flush();
				
				Console.WriteLine("\nFile content:\n");
				
				sr = new StreamReader("test.ini");
				string s;
				while ((s=sr.ReadLine()) != null) Console.WriteLine(s);
				
				Console.WriteLine("\nDone.");
			}
			catch (Exception ex)
			{
				Console.Write("\n\nEXCEPTION: ");
				Console.WriteLine(ex.Message);
			}
			finally
			{
				if (sr != null) sr.Close();
				sr = null;
			}
		}
	}
}