var input = File.ReadAllLines("input.txt");

Part1(input);
Part2(input);

static void Part1(string[] input)
{
    long answer = 0;
    var lists = new List<long[]>();

    for (int i = 0; i < (input.Length - 1); i++)
    {
        var arr = input[i].Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(y => long.Parse(y)).ToList();
        for (var c = 0; c < arr.Count; c++)
        {
            if (i == 0)
            {
                var t = new long[4];
                t[i] = arr[c];
                lists.Add(t);
            }
            else
            {
                var t = lists.ElementAt(c);
                t[i] = arr[c];
                lists.Add(t);
            }
        }
    }

    var opperators = input[4].Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

    for (var i = 0; i < opperators.Length; i++)
    {
        var numbers = lists.ToArray()[i];

        if (opperators[i].Equals("+"))
            answer += numbers.Sum();
        else if (opperators[i].Equals("*"))
            answer += (numbers[0] * numbers[1] * numbers[2] * numbers[3]);
        else
            Console.WriteLine($"Unknown operator {opperators[i]}");
    }

    Console.WriteLine($"Part 1 Answer is {answer}");
}

static void Part2(string[] input)
{
    long answer = 0;
    var lists = new List<long[]>();

    for (int i = 0; i < (input.Length - 1); i++)
    {
        var arr = input[i].Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(y => long.Parse(y)).ToList();
        for (var c = 0; c < arr.Count; c++)
        {
            if (i == 0)
            {
                var t = new long[4];
                t[i] = arr[c];
                lists.Add(t);
            }
            else
            {
                var t = lists.ElementAt(c);
                t[i] = arr[c];
                lists.Add(t);
            }
        }
    }

    var opperators = input[4].Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

    for (var i = 0; i < opperators.Length; i++)
    {
        var numbers = lists.ToArray()[i];

        if (opperators[i].Equals("+"))
            answer += numbers.Sum();
        else if (opperators[i].Equals("*"))
            answer += (numbers[0] * numbers[1] * numbers[2] * numbers[3]);
        else
            Console.WriteLine($"Unknown operator {opperators[i]}");
    }

    Console.WriteLine($"Part 2 Answer is {answer}");
}