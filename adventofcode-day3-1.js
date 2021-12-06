const input = 
[
    0b00100,
    0b11110,
    0b10110,
    0b10111,
    0b10101,
    0b01111,
    0b00111,
    0b11100,
    0b10000,
    0b11001,
    0b00010,
    0b01010
];

let arr = [];
for(let i of input)
{
    for(let j = 0; 1 << j <= i; j++)
    {
        if(arr.length <= j) arr.push(0);
        arr[j] += i >> j & 1;
    }
}

let gamma = 0;
let epsilon = 0;

for(let i in arr)
{
    if(arr[i] > input.length/2)
        gamma |= 1 << i;
    else epsilon |= 1 << i;
}

console.log(gamma * epsilon);

