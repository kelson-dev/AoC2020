use std::collections::BTreeSet;
use std::io::{self, BufRead};

fn main() {
    let mut numbers: BTreeSet<u32> = BTreeSet::new();
    let stdin = io::stdin();
    for line in stdin.lock().lines() {
        let number = line.unwrap().parse::<u32>().unwrap();
        for previous in &numbers {
            if number + previous < 2020 {
                let solution = 2020 - number - previous;
                if numbers.contains(&solution) {
                    println!("{}", solution * number * previous);
                    return;
                }
            }
        }
        numbers.insert(number);
    }
}