using System;

var input = @"forward 5
down 5
forward 8
up 3
down 8
forward 2";

int pos = 0;
int aim = 0;
int depth = 0;

foreach(var line in input.Split("\n"))
{
    var args2 = line.Split(" ");
    int num = int.Parse(args2[1]);
    switch(args2[0])
    {
        case "down": aim+=num; break;
        case "up": aim-=num; break;
        case "forward":
            pos += num;
            depth += aim * num;
            break;
    }
}

Console.WriteLine(pos * depth);
