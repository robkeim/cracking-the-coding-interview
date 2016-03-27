using System;
using System.Linq;
using System.Threading;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test3_6
    {
        [TestMethod]
        public void BasicTest()
        {
            var shelter = new AnimalShelter();

            // Enqueue/dequeue only cats
            EnqueueCats(shelter, 1, 2, 3);
            DequeueAndValidateCats(shelter, 1, 2, 3);

            // Enqueue/dequeue only dogs
            EnqueueDogs(shelter, 4, 5, 6);
            DequeueAndValidateDogs(shelter, 4, 5, 6);

            // Enqueue/dequeue a mix but only dequeue the specific type
            EnqueueCats(shelter, 1, 2);
            EnqueueDogs(shelter, 4, 5);
            EnqueueCats(shelter, 3);
            EnqueueDogs(shelter, 6);

            DequeueAndValidateCats(shelter, 1);
            DequeueAndValidateDogs(shelter, 4);
            DequeueAndValidateCats(shelter, 2, 3);
            DequeueAndValidateDogs(shelter, 5, 6);
        }

        [TestMethod]
        public void InterleavedAnimalTest()
        {
            var shelter = new AnimalShelter();

            EnqueueCats(shelter, 1);
            EnqueueDogs(shelter, 2);
            EnqueueCats(shelter, 3, 4, 5);
            EnqueueDogs(shelter, 6);

            DequeueAndValidateAnimals<Cat>(shelter, 1);
            DequeueAndValidateCats(shelter, 3);
            DequeueAndValidateAnimals<Dog>(shelter, 2);
            DequeueAndValidateAnimals<Cat>(shelter, 4, 5);

            // There's only one animal left (a dog), but we can still use DequeueAny
            DequeueAndValidateAnimals<Dog>(shelter, 6);
        }

        [TestMethod]
        public void InvalidInputTest()
        {
            var shelter = new AnimalShelter();

            // Dequeuing doesn't work when there are no animals
            TestHelpers.AssertExceptionThrown(() => shelter.DequeueAny(), typeof(InvalidOperationException));
            TestHelpers.AssertExceptionThrown(() => shelter.DequeueCat(), typeof(InvalidOperationException));
            TestHelpers.AssertExceptionThrown(() => shelter.DequeueDog(), typeof(InvalidOperationException));

            // Dequeuing doesn't work when there are only animals of the other type
            EnqueueDogs(shelter, 1);
            TestHelpers.AssertExceptionThrown(() => shelter.DequeueCat(), typeof(InvalidOperationException));
            DequeueAndValidateDogs(shelter, 1);

            EnqueueCats(shelter, 2);
            TestHelpers.AssertExceptionThrown(() => shelter.DequeueDog(), typeof(InvalidOperationException));
            DequeueAndValidateCats(shelter, 2);

            // Enqueuing doesn't work for unknown animals
            var elephant = new Elephant(3);
            TestHelpers.AssertExceptionThrown(() => shelter.Enqueue(elephant), typeof(InvalidOperationException));
        }

        private static void EnqueueCats(AnimalShelter shelter, params int[] cats)
        {
            var typedCats = cats.Select(c => new Cat(c));
            EnqueueAnimals(shelter, typedCats.ToArray());
        }

        private static void EnqueueDogs(AnimalShelter shelter, params int[] cats)
        {
            var typedDogs = cats.Select(c => new Dog(c));
            EnqueueAnimals(shelter, typedDogs.ToArray());
        }

        private static void EnqueueAnimals(AnimalShelter shelter, params Animal[] animals)
        {
            foreach (var animal in animals)
            {
                // Sleep here to ensure there are are no time comparison issues and results are easy to test
                // According to the following article precision varies but is typically between 10-15 ms
                // https://msdn.microsoft.com/en-us/library/system.datetimeoffset.now(v=vs.110).aspx
                Thread.Sleep(TimeSpan.FromMilliseconds(50));
                shelter.Enqueue(animal);
            }
        }

        private static void DequeueAndValidateAnimals<T>(AnimalShelter shelter, params int[] ids)
            where T : Animal
        {
            foreach (var id in ids)
            {
                var animal = shelter.DequeueAny();
                Assert.AreEqual(typeof(T), animal.GetType());
                Assert.AreEqual(id, animal.Id);
            }
        }

        private static void DequeueAndValidateCats(AnimalShelter shelter, params int[] ids)
        {
            foreach (var id in ids)
            {
                Assert.AreEqual(id, shelter.DequeueCat().Id);
            }
        }

        private static void DequeueAndValidateDogs(AnimalShelter shelter, params int[] ids)
        {
            foreach (var id in ids)
            {
                Assert.AreEqual(id, shelter.DequeueDog().Id);
            }
        }

        private class Elephant : Animal
        {
            public Elephant(int id)
                : base(id)
            {
            }
        }
    }
}
