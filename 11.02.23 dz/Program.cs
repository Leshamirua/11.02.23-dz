using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _11._02._23_dz
{
    internal class Program
    {
        class Matrix
        {
            private int[,] matrix;
            public int Rows { get; private set; }
            public int Columns { get; private set; }
            public Matrix(int rows, int columns)
            {
                Rows = rows; Columns = columns;
                matrix = new int[Rows, Columns];
            }

            public Matrix()
            {

            }

            public void Input()
            {
                Console.WriteLine($" Введите значения матрицы: ");
                
                for(int i = 0;i < Rows; i++)
                {
                    for (int j = 0; j<Columns; j++)
                    {
                        matrix[i,j] = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.WriteLine();
                }
            }
            public void Output()
            {
                for(int i = 0;i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        Console.Write(matrix[i,j]+" ");
                    }
                    Console.WriteLine();
                }
            }
            public int Minimum()
            {
                int min= matrix[0,0];
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        if (matrix[i, j] < min)
                        {
                            min = matrix[i, j];
                        }
                    }
                }
                return min; 
            }
            public int Maximum()
            {
                int max = matrix[0, 0];
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        if (matrix[i, j] > max)
                        {
                            max = matrix[i, j];
                        }
                    }
                }
                return max;
            }
            public static Matrix operator+ (Matrix matrix1, Matrix matrix2)
            {
                try
                {
                    if (matrix1.Rows != matrix2.Rows|| matrix1.Columns != matrix2.Columns)
                        throw new Exception("        Invalid matrix size!       ");
                    Matrix result = new Matrix();
                    result.matrix = new int[matrix1.Rows, matrix1.Columns];
                    for (int i = 0; i < result.Rows; i++)
                    {
                        for (int j = 0; j < result.Columns; j++)
                        {
                            result.matrix[i, j] = matrix1.matrix[i, j] + matrix2.matrix[i, j];
                        }
                    }
                    return result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
                
            }
            public static Matrix operator- (Matrix matrix1, Matrix matrix2)
            {
                try
                {
                    if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
                        throw new Exception("        Invalid matrix size!       ");
                    Matrix result = new Matrix();
                    result.matrix = new int[matrix1.Rows, matrix1.Columns];
                    for (int i = 0; i < result.Rows; i++)
                    {
                        for (int j = 0; j < result.Columns; j++)
                        {
                            result.matrix[i, j] = matrix1.matrix[i, j] - matrix2.matrix[i, j];
                        }
                    }
                    return result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
            public static Matrix operator* (Matrix matrix1, Matrix matrix2)
            {
                try
                {
                    if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
                        throw new Exception("        Invalid matrix size!       ");
                    Matrix result = new Matrix();
                    result.matrix = new int[matrix1.Rows, matrix1.Columns];
                    for (int i = 0; i < result.Rows; i++)
                    {
                        for (int j = 0; j < result.Columns; j++)
                        {
                            result.matrix[i, j] = matrix1.matrix[i, j] * matrix2.matrix[i, j];
                        }
                    }
                    return result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
            public static Matrix operator* (Matrix matrix1, int a)
            {
                
                    Matrix result = new Matrix();
                    result.matrix = new int[matrix1.Rows, matrix1.Columns];
                    for (int i = 0; i < result.Rows; i++)
                    {
                        for (int j = 0; j < result.Columns; j++)
                        {
                            result.matrix[i, j] = matrix1.matrix[i, j] * a;
                        }
                    }
                    return result;
                
            }
            public static bool operator ==(Matrix matrix1, Matrix matrix2)
            {
                try
                {
                    if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
                        throw new Exception("        Invalid matrix size!       ");
                   
                    for (int i = 0; i < matrix1.Rows; i++)
                    {
                        for (int j = 0; j < matrix1.Columns; j++)
                        {
                           if (matrix1.matrix[i, j] != matrix2.matrix[i, j])
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            public static bool operator != (Matrix matrix1, Matrix matrix2)
            {
                try
                {
                    if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
                        throw new Exception("        Invalid matrix size!       ");

                    for (int i = 0; i < matrix1.Rows; i++)
                    {
                        for (int j = 0; j < matrix1.Columns; j++)
                        {
                            if (matrix1.matrix[i, j] == matrix2.matrix[i, j])
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            public int this[int r, int c]
            {
                get
                {
                    if (r < 0 || r >= matrix.GetLength(0))
                    {
                        throw new Exception("Invalid index!" + r);
                    }
                    else if (c < 0 || c >= matrix.GetLength(1))
                    {
                        throw new Exception("Invalid index! " + c);
                    }
                    else
                        return matrix[r, c];
                }
                set
                {
                    if (r < 0 || r >= matrix.GetLength(0))
                    {
                        throw new Exception("Invalid index! " + r);
                    }
                    else if (c < 0 || c >= matrix.GetLength(1))
                    {
                        throw new Exception("Invalid index! " + c);
                    }
                    else
                        matrix[r, c] = value;
                }
            }
        }

        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(4,4);
            matrix.Input();
            matrix.Output();
            Console.WriteLine();
            Console.WriteLine(matrix.Maximum());
            Console.WriteLine();
            Console.WriteLine(matrix.Minimum());

        }
    }
}
