using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

string input = @"0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";

var strLines = input.Split("\n");
var lines = new Line[strLines.Length];

int smallesX = int.MaxValue;
int smallesY = int.MaxValue;
int biggestX = int.MinValue;
int biggestY = int.MinValue;

for(int i = 0; i < strLines.Length; i++)
{
    var split1 = strLines[i].Split(" -> ");
    var split2 = split1[0].Split(",");
    var split3 = split1[1].Split(",");

    var line = new Line(int.Parse(split2[0]), int.Parse(split2[1]), int.Parse(split3[0]), int.Parse(split3[1]));
    lines[i] = line;

    smallesX = Math.Min(smallesX, Math.Min(line.x1, line.x2));
    smallesY = Math.Min(smallesY, Math.Min(line.y1, line.y2));
    biggestX = Math.Max(biggestX, Math.Max(line.x1, line.x2));
    biggestY = Math.Max(biggestY, Math.Max(line.y1, line.y2));
}

int[,] grid = new int[biggestX - smallesX + 1, biggestY - smallesY + 1];

foreach(var line in lines)
{
    if(line.x1 != line.x2 && line.y1 != line.y2) continue;

    int x = line.x1, y = line.y1;
    for(int i = 0; i <= Math.Max(Math.Abs(line.x2 - line.x1), Math.Abs(line.y2 - line.y1)); i++)
    {
        grid[x - smallesX, y - smallesY]++;

        x += Math.Sign(line.x2 - line.x1);
        y += Math.Sign(line.y2 - line.y1);
    }
}

int sum = 0;
for(var i = 0; i < grid.GetLength(0); i++)
{
    for(var j = 0; j < grid.GetLength(1); j++)
    {
        if(grid[i,j] > 1)
            sum++;
    }
}
Console.WriteLine(sum);

record Line(int x1, int y1, int x2, int y2);
