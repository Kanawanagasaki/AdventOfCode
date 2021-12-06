const input = 
[
    "00100",
    "11110",
    "10110",
    "10111",
    "10101",
    "01111",
    "00111",
    "11100",
    "10000",
    "11001",
    "00010",
    "01010"
];

function calculate(reverse)
{
    let offset = 0;
    let indexes = new Array(input.length).fill(0).map((_,i)=>i);
    while(indexes.length > 1)
    {
        let sum = 0;
        for(let i of indexes)
            if(input[i][offset] == "1")
                sum++;
        
        let res = indexes.length / 2 <= sum;
        if(reverse) res = !res;
        
        for(let i = 0; i < indexes.length; i++)
        {
            if(input[indexes[i]][offset] == (res ? "0" : "1"))
            {
                indexes.splice(i,1);
                i--;
            }
        }

        offset++;
    }
    
    return parseInt(input[indexes[0]], 2);
}

const gamma = calculate(false);
const epsilon = calculate(true);

console.log(gamma * epsilon);
