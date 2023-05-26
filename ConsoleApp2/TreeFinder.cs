using System;

class TreeFinder
{
    public string Data { get; set; }
    public int AvailableTrees { get; set; }
    public string[,] Trees { get; set; }

    public TreeFinder(string data)
    {
        Data = data;
        Trees = new string[GetArrayLength(Data), GetArrayLength(Data)];
    }

    // fill array with zeroes
    public void FillArrayWithZeroes()
    {
        // foreach trees element and fill with zeroes
        for (int row = 0; row < Trees.GetLength(0); row++)
        {
            for (int column = 0; column < Trees.GetLength(1); column++)
            {
                // fill array with zeroes
                Trees[row, column] = "0";
            }
        }
    }

    // get array length (square root of data length)
    public int GetArrayLength(string data) => (int) Math.Round(Math.Sqrt(data.Length));

    // make visible some text
    public void MakeVisible(string visibleText)
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Write(visibleText);
        Console.BackgroundColor = ConsoleColor.Black;
    }

    // load trees from data
    public void LoadTrees()
    {
        // set count to zero
        int count = 0;

        // foreach trees element
        for (int row = 0; row < Trees.GetLength(0); row++)
        {
            for (int column = 0; column < Trees.GetLength(1); column++)
            {
                // if reached end of data 
                if (count == Data.Length)
                {
                    // end loop
                    break;
                }

                // set number from data to trees array
                Trees[row, column] = Data[count].ToString();
                count++;
            }
        }
    }

    // write trees to console
    public void WriteTrees()
    {
        // foreach trees element
        for (int row = 0; row < Trees.GetLength(0); row++)
        {
            for (int column = 0; column < Trees.GetLength(1); column++)
            {
                // if visible - make visible
                if (IsVisible(row, column))
                {
                    MakeVisible(Trees[row, column]);
                }
                else // else - just write
                {
                    Console.Write(Trees[row, column]);
                }
            }

            Console.WriteLine();
        }
    }

    // check previous columns (in left)
    public bool CheckLowestInLeft(int row, int column, int current)
    {
        bool isLowestInLeft = true;

        // previous columns check
        if (column != 0) // check if not first column
        {
            for (int i = column - 1; i >= 0; i--) // all previous columns
            {
                if (int.Parse(Trees[row, i]) >= current) // if any previous column is bigger or equal - not visible
                {
                    isLowestInLeft = false;
                    break; // end loop if not visible
                }
            }
        }

        return isLowestInLeft;
    }

    // check next columns (in right)
    public bool CheckLowestInRight(int row, int column, int current)
    {
        bool isLowestInRight = true;

        // next columns check
        if (column != Trees.GetLength(1)) // check if not last column
        {
            for (int i = column + 1; i < Trees.GetLength(1); i++) // all next columns
            {
                if (int.Parse(Trees[row, i]) >= current) // if any next column is bigger or equal - not visible
                {
                    isLowestInRight = false;
                    break; // end loop if not visible
                }
            }
        }

        return isLowestInRight;
    }

    // check previous rows (in top)
    public bool CheckLowestInTop(int row, int column, int current)
    {
        bool isLowestInTop = true;

        // previous rows check
        if (row != 0)
        {
            for (int i = row - 1; i >= 0; i--) // all previous rows
            {
                if (int.Parse(Trees[i, column]) >= current) // if any previous row is bigger or equal - not visible
                {
                    isLowestInTop = false;
                    break; // end loop if not visible
                }
            }
        }

        return isLowestInTop;
    }

    // check next rows (in bottom)
    public bool CheckLowestInBottom(int row, int column, int current)
    {
        bool isLowestInBottom = true;

        // next rows check
        if (row != 0)
        {
            for (int i = row + 1; i < Trees.GetLength(0); i++) // all next rows
            {
                if (int.Parse(Trees[i, column]) >= current) // if any next row is bigger or equal - not visible
                {
                    isLowestInBottom = false;
                    break; // end loop if not visible
                }
            }
        }

        return isLowestInBottom;
    }

    public bool IsVisible(int row, int column)
    {
        // get current number
        int current = int.Parse(Trees[row, column]);

        // check if lowest in left, right, top, bottom
        
        
        bool isLowestInLeft = CheckLowestInLeft(row, column, current);

        // if lowest in left - visible
        if (isLowestInLeft)
        {
            AvailableTrees++;
            return true;
        }
        
        bool isLowestInRight = CheckLowestInRight(row, column, current);
        
        // if lowest in right - visible
        if (isLowestInRight)
        {
            AvailableTrees++;
            return true;
        }
        
        bool isLowestInTop = CheckLowestInTop(row, column, current);
        
        // if lowest in top - visible
        if (isLowestInTop)
        {
            AvailableTrees++;
            return true;
        }
        
        bool isLowestInBottom = CheckLowestInBottom(row, column, current);
        
        // if lowest in bottom - visible
        if (isLowestInBottom)
        {
            AvailableTrees++;
            return true;
        }

        // if not lowest in left, right, top, bottom - not visible
        return false;
    }
}