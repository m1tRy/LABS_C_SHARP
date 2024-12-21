using Lab_03;

namespace Lab_10
{
    [TestClass]
    public class DynamicArrayTests
    {
        private DynamicArray<int> _dynamicArray;

        [TestInitialize]
        public void Setup()
        {
            _dynamicArray = new DynamicArray<int>();
        }

        [TestMethod]
        public void Add_ShouldIncreaseLength()
        {
            _dynamicArray.Add(1);
            Assert.AreEqual(1, _dynamicArray.Length);
        }

        [TestMethod]
        public void Add_ShouldAddElement()
        {
            _dynamicArray.Add(1);
            Assert.AreEqual(1, _dynamicArray[0]);
        }

        [TestMethod]
        public void AddRange_ShouldIncreaseLength()
        {
            _dynamicArray.AddRange(new[] { 1, 2, 3 });
            Assert.AreEqual(3, _dynamicArray.Length);
        }

        [TestMethod]
        public void AddRange_ShouldAddElements()
        {
            _dynamicArray.AddRange(new[] { 1, 2, 3 });
            Assert.AreEqual(1, _dynamicArray[0]);
            Assert.AreEqual(2, _dynamicArray[1]);
            Assert.AreEqual(3, _dynamicArray[2]);
        }

        [TestMethod]
        public void Remove_ShouldReturnTrueAndDecreaseLength()
        {
            _dynamicArray.Add(1);
            _dynamicArray.Add(2);
            bool result = _dynamicArray.Remove(1);
            Assert.IsTrue(result);
            Assert.AreEqual(1, _dynamicArray.Length);
        }

        [TestMethod]
        public void Remove_ShouldReturnFalseIfElementNotFound()
        {
            _dynamicArray.Add(1);
            bool result = _dynamicArray.Remove(2);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Insert_ShouldInsertAtCorrectIndex()
        {
            _dynamicArray.Add(1);
            _dynamicArray.Add(3);
            _dynamicArray.Insert(1, 2);
            Assert.AreEqual(1, _dynamicArray[0]);
            Assert.AreEqual(2, _dynamicArray[1]);
            Assert.AreEqual(3, _dynamicArray[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Insert_ShouldThrowExceptionForInvalidIndex()
        {
            _dynamicArray.Insert(-1, 1); 
            _dynamicArray.Insert(1, 1); 
            _dynamicArray.Add(1);
            _dynamicArray.Insert(3, 1); 
        }

        [TestMethod]
        public void Indexer_Get_ShouldReturnCorrectElement()
        {
            _dynamicArray.Add(1);
            _dynamicArray.Add(2);
            Assert.AreEqual(2, _dynamicArray[1]);
        }

        [TestMethod]
        public void Indexer_Set_ShouldUpdateElement()
        {
            _dynamicArray.Add(1);
            _dynamicArray[0] = 2;
            Assert.AreEqual(2, _dynamicArray[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexer_ShouldThrowExceptionForInvalidIndex()
        {
            _dynamicArray[-1] = 1;
        }


        [TestMethod]
        public void ConstructorWithCapacity_ShouldCreateArrayWithGivenCapacity()
        {
            var array = new DynamicArray<int>(10);
            Assert.AreEqual(10, array.Capacity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorWithNegativeCapacity_ShouldThrowException()
        {
            var array = new DynamicArray<int>(-1);
        }

        [TestMethod]
        public void ConstructorWithCollection_ShouldAddElements()
        {
            var array = new DynamicArray<int>(new[] { 1, 2, 3 });
            Assert.AreEqual(3, array.Length);
            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(2, array[1]);
            Assert.AreEqual(3, array[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorWithNullCollection_ShouldThrowException()
        {
            var array = new DynamicArray<int>(null);
        }

        [TestMethod]
        public void Equals_ShouldReturnTrueForIdenticalArrays()
        {
            var array1 = new DynamicArray<int>(new[] { 1, 2, 3 });
            var array2 = new DynamicArray<int>(new[] { 1, 2, 3 });
            Assert.IsTrue(array1.Equals(array2));
        }

        [TestMethod]
        public void Equals_ShouldReturnFalseForDifferentArrays()
        {
            var array1 = new DynamicArray<int>(new[] { 1, 2, 3 });
            var array2 = new DynamicArray<int>(new[] { 1, 2, 4 });
            Assert.IsFalse(array1.Equals(array2));
        }
    }
}