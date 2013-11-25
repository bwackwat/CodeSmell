using System;
using System.IO;

namespace CodeSmell
{
	public class Program
	{
		//Use 'fsutil behavior set disablelastaccess 0' in the windows command line (Win + R, cmd, Enter) to enable last access dates. Restart computer.

		private static readonly string[] Files = Directory.GetFiles("C:\\Users\\john.paul.hayes\\Desktop\\", "*",
			SearchOption.AllDirectories);

		private static void Main(string[] args)
		{
			for (int i = 0; i < Files.Length; i++)
			{
				Console.SetCursorPosition(0, Console.BufferHeight - 3);
				Console.WriteLine(File.GetLastAccessTime(Files[i]) + ":" + Files[i]);

				Console.WriteLine();

				Console.SetCursorPosition(0, Console.BufferHeight - 1);
				PrintProgress(i);
			}

			Console.Read();
		}

		private static void PrintProgress(int i)
		{
			double ratio = (double) i/Files.Length;
			Console.Write("Progress: {0} [", ratio*100);

			int plen = 60;

			for (int d = 0; d < plen; d++)
			{
				if (d < ratio*plen)
				{
					Console.Write("|");
				}
				else
				{
					Console.Write(" ");
				}
			}

			Console.WriteLine("]");
		}
	}
}