using _02_SendingStateThroughDelegate;

Car c1 = new("SlugBug", 100, 10);
// direct creation of Car.EngineHandler delegate objects
c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));
c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEventUpperCased));

// instead of creating delegate objects like above -> method group conversion syntax
// unregistering works with this syntax too!
c1.RegisterWithCarEngine(OnCarEngineEventLowerCased);

Console.WriteLine("********* Speeding up *********");
for (int i = 0; i < 6; i++)
{
    c1.Accelerate(20);
}

static void OnCarEngineEvent(string msg)
{
    Console.WriteLine("\n*** Message From Car Object");
    Console.WriteLine($"=> {msg}");
    Console.WriteLine("*****************************\n");
}

static void OnCarEngineEventUpperCased(string msg)
{
    Console.WriteLine($"Uppercased => {msg.ToUpper()}");
}

static void OnCarEngineEventLowerCased(string msg)
{
    Console.WriteLine($"Lowercased => {msg.ToLower()}");
}