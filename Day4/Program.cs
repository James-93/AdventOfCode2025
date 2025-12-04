
var input = File.ReadAllLines("input.txt");
var grid = new char[input[0].Length, input.Length];

for (var i = 0; i < input.Length; i++)
{
    for (var i2 = 0; i2 < input[i].Length; i2++)
    {
        grid[i,i2] = input[i][i2];
    }
}

Part1(grid);
Part2(grid);

void Part1(char[,] grid)
{
    long answer = 0;

    for (var i = 0; i < 138; i++)
    {
        for (var i2 = 0; i2 < 138; i2++)
        {
            if (grid[i, i2].Equals('@'))
            {
                var surroundingValues = new List<char>();

                if (i > 0) // Square above
                    surroundingValues.Add(grid[(i - 1), i2]);

                if (i < 137) // Square below
                    surroundingValues.Add(grid[(i + 1), i2]);

                if (i2 > 0) // Square left
                    surroundingValues.Add(grid[i, (i2 - 1)]);

                if (i2 < 137) // Square right
                    surroundingValues.Add(grid[i, (i2 + 1)]);

                if (i > 0 && i2 > 0) // Square above and left
                    surroundingValues.Add(grid[(i - 1), (i2 - 1)]);

                if (i > 0 && i2 < 137) // Square above and right
                    surroundingValues.Add(grid[(i - 1), (i2 + 1)]);

                if (i < 137 && i2 > 0) // Square below and left
                    surroundingValues.Add(grid[(i + 1), (i2 - 1)]);

                if (i < 137 && i2 < 137) // Square below and right
                    surroundingValues.Add(grid[(i + 1), (i2 + 1)]);

                if (surroundingValues.Where(x => x.Equals('@')).Count() < 4)
                    answer++;
            }
        }
    }

    Console.WriteLine($"Part 1 Answer: {answer}");
}

void Part2(char[,] grid)
{
    long answer = 0;
    long addedThisLoop = 1;

    while (addedThisLoop > 0)
    {
        addedThisLoop = 0;

        for (var i = 0; i < 138; i++)
        {
            for (var i2 = 0; i2 < 138; i2++)
            {
                if (grid[i, i2].Equals('@'))
                {
                    var surroundingValues = new List<char>();

                    if (i > 0) // Square above
                        surroundingValues.Add(grid[(i - 1), i2]);

                    if (i < 137) // Square below
                        surroundingValues.Add(grid[(i + 1), i2]);

                    if (i2 > 0) // Square left
                        surroundingValues.Add(grid[i, (i2 - 1)]);

                    if (i2 < 137) // Square right
                        surroundingValues.Add(grid[i, (i2 + 1)]);

                    if (i > 0 && i2 > 0) // Square above and left
                        surroundingValues.Add(grid[(i - 1), (i2 - 1)]);

                    if (i > 0 && i2 < 137) // Square above and right
                        surroundingValues.Add(grid[(i - 1), (i2 + 1)]);

                    if (i < 137 && i2 > 0) // Square below and left
                        surroundingValues.Add(grid[(i + 1), (i2 - 1)]);

                    if (i < 137 && i2 < 137) // Square below and right
                        surroundingValues.Add(grid[(i + 1), (i2 + 1)]);

                    if (surroundingValues.Where(x => x.Equals('@')).Count() < 4)
                    {
                        grid[i, i2] = '.';
                        addedThisLoop++;
                        answer++;
                    }
                }
            }
        }
    }

    Console.WriteLine($"Part 2 Answer: {answer}");
}