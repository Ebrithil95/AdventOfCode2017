use std::fs::File;
use std::io::prelude::*;

fn main() {
    let filename = "input.txt";
    let mut file = File::open(filename).expect("file not found");

    let mut contents = String::new();
    file.read_to_string(&mut contents).expect("something went wrong reading the file");

    let lines: Vec<&str> = contents.split("\n").collect();
    for line in lines {
        let components: Vec<&str> = line.split(" <-> ").collect();
        let program_id = components.get(0).unwrap().parse::<u32>();

        let connections: Vec<u32> = components.get(1).unwrap().split(", ").filter_map(|e| e.parse().ok()).collect();

        for t in connections {
            println!("{}", t);
        }
    }
}