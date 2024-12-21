using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_07
{
    internal class User
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        private DateTime dateOfBirth;

        public User(string lastName, string firstName, string middleName, DateTime dateOfBirth)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            DateOfBirth = dateOfBirth; 
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Дата рождения не может быть в будущем.");
                }
                dateOfBirth = value;
            }
        }

        public int Age
        {
            get
            {
                return DateTime.Now.Year - dateOfBirth.Year - (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear ? 1 : 0);
            }
        }

        public override string ToString()
        {
            return $"ФИО: {LastName} {FirstName} {MiddleName}, " +
                   $"Дата рождения: {DateOfBirth.ToShortDateString()}, " +
                   $"Возраст: {Age} лет";
        }
    }

    internal class Employee : User
    {
        public int WorkExperience { get; set; }
        public string Position { get; set; }

        public Employee(string lastName, string firstName, string middleName, DateTime dateOfBirth, int workExperience, string position)
            : base(lastName, firstName, middleName, dateOfBirth)
        {
            WorkExperience = workExperience;
            Position = position;
        }


        public override string ToString()
        {
            return base.ToString() + $", Стаж работы: {WorkExperience} лет, Должность: {Position}";
        }
    }

}
