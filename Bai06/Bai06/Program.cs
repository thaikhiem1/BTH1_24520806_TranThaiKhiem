using System;
using System.Text;

namespace Bai06
{
    internal class Program
    {
        // Câu a: Xuất ma trận
        static void xuatmatrix(int[,] mt)
        {
            for (int i = 0; i < mt.GetLength(0); i++)
            {
                for (int j = 0; j < mt.GetLength(1); j++)
                {
                    Console.Write(mt[i, j].ToString("D2") + " ");
                }
                Console.WriteLine();
            }
        }

        // Câu b: tìm phần tử lớn nhất/nhỏ nhất
        static int timmax(int[,] mt)
        {
            int maxValue = mt[0, 0];
            for (int i = 0; i < mt.GetLength(0); i++)
            {
                for (int j = 0; j < mt.GetLength(1); j++)
                {
                    if (mt[i, j] > maxValue)
                        maxValue = mt[i, j];
                }
            }
            return maxValue;
        }
        static int timmin(int[,] mt)
        {
            int minValue = mt[0, 0];
            for (int i = 0; i < mt.GetLength(0); i++)
            {
                for (int j = 0; j < mt.GetLength(1); j++)
                {
                    if (mt[i, j] < minValue)
                        minValue = mt[i, j];
                }
            }
            return minValue;
        }
        // Câu c: tìm dòng có tổng lớn nhất
        static int linesummax(int[,] mt)
        {
            int LineMax = 0;
            int SumMax = int.MinValue;
            for (int i = 0; i < mt.GetLength(0); i++)
            {
                int tong = 0;
                for (int j = 0; j < mt.GetLength(1); j++)
                    tong += mt[i, j];
                if (tong > SumMax)
                {
                    LineMax = i;
                    SumMax = tong;
                }
            }
            return LineMax;
        }
        // Câu d: Tính tổng các số không là số nguyên tố
        static bool isprime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0) return false;
            return true;
        }
        static int SumNoPrime(int[,] mt)
        {
            int Sum = 0;
            for (int i = 0; i < mt.GetLength(0); i++)
            {
                for (int j = 0; j < mt.GetLength(1); j++)
                {
                    if (!isprime(mt[i, j]))
                        Sum += mt[i, j];
                }
            }
            return Sum;
        }
        // Câu e: Xóa dòng thứ k trực tiếp trên ma trận gốc
        static void xoadongk(ref int[,] mt, int k)
        {
            if (k < 0 || k >= mt.GetLength(0))
            {
                Console.WriteLine("Chỉ số dòng k không hợp lệ!");
                return;
            }
            int rows = mt.GetLength(0);
            int cols = mt.GetLength(1);
            int[,] temp = new int[rows - 1, cols];
            int r = 0;

            for (int i = 0; i < rows; i++)
            {
                if (i == k) continue;
                for (int j = 0; j < cols; j++)
                    temp[r, j] = mt[i, j];
                r++;
            }
            mt = temp; 
        }

        // Câu f: Xóa cột chứa phần tử lớn nhất
        static int[,] xoacotmax(int[,] mt)
        {
            int row = mt.GetLength(0);
            int col = mt.GetLength(1);
            int maxValue = mt[0, 0];
            int maxCot = 0;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (mt[i, j] > maxValue)
                    {
                        maxValue = mt[i, j];
                        maxCot = j;
                    }
                }
            }
            int[,] ans = new int[row, col - 1];
            for (int i = 0; i < row; i++)
            {
                int c = 0;
                for (int j = 0; j < col; j++)
                {
                    if (j == maxCot) continue;
                    ans[i, c] = mt[i, j];
                    c++;
                }
            }
            return ans;
        }
        static void Main(string[] args)
        {
            try
            {
                Console.InputEncoding = Encoding.UTF8;
                Console.OutputEncoding = Encoding.UTF8;
                Console.Write("Nhập số hàng: ");
                int m = int.Parse(Console.ReadLine());
                Console.Write("Nhập số cột: ");
                int n = int.Parse(Console.ReadLine());
                Random rd = new Random();
                int[,] matrix = new int[m, n];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = rd.Next(-100, 101);
                    }

                }
                Console.WriteLine("Ma trận vừa tạo: ");
                xuatmatrix(matrix);
                Console.WriteLine("Số lớn nhất trong ma trận: " + timmax(matrix));
                Console.WriteLine("Số nhỏ nhất trong ma trận: " + timmin(matrix));
                Console.WriteLine("Dòng có tổng lớn nhất: " + linesummax(matrix));
                Console.WriteLine("Tổng các số không là nguyên tố: " + SumNoPrime(matrix));
                Console.Write("Nhập k: ");
                int k = int.Parse(Console.ReadLine());
                xoadongk(ref matrix, k);
                Console.WriteLine($"Ma trận sau khi xóa dòng {k}: ");
                xuatmatrix(matrix);
                matrix = xoacotmax(matrix);
                Console.WriteLine("Ma trận sau khi xóa cột có số lớn nhất: ");
                xuatmatrix(matrix);
            }
            catch (Exception ex) { 
                  Console.WriteLine(ex.Message);
            }
        }
    }
}
