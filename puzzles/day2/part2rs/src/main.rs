use std::io::{self, BufRead};

macro_rules! to_num {
    ($input:expr) => {
        $input.parse::<usize>().unwrap()
    };
}

struct ProblemState {
    valid_passwords : u32
}

fn eval(state : &mut ProblemState, text : String) {
    let dash = text.find('-').unwrap();
    let space = text.find(' ').unwrap();
    let colon = text.find(':').unwrap();
    let first = to_num!(text[..dash]);
    let second = to_num!(text[dash+1..space]);
    let letter = text.chars().nth(space+1).unwrap();
    let first_is_lett = text[colon+2..].chars().nth(first - 1).unwrap() == letter;
    let second_is_lett = text[colon+2..].chars().nth(second - 1).unwrap() == letter;
    if first_is_lett ^ second_is_lett {
        state.valid_passwords += 1;
    }
}

fn main() {
    let stdin = io::stdin();
    let mut state = ProblemState { valid_passwords: 0 };
    for line in stdin.lock().lines() {
        let text = line.unwrap();
        eval(&mut state, text);
    }
    println!("{}", state.valid_passwords);
}
