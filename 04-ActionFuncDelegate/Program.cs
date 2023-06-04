// Action dont return anything
Action<string, ConsoleColor, int> actionTarget = DisplayMessage;
actionTarget("Action Message!", ConsoleColor.Yellow, 5);

Func<int, int, int> funcTarget = Add;
int result = funcTarget(10, 7);
Console.WriteLine($"'funcTarget' result: {result}");

static void DisplayMessage(string msg, ConsoleColor color, int printCount)
{
    ConsoleColor previous = Console.ForegroundColor;
    Console.ForegroundColor = color;

    for (int i = 0; i< printCount; i++)
    {
        Console.WriteLine(msg);
    }

    Console.ForegroundColor = previous;
}

static int Add(int x, int y)
{
    return x + y;
}
