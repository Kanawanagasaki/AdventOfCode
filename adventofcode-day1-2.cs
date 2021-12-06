using System;
using System.Linq;

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

int res = 0;
int last = int.MaxValue;

var data = input.Split('\n').Where(line=>int.TryParse(line, out int num)).Select(num=>int.Parse(num)).ToArray();
for(int i = 0; i < data.Length - 2; i++)
{
    int sum = 0;
    for(int j = 0; j < 3; j++)
        sum += data[i + j];
    if(sum > last)
        res++;
    last = sum;
}
Console.WriteLine(res);