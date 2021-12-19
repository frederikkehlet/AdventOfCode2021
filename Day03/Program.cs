string inputFilePath = @".\input.txt";
List<string> lines = System.IO.File.ReadAllLines(inputFilePath).ToList();

// part 1
string gammaRate = "";
string epsilonRate = "";

int positions = lines[0].Length;
for (int i = 0; i < positions; i++) 
{
    int zeroCount = 0;
    int oneCount = 0;
    foreach (string line in lines) 
    {
        if (line[i] == '0') zeroCount += 1;
        else oneCount += 1;
    }
    
    if (oneCount > zeroCount) 
    {
        gammaRate += '1';
        epsilonRate += '0';
    } 
    else
    {
        gammaRate += '0';
        epsilonRate += '1';
    }
}

int gammaRateDec, epsilonRateDec = 0;
gammaRateDec = Convert.ToInt32(gammaRate,2);
epsilonRateDec = Convert.ToInt32(epsilonRate,2);

Console.WriteLine($"Part 1 answer: {gammaRateDec * epsilonRateDec}");

// part 2
for (int i = 0; i < positions; i++) 
{
    if (lines.Count == 1) break;

    int zeroCount = 0;
    int oneCount = 0;

    foreach (string line in lines) 
    {
        if (line[i] == '0') zeroCount += 1;
        else oneCount += 1;
    }
    
    // keep lines with 1 at current position
    if (oneCount >= zeroCount) 
    {
        List<string> filteredLines = lines.Where(line => line[i] == '1').ToList();
        lines = filteredLines;
    }
    else 
    {
        List<string> filteredLines = lines.Where(line => line[i] == '0').ToList();
        lines = filteredLines;
    }
}

string oxygenGeneratorRating = lines[0];
lines = System.IO.File.ReadAllLines(inputFilePath).ToList();

for (int i = 0; i < positions; i++) 
{
    if (lines.Count == 1) break;

    int zeroCount = 0;
    int oneCount = 0;

    foreach (string line in lines) 
    {
        if (line[i] == '0') zeroCount += 1;
        else oneCount += 1;
    }
    
    // keep lines with 0 at current position
    if (oneCount >= zeroCount) 
    {
        List<string> filteredLines = lines.Where(line => line[i] == '0').ToList();
        lines = filteredLines;
    }
    else 
    {
        List<string> filteredLines = lines.Where(line => line[i] == '1').ToList();
        lines = filteredLines;
    }
}

string scrubberRating = lines[0];

Console.WriteLine($"Part 2 answer: {Convert.ToInt32(oxygenGeneratorRating, 2) * Convert.ToInt32(scrubberRating, 2)}");
