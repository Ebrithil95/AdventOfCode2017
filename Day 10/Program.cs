using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day_10
{
	class Program
	{
		const int LIST_SIZE = 256;

		static void Main(string[] args)
		{
			try
			{
				List<int> lengths;
				using (StreamReader sr = new StreamReader("input.txt"))
				{
					string line = sr.ReadLine();
					lengths = line.Split(',').Select(Int32.Parse).ToList();
				}

				List<int> numbers = new List<int>();
				for (int i = 0; i < LIST_SIZE; ++i) numbers.Add(i);

				int currentPos = 0;
				int skipSize = 0;

				foreach (var length in lengths)
				{
					if (currentPos + length >= numbers.Count)
					{
						int remainder = (currentPos + length) % numbers.Count;
						List<int> temp = new List<int>();
						temp.AddRange(numbers.GetRange(currentPos, length - remainder));
						temp.AddRange(numbers.GetRange(0, remainder));
						temp.Reverse();
						for (int i = currentPos; i < currentPos + length; ++i)
						{
							numbers[i % numbers.Count] = temp[i - currentPos];
						}
					}
					else
					{
						numbers.Reverse(currentPos, length);
					}

					currentPos = (currentPos + length + skipSize++) % numbers.Count;
				}
				Console.WriteLine(numbers[0] * numbers[1]);
			}
			catch (Exception e) { }
		}
	}
}
