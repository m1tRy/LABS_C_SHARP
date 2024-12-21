using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_04
{
    public delegate int Comparison<in T>(T x, T y);
    public delegate void SortingCompletedEventHandler();

    internal class Sorter<T>
    {

        public event EventHandler SortingCompleted;
        public event SortingCompletedEventHandler SortingCompletedWithoutArgs;

        public void SortArray(T[] array, Comparison<T> comparison)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (comparison(array[j], array[j + 1]) > 0)
                    {
                        T temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            OnSortingCompleted();
            OnSortingCompletedWithoutArgs();
        }

        protected virtual void OnSortingCompleted()
        {
            SortingCompleted?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnSortingCompletedWithoutArgs()
        {
            SortingCompletedWithoutArgs?.Invoke(); 
        }
    }
}
