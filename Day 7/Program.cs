using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Day_7
{
    class Program
    {

        private static readonly Regex regex = new Regex(@"([a-z]+) \(([\d]+)\)(?: -> ([a-z, ]+))?");
        private static Disk root = new Disk();

        static void Main(string[] args)
        {
            try {
                using (StreamReader sr = new StreamReader("input.txt")) {
                   while (!sr.EndOfStream) {
                       var line = sr.ReadLine();

                       var match = regex.Match(line);
                       if (match.Success) {
                           var name = match.Groups[1].Value;
                           var weight = int.Parse(match.Groups[2].Value);
                           var nextDisks = match.Groups[3].Value.Split(new char[]{' ',','}, StringSplitOptions.RemoveEmptyEntries);
                       }
                   }
                }
            }
            catch (Exception e) {}
        }
    }
}
