using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SendingStateThroughDelegate;

public class Car
{
    public int CurrentSpeed { get; set; }
    public int MaxSpeed { get; set; } = 100;

    // in german: kosename!!!
    public string PetName { get; set; }

    public delegate void CarEngineHandler(string msgForCaller);

    private bool _carIsDead;

    private CarEngineHandler _listOfHandlers;

    public Car() { }

    public Car(string petName, int maxSpeed, int currentSpeed)
    {
        PetName = petName;
        CurrentSpeed = currentSpeed;
        MaxSpeed = maxSpeed;
    }

    public void RegisterWithCarEngine(CarEngineHandler handler)
    {
        // multicast enabled
        _listOfHandlers += handler;
    }

    public void Accelerate(int delta)
    {
        if (_carIsDead)
        {
            _listOfHandlers?.Invoke("Sorry, this car is dead");
        }
        else
        {
            CurrentSpeed += delta;
            if (10 == (MaxSpeed - CurrentSpeed))
            {
                _listOfHandlers?.Invoke("Careful buddy! Gonna blow!");
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
