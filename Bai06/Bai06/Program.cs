using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai06
{
    internal class Program
    {
        //câu a: Xuất ma trận
        static void Xuatmatrix(int[,] mt)
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
        //câu b:tìm phần tử lớn nhất/nhỏ nhất;
        static int Timmax(int[,] mt)
        {
            int maxValue = mt[0, 0];
            for (int i = 0; i < mt.GetLength(0); i++)
            {
                for (int j = 0; j < mt.GetLength(1); j++)
                {
                    if (mt[i, j] > maxValue)
                    {
                        maxValue = mt[i, j];
                    }
                }
            }
            return maxValue;
        }
        static int Timmin(int[,] mt)
        {
            int minValue = mt[0, 0];
            for (int i = 0; i < mt.GetLength(0); i++)
            {
                for (int j = 0; j < mt.GetLength(1); j++)
                {
                    if (mt[i, j] < minValue)
                    {
                        minValue = mt[i, j];
                    }
                }
            }
            return minValue;

        }
        //câu c:tìm dòng có tổng lớn nhất:
        static int LineSumMax(int[,] mt)
        {
            int LineMax = 0;
            int SumMax = int.MinValue;
            for (int i = 0; i < mt.GetLength(0); i++)
            {
                int tong = 0;
                for (int j = 0; j < mt.GetLength(1); j++)
                {
                    tong += mt[i, j];
                }
                if (tong > SumMax)
                {
                    LineMax = i;
                    SumMax = tong;
                }
            }
            return LineMax;

        }
        //câu d: Tính tổng các số không là số nguyên tố:
        static bool Isprime(int n)
        {
            if (n < 2)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        static int SumNoPrime(int[,] mt)
        {
            int Sum = 0;
            for (int i = 0; i < mt.GetLength(0); i++)
            {
                for (int j = 0; j < mt.GetLength(1); j++)
                {
                    if (!Isprime(mt[i, j]))
                    {
                        Sum += mt[i, j];
                    }
                }
            }
            return Sum;
        }
        //câu e: xóa dòng thứ k;
        static int[,] XoaDongK(int[,] mt, int k)
        {
            try
            {
                if (k < 0 || k >= mt.GetLength(0))
                {
                    throw new ArgumentOutOfRangeException(nameof(k), "Chỉ số dòng k không hợp lệ!");
                }
                int[,] ans = new int[mt.GetLength(0) - 1, mt.GetLength(1)];
                int r = 0;
                for (int i = 0; i < mt.GetLength(0); i++)
                {
                    if (i == k)
                    {
                        continue;
                    }
                    for (int j = 0; j < mt.GetLength(1); j++)
                    {
                        ans[r, j] = mt[i, j];
                    }
                    r++;
                }
                return ans;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return mt;
            }
        }
        //câu f: Xóa cột chứa phần tử lớn nhất trong ma trận:
        static int[,] XoaCotMax(int[,] mt)
        {
            int rows = mt.GetLength(0);
            int cols = mt.GetLength(1);
            int maxValue = mt[0, 0];
            int maxCot = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (mt[i, j] > maxValue)
                    {
                        maxValue = mt[i, j];
                        maxCot = j;
                    }
                }
            }
            int[,] ans = new int[rows, cols - 1];
            for (int i = 0; i < rows; i++)
            {
                int c = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (j == maxCot)
                    {
                        continue;
                    }
                    ans[i, c] = mt[i, j];
                    c++;
                }
            }
            return ans;
        }
        static void Main(string[] args)
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
            Xuatmatrix(matrix);
            Console.WriteLine("Số lớn nhất trong ma trận: " + Timmax(matrix));
            Console.WriteLine("Số nhỏ nhất trong ma trận: " + Timmin(matrix));
            Console.WriteLine("Dòng có tổng lớn nhất: " + LineSumMax(matrix));
            Console.WriteLine("Tổng các số không là nguyên tố: " + SumNoPrime(matrix));
            Console.Write("Nhập k: ");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine($"Ma trận sao khi xóa dòng {k}: ");
            int[,] ans = XoaDongK(matrix, k);
            Xuatmatrix(ans);
            int[,] result = XoaCotMax(matrix);
            Console.WriteLine($"Ma trận sao khi xóa cột có số lớn nhất: ");
            Xuatmatrix(result);
        }
    }
}
