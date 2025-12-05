var input = File.ReadAllLines("input.txt");

//Part1(input);
Part2(input);

static void Part1(string[] input)
{
    var answer = 0;
    var index = 0;
    var freashRanges = new List<(long lowerBound, long upperBound)>();

    for (index = 0; index < input.Length; index++)
    {
        if (string.IsNullOrEmpty(input[index]))
            break;

        var rangeArr = input[index].Split('-');
        freashRanges.Add(new(long.Parse(rangeArr[0]), long.Parse(rangeArr[1])));
    }
    var requiredIngredients = input.Skip((index + 1)).Select(x => long.Parse(x));



    foreach (var requiredIngredient in requiredIngredients)
    {
        if (freashRanges.Any(x => requiredIngredient >= x.lowerBound && requiredIngredient <= x.upperBound))
            answer++;
    }

    Console.WriteLine($"Part 1 Answer is {answer}");
}

static void Part2(string[] input)
{
    var index = input.ToList().IndexOf(string.Empty);
    var filteredInput = input.Take(index - 1);
    var listOflistsGoodNumbers = new List<List<long>>();

    Parallel.ForEach(filteredInput, x =>
    {
        var listOfGoodNumbers = new List<long>();
        var rangeArr = x.Split('-');

        for (var c = long.Parse(rangeArr[0]); c <= long.Parse(rangeArr[1]); c++)
            listOfGoodNumbers.Add(c);

        listOflistsGoodNumbers.Add(listOfGoodNumbers);
    });

    Console.WriteLine($"Part 2 Answer is {listOflistsGoodNumbers.SelectMany(x => x.Select(y => y)).Distinct().Count()}");
}