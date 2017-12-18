using System.Collections.Generic;
using System;

namespace Day_7
{
    class Disk
    {
        public string Name;
        public int weight;
        public List<Disk> nextDisks;
        public List<string> nextDisksString;
        public Disk parent = null;

        public Disk(string name, int weight, List<string> list)
        {
            this.Name = name;
            this.weight = weight;
            this.nextDisks = new List<Disk>();
            this.nextDisksString = list;
        }

        public Disk() : this(null, 0, null)
        {
        }

        public Disk getRoot()
        {
            return parent != null ? parent.getRoot() : this;
        }

        public int getWeight()
        {
            var w = weight;
            foreach (var d in nextDisks)
            {
                w += d.getWeight();
            }

            return w;
        }

        public void checkWeight(int needed)
        {
            foreach (var disk in nextDisks)
            {
                var x = disk.getWeight();
                Console.WriteLine(x);
            }
        }
    }
}