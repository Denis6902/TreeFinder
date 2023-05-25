using System;

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
        for (int row = 0; row < Map.GetLength(0); row++)
        {
            for (int column = 0; column < Map.GetLength(1); column++)
            {
                // fill array with zeroes
                Map[row, column] = "0";
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
        for (int row = 0; row < Map.GetLength(0); row++)
        {
            for (int column = 0; column < Map.GetLength(1); column++)
            {
                // if not reached end of data 
                if (count != Data.Length)
                {
                    // set number from data to map array
                    Map[row, column] = Data[count].ToString();
                    count++;
                }
            }
        }
    }

    // write map
    public void WriteMap()
    {
        for (int row = 0; row < Map.GetLength(0); row++)
        {
            for (int column = 0; column < Map.GetLength(1); column++)
            {
                // if visible - make visible
                if (IsVisible(row, column))
                {
                    MakeVisible(Map[row, column]);
                }
                else // else - just write
                {
                    Console.Write(Map[row, column]);
                }
            }

            Console.WriteLine();
        }
    }

    // check previous columns
    public bool CheckLowestInLeft(int row, int column, int current)
    {
        bool isLowestInLeft = true;

        // previous columns check
        if (column != 0) // check if not first column
        {
            for (int i = column - 1; i >= 0; i--) // all previous columns
            {
                if (int.Parse(Map[row, i]) >= current) // if previous column is bigger or equal - not visible
                {
                    isLowestInLeft = false;
                }
            }
        }
        else
        {
            isLowestInLeft = true; // if is first column - visible
        }

        return isLowestInLeft;
    }

    public bool CheckLowestInTopRight(int row, int column, int current)
    {
        bool isLowestInRight = true;

        // next columns check
        if (column != Map.GetLength(1)) // check if not last column
        {
            for (int i = column + 1; i < Map.GetLength(1); i++) // all next columns
            {
                if (int.Parse(Map[row, i]) >= current) // if next column is bigger or equal - not visible
                {
                    isLowestInRight = false;
                }
            }
        }
        else
        {
            isLowestInRight = true; // if is last column - visible
        }

        return isLowestInRight;
    }

    public bool CheckLowestInTop(int row, int column, int current)
    {
        bool isLowestInTop = true;

        // previous rows check
        if (row != 0)
        {
            for (int i = row - 1; i >= 0; i--) // all previous rows
            {
                if (int.Parse(Map[i, column]) >= current) // if previous row is bigger or equal - not visible
                {
                    isLowestInTop = false;
                }
            }
        }
        else
        {
            isLowestInTop = true; // if is first column - visible
        }

        return isLowestInTop;
    }

    public bool CheckLowestInBottom(int row, int column, int current)
    {
        bool isLowestInBottom = true;

        // next rows check
        if (row != 0)
        {
            for (int i = row + 1; i < Map.GetLength(0); i++) // all next rows
            {
                if (int.Parse(Map[i, column]) >= current) // if next row is bigger or equal - not visible
                {
                    isLowestInBottom = false;
                }
            }
        }
        else
        {
            isLowestInBottom = true; // if is last column - visible
        }

        return isLowestInBottom;
    }

    public bool IsVisible(int row, int column)
    {
        // get current number
        int current = int.Parse(Map[row, column]);

        bool isLowestInLeft = CheckLowestInLeft(row, column, current);
        bool isLowestInRight = CheckLowestInTopRight(row, column, current);
        bool isLowestInTop = CheckLowestInTop(row, column, current);
        bool isLowestInBottom = CheckLowestInBottom(row, column, current);


        bool isAvailable = isLowestInLeft || isLowestInRight || isLowestInTop || isLowestInBottom;

        // if available - increment available trees
        if (isAvailable)
        {
            AvailableTrees++;
        }

        return isAvailable;
    }
}