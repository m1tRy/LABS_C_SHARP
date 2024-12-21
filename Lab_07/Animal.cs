using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_07
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; } 

        public Animal(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }

        
        public virtual string GetInfo()
        {
            return $"Это животное: {Name}, возраст: {Age} лет.";
        }

      
        public void CelebrateBirthday()
        {
            Age++;
            Console.WriteLine($"{Name} отмечает день рождения и теперь ему {Age} лет!");
        }
    }


    public interface IMakeSound
    {
        void MakeSound();
    }


    public class Dog : Animal, IMakeSound
    {
      
        public event Action OnMakeSound;

        public Dog(string name, int age) : base(name, age) { }

        public override string GetInfo()
        {
            return base.GetInfo() + " Это собака.";
        }

        public void MakeSound()
        {
            Console.WriteLine($"{Name} говорит: Гав!");
            OnMakeSound?.Invoke(); 
        }
    }


    public class Cat : Animal, IMakeSound
    {
        public event Action OnMakeSound;

        public Cat(string name, int age) : base(name, age) { }

        public override string GetInfo()
        {
            return base.GetInfo() + " Это кошка.";
        }

        public void MakeSound()
        {
            Console.WriteLine($"{Name} говорит: Мяу!");
            OnMakeSound?.Invoke();
        }
    }


    public class Parrot : Animal, IMakeSound
    {
        public event Action OnMakeSound;

        public Parrot(string name, int age) : base(name, age) { }

        public override string GetInfo()
        {
            return base.GetInfo() + " Это попугай.";
        }

        public void MakeSound()
        {
            Console.WriteLine($"{Name} говорит: Попугай!");
            OnMakeSound?.Invoke();
        }
    }

}
