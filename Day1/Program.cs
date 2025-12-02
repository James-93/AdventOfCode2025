
var counter = 0;
var startingPoint = 50;
var operations = File.ReadAllLines("input.txt");

foreach (var operation in operations)
{
    var t = operation[0];
    var value = int.Parse(operation.Trim(t));

    if (t.Equals('L'))
    {
        // Minus value from startingPoint
        startingPoint -= value;
    }
    else if (t.Equals('R'))
    {
        // Add value to startingPoint
        startingPoint += value;
    }

    if (startingPoint.Equals(0))
    {
        counter++;
        continue;
    }

    if (startingPoint < 0)
    {
        startingPoint = (100 + startingPoint);
    }

    if ((startingPoint % 100) == 0)
        counter++;
}

Console.WriteLine($"Part 1 Answer: {counter}");

counter = 0;
startingPoint = 50;

foreach (var operation in operations)
{
    var t = operation[0];
    var value = int.Parse(operation.Trim(t));
    var timePassedZero = (value / 100);

    if (t.Equals('L'))
    {
        // Minus value from startingPoint
        startingPoint -= value;
    }
    else if (t.Equals('R'))
    {
        // Add value to startingPoint
        startingPoint += value;
    }

    if (startingPoint < 0)
    {
        startingPoint = (startingPoint % 100);
        counter++;
    }
    else if (startingPoint > 99)
    {
        startingPoint = (startingPoint % 100);
        counter++;
    }
    else if ((startingPoint % 100) == 0)
    {
        counter++;
        startingPoint = 0;
    }

    counter += timePassedZero;
}

Console.WriteLine($"Part 2 Answer: {counter}");
