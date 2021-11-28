using System;
using System.Collections.Generic;

namespace FlaviusJosephusTask
{
    // <summary>
    /// Class FlaviusJosephusCalculate
    /// </summary>
    public static class FlaviusJosephusCalculate
    {
        /// <summary>
        /// Find the winner.
        /// </summary>
        /// <param name="count">Number of people</param>
        /// <param name="step">Step to delete</param>
        /// <returns>Number of the remaining person.</returns>
        public static IEnumerable<int> Calculate(int count, int step)
        {
            if (count < 1)
            {
                throw new ArgumentException($"The {nameof(count)} must be more than zero.");
            }

            if (step < 1)
            {
                throw new ArgumentException($"The {nameof(step)} must be more than zero.");
            }

            return GetPersonToRemove(count, step);
        }

        private static IEnumerable<int> GetPersonToRemove(int count, int step)
        {
            Person current = new Person() { Position = 1 };
            Person temp = current;
            for (int i = 2; i <= count; i++)
            {
                current.Next = new Person();
                current.Next.Previous = current;
                current = current.Next;
                current.Position = i;
            }

            current.Next = temp;
            current.Next.Previous = current;
            current = current.Next;
            int counter = 1;
            while (current.Next != current)
            {
                if (counter == step)
                {
                    yield return current.Position;
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                    var next = current.Previous.Next;
                    current = next;
                    counter = 1;
                }
                else
                {
                    current = current.Next;
                    counter++;
                }
            }

            yield return current.Position;
        }

        private class Person
        {
            public int Position { get; set; }
            public Person Previous { get; set; }
            public Person Next { get; set; }
        }
    }
}
