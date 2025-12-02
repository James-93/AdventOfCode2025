

var operations = File.ReadAllLines("input.txt");

Part1(operations);

Part2(operations);

static void Part2(string[] operations)
{
  var answer = 0;
  var startingPoint = 50;
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
      answer++;
    }
    else if (startingPoint > 99)
    {
      startingPoint = (startingPoint % 100);
      answer++;
    }
    else if ((startingPoint % 100) == 0)
    {
      answer++;
      startingPoint = 0;
    }

    answer += timePassedZero;
  }

  Console.WriteLine($"Part 2 Answer: {answer}");
}

static void Part1(string[] operations)
{
  var startingPoint = 50;
  var answer = 0;

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
      answer++;
      continue;
    }

    if (startingPoint < 0)
    {
      startingPoint = (100 + startingPoint);
    }

    if ((startingPoint % 100) == 0)
      answer++;
  }

  Console.WriteLine($"Part 1 Answer: {answer}");
}