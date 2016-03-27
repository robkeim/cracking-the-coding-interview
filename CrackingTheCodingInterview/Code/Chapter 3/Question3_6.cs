using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Code
{
    // 3.6 Animal Shelter: An animal shelter, which holds only dogs and cats, operates on a strictly "first in, first out" basis.  People must
    // adopt either the "oldest" (based on arrival time) of all animals at the shelter, or they can select whether they would prefer a dog or a
    // cat (and will receive the oldest animal of that type).  They cannot select which specific animal they would like.  Create the data structures
    // to maintain this system and implement operations such as enqueue, dequeueAny, dequeueDog, and dequeueCat.  You may use the built-in LinkedList
    // data structure.

    // Space: O(N) -> the number of animals in the shelter
    // Time: O(1) -> for all of the methods implemented
    [SuppressMessage("Documentation Rules", "SA1649")]
    public class AnimalShelter
    {
        private readonly LinkedList<Cat> cats;
        private readonly LinkedList<Dog> dogs;

        public AnimalShelter()
        {
            cats = new LinkedList<Cat>();
            dogs = new LinkedList<Dog>();
        }

        public void Enqueue(Animal animal)
        {
            var cat = animal as Cat;
            var dog = animal as Dog;

            if (cat != null)
            {
                cats.AddLast(cat);
            }
            else if (dog != null)
            {
                dogs.AddLast(dog);
            }
            else
            {
                throw new InvalidOperationException("The shelter does not accept this type of animal");
            }
        }

        public Animal DequeueAny()
        {
            if (cats.Count == 0 && dogs.Count == 0)
            {
                throw new InvalidOperationException("There are no animals in the shelter");
            }

            var catEnqueueTime = cats?.First?.Value?.ArrivalTime ?? DateTimeOffset.MaxValue;
            var dogEnqueueTime = dogs?.First?.Value?.ArrivalTime ?? DateTimeOffset.MaxValue;

            // NOTE: this will favor a dog in the event that two animals were enqueued exactly at the same time although I doubt LinkedList is
            // thread safe, so if we wanted to support that scenario, we'd have to use a thread safe class or add locks around the accesses.
            if (catEnqueueTime < dogEnqueueTime)
            {
                return DequeueCat();
            }
            else
            {
                return DequeueDog();
            }
        }

        public Cat DequeueCat()
        {
            if (cats.Count == 0)
            {
                throw new InvalidOperationException("There are no cats in the shelter");
            }

            var result = cats.First.Value;
            cats.RemoveFirst();

            return result;
        }

        public Dog DequeueDog()
        {
            if (dogs.Count == 0)
            {
                throw new InvalidOperationException("There are no dogs in the shelter");
            }

            var result = dogs.First.Value;
            dogs.RemoveFirst();

            return result;
        }
    }

    [SuppressMessage("Maintainability Rules", "SA1402")]
    public class Cat : Animal
    {
        public Cat(int id)
            : base(id)
        {
        }
    }

    [SuppressMessage("Maintainability Rules", "SA1402")]
    public class Dog : Animal
    {
        public Dog(int id)
            : base(id)
        {
        }
    }

    [SuppressMessage("Maintainability Rules", "SA1402")]
    [DebuggerDisplay("Id = {Id}, ArrivalTime = {DebuggerDisplay,nq}")]
    public abstract class Animal
    {
        protected Animal(int id)
        {
            Id = id;
            ArrivalTime = DateTimeOffset.UtcNow;
        }

        public int Id { get; }

        public DateTimeOffset ArrivalTime { get; }

        [SuppressMessage("Microsoft.Performance", "CA1811")]
        private string DebuggerDisplay => $"{ArrivalTime:HH:mm:ss.fff}";
    }
}
