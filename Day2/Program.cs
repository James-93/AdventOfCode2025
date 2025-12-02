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

