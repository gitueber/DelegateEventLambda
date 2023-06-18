using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_EventExample;

public class Car
{
    private bool _carIsDead;

    public int CurrentSpeed { get; set; }
    public int MaxSpeed { get; set; } = 100;
    public string PetName { get; set; }

    public delegate void CarEngineHandler(string msg);

    public Car(string petName, int maxSpeed, int currentSpeed)
    {
        PetName = petName;
        MaxSpeed = maxSpeed;
        CurrentSpeed = currentSpeed;
    }

    public event CarEngineHandler? Exploded;
    public event CarEngineHandler? AboutToBlow;

    public void Accelerate(int delta)
    {
        if (_carIsDead)
        {
            Exploded?.Invoke("Sorry, this car is dead");
        }
        else
        {
            CurrentSpeed += delta;

            if (10 == MaxSpeed - CurrentSpeed)
            {
                AboutToBlow?.Invoke("Careful buddy! Gonna blow!");
            }

            if (CurrentSpeed >= MaxSpeed)
            {
                _carIsDead = true;
            }
            else
            {
                Console.WriteLine($"CurrentSpeed = {CurrentSpeed}");
            }
        }
    }
}
