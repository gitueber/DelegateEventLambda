using _05_EventExample;

Car car = new("SlubBug", 100, 10);
// registering to events
car.AboutToBlow += CarIsAlmostDoomed;
car.AboutToBlow += CarAboutToBlow;

// here just an example, using the method group conversion syntax with events
Car.CarEngineHandler engineHandler = CarExploded;
car.Exploded += engineHandler;

Console.WriteLine("#### Speeding up ####");
for (int i = 0; i < 6; i++)
{
    car.Accelerate(20);
}

// unregister CarExploded method -> message 'Sorry, this car is dead' won't be printed for each iteration
car.Exploded -= engineHandler;
Console.WriteLine("#### Speeding up ####");
for (int i = 0; i < 6; i++)
{
    car.Accelerate(20);
}


static void CarAboutToBlow(string msg)
{
    Console.WriteLine(msg);
}

static void CarIsAlmostDoomed(string msg)
{
    Console.WriteLine($"=> Critical Message from Car: {msg}");
}

static void CarExploded(string msg)
{
    Console.WriteLine(msg);
}