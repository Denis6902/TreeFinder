class TreeFinder
{
    public string Data { get; set; }
    public int AvailableTrees { get; set; }
    public string[,] Map { get; set; }

    public TreeFinder(string data)
    {
        Data = data;
        Map = new string[GetArrayLength(Data), GetArrayLength(Data)];
    }

    // fill array with zeroes
    public void FillArrayWithZeroes()
    {
        for (int i = 0; i < Map.GetLength(0); i++)
        {
            for (int j = 0; j < Map.GetLength(1); j++)
            {
                // fill array with zeroes
                Map[i, j] = "0";
            }
        }
    }

    // get array length
    public int GetArrayLength(string data) => (int) Math.Round(Math.Sqrt(data.Length));

    // make visible some text
    public void MakeVisible(string visibleText)
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Write(visibleText);
        Console.BackgroundColor = ConsoleColor.Black;
    }

    // load map
    public void LoadMap()
    {
        // set count to zero
        int count = 0;

        // foreach map element
        for (int i = 0; i < Map.GetLength(0); i++)
        {
            for (int j = 0; j < Map.GetLength(1); j++)
            {
                // if not reached end of data 
                if (count != Data.Length)
                {
                    // set number from data to map array
                    Map[i, j] = Data[count].ToString();
                    count++;
                }
            }
        }
    }

    // write map
    public void WriteMap()
    {
        for (int i = 0; i < Map.GetLength(0); i++)
        {
            for (int j = 0; j < Map.GetLength(1); j++)
            {
                // if visible - make visible
                if (IsVisible(i, j))
                {
                    MakeVisible(Map[i, j]);
                }
                else // else - just write
                {
                    Console.Write(Map[i, j]);
                }
            }

            Console.WriteLine();
        }
    }

    // check if is visible
    public bool IsVisible(int i, int j)
    {
        // get current number
        int current = int.Parse(Map[i, j]);

        // get previous and next numbers
        int previousColumn = -1; // -1 because 0 is lowest valid number
        int previousRow = -1;
        int nextColumn = -1;
        int nextRow = -1;

        // previous column
        if (j != 0) // check if not first column
        {
            previousColumn = int.Parse(Map[i, j - 1]);
        }

        // previous row
        if (i != 0) // check if not first row
        {
            previousRow = int.Parse(Map[i - 1, j]);
        }

        // next column
        if (j < Map.GetLength(1) - 1) // check if not last column
        {
            nextColumn = int.Parse(Map[i, j + 1]);
        }

        // next row
        if (i < Map.GetLength(0) - 1) // check if not last row
        {
            nextRow = int.Parse(Map[i + 1, j]);
        }

        // if current number is bigger than previous or next - make visible
        bool isAvailable = previousColumn < current || previousRow < current || nextColumn < current ||
                           nextRow < current;

        // if available - increment available trees
        if (isAvailable)
        {
            AvailableTrees++;
        }

        // return is available
        return isAvailable;
    }
}