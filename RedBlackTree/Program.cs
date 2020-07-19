using System;
using System.Linq;

namespace RedBlackTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var tree = new RedBlackTree<Person>() {
                new Person(1),
                new Person(2),
                new Person(3),
                new Person(4),
                new Person(5),
                new Person(6),
                new Person(7),
                new Person(8),
                new Person(9),
                new Person(10),
            };

            //Console.WriteLine(tree.Contains(new Person(15)));
            //tree.Remove(new Person(5));
            //tree.MakeRoot(new Person(5));

            foreach (var person in tree)
            {
                Console.WriteLine(person);
            }
        }
    }

    class Person : IEntity
    {
        public int Id { get; }

        public string Name { get; set; }

        public Person(int id)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"Person(Id={Id})";
        }

        public override bool Equals(object obj)
        {
            return obj is Person person &&
                   Id == person.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
