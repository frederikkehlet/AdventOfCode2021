using System.Text.RegularExpressions;

string inputFilePath = @".\input.txt";
List<string> lines = System.IO.File.ReadAllLines(inputFilePath).ToList();

// list of drawn numbers
List<string> drawnNumbers = lines[0].Split(",").ToList();

// list of all board numbers
var boardNumbers = System.IO.File.ReadAllText(inputFilePath).Split("\n")[2..];

// empty list to store boards as 2D arrays
List<string[,]> boards = new();

// creates a board and adds to list
for (int i = 0; i < boardNumbers.Length - 4; i += 6) 
{
    var ranges = boardNumbers[(i)..(i+5)];
    string[,] board = new string[5,5];

    for (int j = 0; j < 5; j++) 
    {
        // split range into numbers
        string[] numbers = Regex.Split(Convert.ToString(ranges[j]).Trim(), @"\D+");

        for(int k = 0; k < numbers.Length; k++)        
            // assign numbers to corresponding row and column
            board[j,k] = numbers[k];
        
    }
    boards.Add(board);
}

// plays bingo
foreach (string drawnNumber in drawnNumbers) 
{
    foreach(string[,] board in boards) 
    {
        MarkNumberOnBoard(board, drawnNumber);
        if (HasCompleteRowOrColumn(board))
        {
            Console.WriteLine("Winner!");
            PrintBoard(board);
            Console.WriteLine($"Score: {CalculateScore(board, drawnNumber)}");
            return;
        }
    }
}

// method for printing out single board
void PrintBoard(string[,] board)
{
    for (int i = 0; i < board.GetLength(0); i++)
    {
        for (int j = 0; j < board.GetLength(1); j++)        
            Console.Write(board[i,j] + "\t");
        
        Console.WriteLine();
    }
}

// method for marking the drawn number on a board
void MarkNumberOnBoard(string[,] board, string number)
{
    for (int i = 0; i < board.GetLength(0); i++)    
        for (int j = 0; j < board.GetLength(1); j++)        
            if (board[i,j] == number) board[i,j] = "X";   
}

// method for checking if a row or column in a board is complete
bool HasCompleteRowOrColumn(string[,] board)
{
    int numbersMarkedPerRow = 0;

    // check by row
    for (int i = 0; i < board.GetLength(0); i++)
    {
        for (int j = 0; j < board.GetLength(1); j++)
            if (board[i,j] == "X") numbersMarkedPerRow++;   
        
        if (numbersMarkedPerRow == 5) return true;
        else numbersMarkedPerRow = 0; // reset counter
    }

    int numbersMarkedPerColumn = 0;

    // check by column
    for (int i = 0; i < board.GetLength(0); i++)
    {
        for (int j = 0; j < board.GetLength(1); j++)        
            if (board[j,i] == "X") numbersMarkedPerColumn++;
        
        if (numbersMarkedPerColumn == 5) return true;
        else numbersMarkedPerColumn = 0; // reset counter
    }

    return false; // if we exhaust all rows and columns, the board has not yet won
}

int CalculateScore(string[,] board, string number)
{
    int score = 0;

    for (int i = 0; i < board.GetLength(0); i++)
        for (int j = 0; j < board.GetLength(1); j++)
           if (board[i,j] != "X") score += Convert.ToInt32(board[i,j]);
        
    return score * Convert.ToInt32(number);
}

