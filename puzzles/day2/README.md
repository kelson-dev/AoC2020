# Day 2, Passwords
https://adventofcode.com/2020/day/2

## Part 1:
From a list of passwords and their policies, determine how many passwords are valid

The input contains a list of policy password pairs. 
A policy is in the form `{MIN}-{MAX} {LETTER}:` and specifies
how many times {LETTER} must occur in the password following the `:` for
the password to be valid.

## Part 2:



## Running the C# solutions

[Install .NET 5.0 sdk](https://dotnet.microsoft.com/download/dotnet/5.0)

Use `dotnet run` in the directory containing the `.csproj` file and pipe your puzzle input into STDIN, such as:
> `dotnet run < day1.input`

## Running the Rust solutions

[Install rust](https://www.rust-lang.org/tools/install)

Use `cargo run` in the directory containing the `Cargo.toml` file and pipe your puzzle input to STDIN, such as:
> `cargo run < day1.input`
