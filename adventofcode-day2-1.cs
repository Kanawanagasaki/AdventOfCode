using System;
using System.Linq;

var input = @"forward 5
down 5
forward 8
up 3
down 8
forward 2";

int hor = 0;
int vert = 0;

foreach(var line in input.Split("\n"))
{
    var words = line.Split(" ");
    int num = int.Parse(words[1]);
    if(words[0] == "forward")
        hor += num;
    else if(words[0] == "down")
        vert += num;
    else if(words[0] == "up")
        vert -= num;
}

Console.WriteLine(hor * vert);