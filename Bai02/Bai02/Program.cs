using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bai02
{
    internal class Program
    {
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
        static int SumPrime(int n)
        {
            int sum = 0;
            bool[] Sangnt = check_prime(n);
            for (int i = 0; i < n; i++)
            {
                if (Sangnt[i])
                {
                    sum += i;
                }
            }
            return sum;
        }
        static void Main(string[] args)
        {
            try{
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            int n;
            Console.Write("Nhập số nguyên dương n: ");
            n = int.Parse(Console.ReadLine());
            int Sumprime = SumPrime(n);

            Console.WriteLine("Tổng số nguyên tố < n: " + Sumprime);
            }
             catch (Exception ex) { 
       Console.WriteLine("Lỗi: "+ ex.Message);
 }
        }
    }
}

