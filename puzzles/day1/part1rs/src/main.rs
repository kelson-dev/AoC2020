use std::collections::BTreeSet;
use std::io::{self, BufRead};

fn main() {
    let mut numbers : BTreeSet<u32> = BTreeSet::new();
    let stdin = io::stdin();
    for line in stdin.lock().lines() {
        let number = line.unwrap().parse::<u32>().unwrap();
        let solution = 2020 - number;
        if numbers.contains(&solution) {
            println!("{}", solution * number);
            return;
        }
        else {
            numbers.insert(number);
        }
    }
}
