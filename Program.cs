﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqOverCollections
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** LINQ over Generic Collections *****");

            // Make a List<> of Car objects.
            List<Car> myCars = new List<Car>()
            {
                new Car {PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
                new Car {PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
                new Car {PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
                new Car {PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                new Car {PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford" } ,
            };

            GetFastCars(myCars);
            GetFastBMWs(myCars);
            LINQOverArrayList();
            OfTypeAsFilter();
            Console.ReadLine();
        }

        static void GetFastCars(List<Car> myCars)
        {
            // Find all Car objects in the List<> where the Speed is greater than 55.
            var fastCars = from c in myCars where c.Speed > 55 select c;

            foreach (var car in fastCars)
                Console.WriteLine($"{car.PetName} is going too fast!");
        }

        static void GetFastBMWs(List<Car> myCars)
        {
            var fastCars = from c in myCars where c.Speed > 90 && c.Make == "BMW" select c;

            foreach (var car in fastCars)
                Console.WriteLine($"{car.PetName} is going too fast!");
        }
        static void LINQOverArrayList()
        {
            Console.WriteLine("***** LINQ Over ArrayList *****");

            // Here is a nongeneric collection of cars.
            ArrayList myCars = new ArrayList()
            {
                new Car {PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
                new Car {PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
                new Car {PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
                new Car {PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                new Car {PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford" } ,
            };

            //Transform ArrayList into an IEnumerable<T>-compatible type.
            var myCarsEnum = myCars.OfType<Car>();

            //Create a query into an IEnumerable<T>-compatible type.
            var fastCars = from c in myCarsEnum where c.Speed > 55 select c;

            foreach (var car in fastCars)
                Console.WriteLine($"{car.PetName} is going too fast!");

        }

        static void OfTypeAsFilter()
        {
            // Extract the ints from the ArrayList.
            ArrayList myStuff = new ArrayList();
            myStuff.AddRange(new object[] { 10, 400, 8, false, new Car(), "string data" });
            var myInts = myStuff.OfType<int>();

            // Prints out 10, 400, and 8.
            foreach (int i in myInts)
                Console.WriteLine("Int value: {0}", i);
        }
    }
}
