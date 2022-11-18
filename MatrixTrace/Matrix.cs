using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTrace
{
    public class Matrix
    {
        private int _columns;
        public int Columns => _columns;

        private int _rows;
        public int Rows => _rows;

        private int[,] _matrix;

        public Matrix(int columns, int rows)
        {
            if (columns <= 0)
            {
                throw new ArgumentException(
                   "Parameter columns may not be null and < 0.");
            }            
            if (rows <= 0)
            {
                throw new ArgumentException(
                   "Parameter columns may not be null and < 0.");
            }
            _columns = columns;
            _rows = rows;
            _matrix = new int[_rows, _columns];
            Random random = new Random();
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    _matrix[i, j] = random.Next(101);
                }
            }
        }

        public int[,] GetMatrixCopy()
        {
            return (int[,])_matrix.Clone();
        }

        public Matrix(int[,] testMatrix)
        {
            // Constructor for testing
            bool matrixIsOk = true;
            for (int i = 0; i < testMatrix.GetLength(1); i++)
            {
                for (int j = 0; j < testMatrix.GetLength(0); j++)
                {
                    if (testMatrix[i, j] < 0)
                    {
                        throw new ArgumentException("Parameter columns may not be < 0.");
                        matrixIsOk = false;
                    }
                }
            }
            if (matrixIsOk)
            {
                _rows = testMatrix.GetLength(1);
                _columns = testMatrix.GetLength(0);
                _matrix = testMatrix;
            }
        }

        public void PrintMatrix()
        {
            Console.WriteLine("Generated Matrix {0} * {1}: ", _columns, _rows);
            for (int i = 0; i < _rows; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < _columns; j++)
                {
                    if (i == j)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        string printElement = Convert.ToString(_matrix[i, j]).PadRight(5);
                        Console.Write(printElement);
                        Console.ResetColor();
                    }
                    else
                    {
                        string printElement = Convert.ToString(_matrix[i, j]).PadRight(5);
                        Console.Write(printElement);
                    }
                }
            }
        }

        public int SumMainDiagonal()
        {
            int sumResult = 0;
            int mainDiagonalLength;
            if (_rows <= _columns)
            {
                mainDiagonalLength = _rows;
            }
            else 
            {
                mainDiagonalLength = _columns;            
            }
            for (int i = 0; i < mainDiagonalLength; i++)
            {
                sumResult += _matrix[i, i];
            }
            return sumResult;
        }

        public void EnhancedTask()
        {
            //Print first row
            Console.WriteLine("\nEnhanced Task :");
            for (int j = 0; j < _columns; j++)
            {
                Console.Write("{0} ", _matrix[0, j]);
            }
            //Print last column
            for (int i = 1; i < _rows; i++)
            {
                Console.Write("{0} ", _matrix[i, _columns - 1]);
            }
            //Print rows depends on last printed simbol
            if (_rows % 2 != 0)
            {
                for (int i = _matrix.GetLength(0) - 1; i > 0; i--)
                {
                    if (i % 2 == 0)
                    {
                        for (int j = _matrix.GetLength(1) - 2; j >= 0; j--) Console.Write(_matrix[i, j] + " ");
                    }
                    else
                    {
                        for (int j = 0; j < _matrix.GetLength(1) - 1; j++) Console.Write(_matrix[i, j] + " ");
                    }
                }
            }
            else
            {
                for (int i = _matrix.GetLength(0) - 1; i > 0; i--)
                {
                    if (i % 2 != 0)
                    {
                        for (int j = _matrix.GetLength(1) - 2; j >= 0; j--) Console.Write(_matrix[i, j] + " ");
                    }
                    else
                    {
                        for (int j = 0; j < _matrix.GetLength(1) - 1; j++) Console.Write(_matrix[i, j] + " ");
                    }
                }
            }
        }
    }
}
