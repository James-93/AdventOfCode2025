var input = File.ReadAllLines("input.txt");

Part1(input);
Part2(input);

static void Part1(string[] input)
{
    long answer = 0;

    foreach (var bank in input)
    {
        var ar = bank.ToCharArray().ToList().Select(x => int.Parse(x.ToString()));

        var highestNumberData = ReturnHighestNumber(ar, 0, (ar.Count() - 1));
        var nextHighestNumberData = ReturnHighestNumber(ar, (highestNumberData.index + 1), (ar.Count() - (highestNumberData.index + 1)));

        if (nextHighestNumberData.index <= highestNumberData.index)
            throw new Exception("Ahhhhhhhhhhhhhhhhhhhhhh");

        answer += int.Parse($"{highestNumberData.value}{nextHighestNumberData.value}");
    }

    Console.WriteLine(answer);
}

static void Part2(string[] input)
{
    long answer = 0;

    foreach (var bank in input)
    {
        var ar = bank.ToCharArray().ToList().Select(x => int.Parse(x.ToString()));
        var numberParts = new List<(int index, int value)>();

        numberParts.Add(ReturnHighestNumber(ar, 0, (ar.Count() - 11)));

        for (int i = 0; i < 11; i++)
        {
            numberParts.Add(ReturnHighestNumber(ar, (numberParts.Last().index + 1), (ar.Count() - (numberParts.Last().index + 1)) - (11 - numberParts.Count())));
        }

        answer += long.Parse(String.Join("",numberParts.Select(x => x.value.ToString()))); 
    }

    Console.WriteLine(answer);
}

static (int index, int value) ReturnHighestNumber(IEnumerable<int> ar, int startingIndex, int length)
{
    var currentHighNumberIndex = 0;
    var highNumber = 0;

    for (int i = 0; i < length; i++)
    {
        if (ar.ElementAt(startingIndex + i) > highNumber)
        {
            currentHighNumberIndex = (startingIndex + i);
            highNumber = ar.ElementAt(currentHighNumberIndex);
        }
    }

    return ( index: currentHighNumberIndex, value: ar.ElementAt(currentHighNumberIndex) );
}