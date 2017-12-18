using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace Day_7
{
    class Program
    {

        private static readonly Regex regex = new Regex(@"([a-z]+) \(([\d]+)\)(?: -> ([a-z, ]+))?");
        private static Disk root = new Disk();
        private static List<Disk> disks = new List<Disk>();
        private static Dictionary<string, Disk> dict = new Dictionary<string, Disk>();

        static void Main(string[] args)
        {
            try
            {
                using (StreamReader sr = new StreamReader("input.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();

                        var match = regex.Match(line);
                        if (match.Success)
                        {
                            var name = match.Groups[1].Value;
                            var weight = int.Parse(match.Groups[2].Value);
                            var nextDisks = match.Groups[3].Value.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                            disks.Add(new Disk(name, weight, new List<string>(nextDisks)));
                        }
                    }
                    disks.ForEach(e =>
                    {
                        dict.Add(e.Name, e);
                    });
                    root = disks[0];

                    for (int i = disks.Count - 1; i >= 0; i--)
                    {
                        var disk = disks[i];
                        if (disk.nextDisksString.Count > 0)
                        {
                            disk.nextDisksString.ForEach(e =>
                            {
                                dict[e].parent = disk;
                                disk.nextDisks.Add(dict[e]);
                            });
                        }

                        disks.Remove(disk);
                    }

                    root = root.getRoot();
                    
                    Console.WriteLine(root.Name);
                }
            }
            catch (Exception e) { }
        }
    }
}
