using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Bai01
{
    internal class Program
    {
        //câu a: Tính tổng các số lẻ trong mảng:
        
        static int TongSoLe(int[] number)
        {
            int sum = 0;
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] % 2 != 0)
                {
                    sum += number[i];
                }
            }
            return sum;
        }
        //câu b: Đếm số nguyên tố trong mảng:
        static bool[] check_prime(int n)
        {
            bool[] SangNt = new bool[n + 1];
            SangNt[0] = false;
            SangNt[1] = false;
            for (int i = 2; i <= n; i++)
            {
                SangNt[i] = true;
            }
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (SangNt[i])
                {
                    for (int j = i * i; j <= n; j += i)
                    {
                        SangNt[j] = false;
                    }
                }

            }
            return SangNt;
        }
        static int CountPrime(int[] number)
        {
            int count = 0;
            int maxValue = number.Max();
            bool[] SangNt = check_prime(maxValue);
            foreach (int x in number)
            {
                if (x >= 2 && SangNt[x])
                {
                    count++;
                }
            }
            return count;
        }
        //câu c:Tìm số chính phương nhỏ nhất:
        static bool check_chinh_phuong(int n)
        {
            if (n < 0)
            {
                return false;
            }
            int sqrt_n = (int)Math.Sqrt(n);
            return sqrt_n * sqrt_n == n;
        }
        static int ChinhPhuongNhoNhat(int[] number)
        {
            int cp_min = int.MaxValue;
            for (int i = 0; i < number.Length; i++)
            {
                if (check_chinh_phuong(number[i]) && number[i] < cp_min)
                {
                    cp_min = number[i];

                }
            }
            if (cp_min == int.MaxValue)
            {
                return -1;
            }
            return cp_min;
        }

        static void Main(string[] args)
        {
            //câu a
            try{
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            int n;
            Console.Write("Nhập số nguyên n: ");
            n = int.Parse(Console.ReadLine());
            int[] number = new int[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                number[i] = rand.Next(-100, 101);
            }
            int SumLe = TongSoLe(number);
            Console.Write("Mảng sau khi random n số ngẫu nhiên: ");
            Console.WriteLine(string.Join(" ", number));
            Console.WriteLine($"Tổng các số lẻ trong mảng: {SumLe}");
            //câu b
            int count = CountPrime(number);
            Console.WriteLine($"Tổng số nguyên tố trong mảng: {count}");
            //câu c
            int min_cp = ChinhPhuongNhoNhat(number);
            if (min_cp != -1)
            {
                Console.Write("Số chính phương nhỏ nhất: ");
                for (int i = 0; i < number.Length; i++)
                {
                    if (number[i] == min_cp)
                    {
                        Console.WriteLine(number[i] + " ");
                    }
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy số chính phương trong mảng: " + min_cp);
            }
            }
             catch (Exception ex) { 
       Console.WriteLine("Lỗi: "+ ex.Message);
 }
        }
    }
}





