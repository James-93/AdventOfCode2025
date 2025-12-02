var input = File.ReadAllLines("input.txt");
var ranges = input[0].Split(',');
long answer = 0;

foreach (var range in ranges)
{
    var lowwerBound = long.Parse(range.Split('-')[0].TrimStart('0'));
    var upperBound = long.Parse(range.Split('-')[1].TrimStart('0'));

    if (lowwerBound > upperBound)
        Console.WriteLine("Invalid range");

    var numbersWithinRange = new List<long>();

    for (long i = lowwerBound; i <= upperBound; i++)
    {
        numbersWithinRange.Add(i);
    }

    foreach (var number in numbersWithinRange)
    {
        var str = number.ToString();

        if (str.Length % 2 != 0)
            continue;

        var firstHalf = str.Substring(0, (str.Length / 2));
        var secondHalf = str.Substring((str.Length / 2), (str.Length / 2));

        if (firstHalf.Equals(secondHalf))
            answer += number;
    }
}

Console.WriteLine($"Part 1 Answer: {answer}");

answer = 0;

foreach (var range in ranges)
{
    var lowwerBound = long.Parse(range.Split('-')[0].TrimStart('0'));
    var upperBound = long.Parse(range.Split('-')[1].TrimStart('0'));

    if (lowwerBound > upperBound)
        Console.WriteLine("Invalid range");

    var numbersWithinRange = new List<long>();

    for (long i = lowwerBound; i <= upperBound; i++)
    {
        numbersWithinRange.Add(i);
    }

    foreach (var number in numbersWithinRange)
    {
        var str = number.ToString();

        for (var c = 1; c <= (str.Length / 2); c++)
        {
            if (str.Length % c != 0)
                continue;

            var pattern = str.Substring(0, c);

            var chunks = str.Select((c, i) => new { c, group = i / 3 })
                         .GroupBy(x => x.group)
                         .Select(g => new string(g.Select(x => x.c).ToArray()))
                         .ToList();

            if (chunks.All(x => x.Equals(pattern)))
            {
                answer += number;
            }
        }
    }
}

Console.WriteLine($"Part 2 Answer: {answer}");