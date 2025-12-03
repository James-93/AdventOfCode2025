
var dial = new SafeDial { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99 };
var operations = File.ReadAllLines("input.txt");

Part1(operations);

Part2(dial, operations);

static void Part2(SafeDial dial, string[] operations)
{
  var answer = 0;
  var pointer = 50;

  foreach (var operation in operations)
  {
    var t = operation[0];
    var value = int.Parse(operation.Trim(t));
    var timePassedZero = (value / 100);

    if (t.Equals('L'))
    {
      // Spin Left
      for (var i = 0; i < value; i++)
      {
        pointer--;
        if (dial[pointer] == 0)
          answer++; // Do a jig
      }
    }
    else if (t.Equals('R'))
    {
      // Spin Right
      for (var i = 0; i < value; i++)
      {
        pointer++;
        if (dial[pointer] == 0)
          answer++; // Do a jig
      }
    }

  }

  Console.WriteLine($"Part 2 Answer: {answer}");
}

static void Part1(string[] operations)
{
  var pointer = 50;
  var answer = 0;

  foreach (var operation in operations)
  {
    var t = operation[0];
    var value = int.Parse(operation.Trim(t));

    if (t.Equals('L'))
    {
      // Minus value from startingPoint
      pointer -= value;
    }
    else if (t.Equals('R'))
    {
      // Add value to startingPoint
      pointer += value;
    }

    if (pointer.Equals(0))
    {
      answer++;
      continue;
    }

    if (pointer < 0)
    {
      pointer = (100 + pointer);
    }

    if ((pointer % 100) == 0)
      answer++;
  }

  Console.WriteLine($"Part 1 Answer: {answer}");
}

public class SafeDial : List<int>
{
  public new int this[int index]
  {
    get
    {
      if (Count == 0)
        throw new ArgumentException("bad input");

      index = ((index % Count) + Count) % Count;
      return base[index];
    }
    set
    {
      if (Count == 0)
        throw new ArgumentException("bad input");

      index = ((index % Count) + Count) % Count;
      base[index] = value;
    }
  }
}