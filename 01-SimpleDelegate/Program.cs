using _01_SimpleDelegate;

BinaryOp add = new(SimpleMath.Add);
BinaryOp sub = new(SimpleMath.Subtract);

Console.WriteLine("10 + 10 is {0}", add(10, 10));
Console.WriteLine("10 - 10 is {0}", sub(10, 10));

ShowDelegate(add);
ShowDelegate(sub);

static void ShowDelegate(Delegate del)
{
    foreach(Delegate d in del.GetInvocationList())
    {
        Console.WriteLine($"Method name: {d.Method}");

        // if the delegate is pointing to a static member, then target is null
        Console.WriteLine($"Type name: {d.Target}");
    }
}

public delegate int BinaryOp(int x, int y);
