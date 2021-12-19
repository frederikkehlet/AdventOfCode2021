string inputFilePath = @".\input.txt";
string[] numbers = System.IO.File.ReadAllLines(inputFilePath);

// part 1
int count = 0;
for (int i = 1; i < numbers.Length; i++) 
{
    if (Convert.ToInt32(numbers[i]) > Convert.ToInt32(numbers[i-1])) count++;
}
Console.WriteLine($"Part 1 answer: {count}");

// part 2
count = 0;
for (int i = 1; i < numbers.Length - 2; i++) 
{
    int previousWindowSum = 0;
    int currentWindowSum = 0;
    
    string[] previousWindow = numbers[(i-1)..((i-1) + 3)]; // the last index is non-inclusive
    string[] currentWindow = numbers[i..(i+3)];

    foreach (var num in previousWindow) previousWindowSum += Convert.ToInt32(num);
    foreach (var num in currentWindow) currentWindowSum += Convert.ToInt32(num);
    
    if (currentWindowSum > previousWindowSum) count++;
}
Console.WriteLine($"Part 2 answer: {count}");