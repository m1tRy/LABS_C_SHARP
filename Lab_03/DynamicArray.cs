using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_03
{
    public class DynamicArray<T> : IEnumerable<T>
    {
        private T[] _array;
        private int _count;

        public DynamicArray()
        {
            _array = new T[8];
            _count = 0;
        }

        public DynamicArray(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity cannot be negative.");

            _array = new T[capacity];
            _count = 0;
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            _count = 0;
            _array = new T[8];

            AddRange(collection);
        }

        public void Add(T item)
        {
            EnsureCapacity(_count + 1);
            _array[_count++] = item;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            int collectionCount = 0;
            foreach (var item in collection)
            {
                collectionCount++;
            }

            EnsureCapacity(_count + collectionCount);

            foreach (var item in collection)
            {
                _array[_count++] = item;
            }
        }

        public bool Remove(T item)
        {
            int index = Array.IndexOf(_array, item, 0, _count);
            if (index < 0)
                return false;

            for (int i = index; i < _count - 1; i++)
            {
                _array[i] = _array[i + 1];
            }

            _array[_count - 1] = default; 
            _count--;
            return true;
        }

        public bool Insert(int index, T item)
        {
            if (index < 0 || index > _count)
                throw new ArgumentOutOfRangeException(nameof(index), "Index out of range.");

            EnsureCapacity(_count + 1);

            for (int i = _count; i > index; i--)
            {
                _array[i] = _array[i - 1];
            }

            _array[index] = item;
            _count++;
            return true;
        }

        public int Length => _count;

        public int Capacity => _array.Length;

        private void EnsureCapacity(int min)
        {
            if (Capacity < min)
            {
                int newCapacity = Math.Max(Capacity * 2, min);
                T[] newArray = new T[newCapacity];
                Array.Copy(_array, newArray, _count);
                _array = newArray;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                    throw new ArgumentOutOfRangeException(nameof(index), "Index out of range.");
                return _array[index];
            }
            set
            {
                if (index < 0 || index >= _count)
                    throw new ArgumentOutOfRangeException(nameof(index), "Index out of range.");
                _array[index] = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is DynamicArray<T> otherArray)
            {
                if (this.Length != otherArray.Length)
                {
                    return false;
                }

                for (int i = 0; i < this.Length; i++)
                {
                    if (!EqualityComparer<T>.Default.Equals(this[i], otherArray[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            for (int i = 0; i < Length; i++)
            {
                hash = hash * 31 + (_array[i]?.GetHashCode() ?? 0);
            }
            return hash;
        }
    }
}
