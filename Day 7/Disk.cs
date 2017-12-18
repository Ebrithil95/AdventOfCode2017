using System.Collections.Generic;

namespace Day_7 {
    class Disk {
        private string Name;
        private int weight;
        private List<Disk> nextDisks;

        public Disk(string name, int weight) {
            this.Name = name;
            this.weight = weight;
            this.nextDisks = new List<Disk>();
        }

        public Disk() : this(null, 0) {
        }
    }
}