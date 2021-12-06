using System;
using System.Linq;
using System.Diagnostics;

var input = @"7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1

22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19

 3 15  0  2 22
 9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6

14 21 17 24  4
10 16 15  9 19
18  8 23 26 20
22 11 13  6  5
 2  0 12  3  7";

var lines = input.Split("\n");
var numbers = lines[0].Split(",").Select(num=>int.Parse(num));

int numberOfBoards = (lines.Length - 1) / 6;

int?[][,] boards = new int?[numberOfBoards][,];

for(int i = 0; i < numberOfBoards; i++)
{
    boards[i] = new int?[5, 5];
    for(int j = 0; j < 5; j++)
    {
        var nums = lines[6 * i + j + 2].Replace("  ", " ").Trim().Split(" ").Select(num=>int.Parse(num)).ToArray();
        for(int k = 0; k < 5; k++)
        {
            boards[i][j,k] = nums[k];
        }
    }
}

foreach(var num in numbers)
{
    for(int i = 0; i < numberOfBoards; i++)
    {
        for(int j = 0; j < 5; j++)
        {
            for(int k = 0; k < 5; k++)
            {
                if(boards[i][j,k] == num)
                    boards[i][j,k] = null;
            }
        }
    }

    for(int i = 0; i < numberOfBoards; i++)
    {
        bool flag = false;
        for(int j = 0; j < 5; j++)
        {
            int rowSum = 0;
            int columnSum = 0;
            for(int k = 0; k < 5; k++)
            {
                if(boards[i][j,k] is null)
                    rowSum++;
                if(boards[i][k, j] is null)
                    columnSum++;
            }
            if(rowSum == 5) flag = true;
            if(columnSum == 5) flag = true;
        }

        if(flag)
        {
            int sum = 0;

            for(int j = 0; j < 5; j++)
            {
                for(int k = 0; k < 5; k++)
                {
                    if(boards[i][j,k] is not null)
                        sum += boards[i][j,k].Value;
                }
            }

            Console.WriteLine(sum * num);

            return;
        }
    }
}
