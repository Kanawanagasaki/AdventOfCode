using System;

var input = @"199
200
208
210
200
207
240
269
260
263";

int last = int.MaxValue;
int res = 0;

foreach(var line in input.Split('\n'))
    if(int.TryParse(line, out int num))
    {
        if(num > last)
            res++;
        last = num;
    }

Console.WriteLine(res);