using MatrixTrace;
using System;

namespace MatrixTest
{
    [TestClass]
    public class MatrixTests
    {
        [TestClass]
        public class MatrixTest
        {
            [TestMethod]
            public void TestDifferentMatrix()
            {
                int[,] ints = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } };
                int expected = 12;
                Matrix testObject = new Matrix(ints);
                Assert.AreEqual(expected, testObject.SumMainDiagonal());
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException),
            "The matrix elements is not allowed from the condition.")]
            public void ValuesMinusConstructor()
            {
                int[,] ints = { { -2, -4, 2 }, { 3, 4, 5 }, { 6, 7, 8 } };
                int expected = 12;
                Matrix testObject = new Matrix(ints);
                Assert.AreEqual(expected, testObject.SumMainDiagonal());
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException),
             "A null value was inappropriately allowed.")]
            public void NullConstructor()
            {
                Matrix a = new Matrix(0, 0);
            }

            [TestMethod]
            public void Test0Until100Elements()
            {
                bool allElementsAre0Until100 = true;
                int columns = 10;
                int rows = 10;
                Matrix testObject = new Matrix(columns, rows);
                int[,] matrixCopy = testObject.GetMatrixCopy();
                for (int i = 0; i < testObject.Rows; i++)
                {
                    for (int j = 0; j < testObject.Columns; j++)
                    {
                        if (matrixCopy[i, j] < 0 || matrixCopy[i, j] > 100)
                        {
                            allElementsAre0Until100 = false;
                        }
                    }
                }
                Assert.IsTrue(allElementsAre0Until100);
            }

            [TestMethod]
            public void ColumnsRowsVerification()
            {
                int columns = 5;
                int rows = 3;
                Matrix testObject = new Matrix(columns, rows);
                Assert.AreEqual(columns, testObject.Columns);
                Assert.AreEqual(rows, testObject.Rows);
            }
        }
    }
}