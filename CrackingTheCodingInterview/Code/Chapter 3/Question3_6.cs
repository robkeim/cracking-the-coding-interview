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

    // For all methods:
    // Space: O(N) where N is the number of animals in the shelter
    // Time: O(1)
    [SuppressMessage("Documentation Rules", "SA1649")]
    public class AnimalShelter
    {
        private readonly LinkedList<Cat> _cats;
        private readonly LinkedList<Dog> _dogs;

        public AnimalShelter()
        {
            _cats = new LinkedList<Cat>();
            _dogs = new LinkedList<Dog>();
        }

        public void Enqueue(Animal animal)
        {
            var cat = animal as Cat;
            var dog = animal as Dog;

            if (cat != null)
            {
                _cats.AddLast(cat);
            }
            else if (dog != null)
            {
                _dogs.AddLast(dog);
            }
            else
            {
                throw new InvalidOperationException("The shelter does not accept this type of animal");
            }
        }

        public Animal DequeueAny()
        {
            if (_cats.Count == 0 && _dogs.Count == 0)
            {
                throw new InvalidOperationException("There are no animals in the shelter");
            }

            var catEnqueueTime = _cats?.First?.Value?.ArrivalTime ?? DateTimeOffset.MaxValue;
            var dogEnqueueTime = _dogs?.First?.Value?.ArrivalTime ?? DateTimeOffset.MaxValue;

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
            if (_cats.Count == 0)
            {
                throw new InvalidOperationException("There are no cats in the shelter");
            }

            var result = _cats.First.Value;
            _cats.RemoveFirst();

            return result;
        }

        public Dog DequeueDog()
        {
            if (_dogs.Count == 0)
            {
                throw new InvalidOperationException("There are no dogs in the shelter");
            }

            var result = _dogs.First.Value;
            _dogs.RemoveFirst();

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
