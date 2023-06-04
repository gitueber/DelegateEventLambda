MyGenericDelegate<string> strTarget = new(StringTarget);
strTarget("Some string data");

MyGenericDelegate<int> intTarget = new(IntTarget);
intTarget(42);

static void StringTarget(string arg)
{
    Console.WriteLine($"arg in uppercase is: {arg.ToUpper()}");
}

static void IntTarget(int arg)
{
    Console.WriteLine($"++arg is: {++arg}");
}

public delegate void MyGenericDelegate<T>(T arg);