use std::fs::File;
use std::io::prelude::*;

fn get_input() -> String {
    let filename = "input.txt";
    let mut file = File::open(filename).expect("file not found");

    let mut contents = String::new();
    file.read_to_string(&mut contents).expect("something went wrong reading the file");

    contents
}

fn get_distance (pos: (i32, i32)) -> i32 {
    let x = if pos.0 < 0 { pos.0 * -1 } else {pos.0};
    let y = if pos.1 < 0 { pos.1 * -1 } else {pos.1};
    let z = -1 * (pos.0 + pos.1);

    i32::max(i32::max(x, y), z)
}

fn main() {
    let input = get_input();
    let x = input.split(",");

    let mut current_pos : (i32, i32) = (0, 0);
    let mut max_dist = 0;

    for elem in x {
        let temp =
            if elem == "n" {
                (0, -1)
            } else if elem == "ne" {
                (1, -1)
            } else if elem == "nw" {
                (-1, 0)
            } else if elem == "s" {
                (0, 1)
            } else if elem == "se" {
                (1, 0)
            } else if elem == "sw" {
                (-1, 1)
            } else {
                (0, 0)
            };

        current_pos = (current_pos.0 + temp.0, current_pos.1 + temp.1);
        let current_dist = get_distance(current_pos);
        if current_dist > max_dist {
            max_dist = current_dist;
        }
    }

    println!("Distance: {}", get_distance(current_pos));
    println!("Max Distance: {}", max_dist);
}
