using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_07
{
    internal class Round
    {
        private double radius;
        private double centerX;
        private double centerY;

        public Round(double centerX, double centerY, double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentException("Радиус не может быть отрицательным.");
            }

            this.centerX = centerX;
            this.centerY = centerY;
            this.radius = radius;
        }

        public double Circumference
        {
            get { return 2 * Math.PI * radius; }
        }

        public double Area
        {
            get { return Math.PI * radius * radius; }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Круг с центром в ({centerX}, {centerY}) и радиусом {radius}");
            Console.WriteLine($"Длина окружности: {Circumference}");
            Console.WriteLine($"Площадь круга: {Area}");
        }
    }
}
