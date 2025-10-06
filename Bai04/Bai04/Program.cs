using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bai04
{
    internal class Program
    {
        static bool kt_nhuan(int years)
        {
            return (years % 400 == 0) || (years % 4 == 0 && years % 100 != 0);
        }
        static int NgayTrongThang(int years, int month)
        {
            if (years <= 0)
            {
                return -1;
            }
            if (month < 1 || month > 12)
            {
                return -1;
            }
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                   
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    return (kt_nhuan(years) ? 29 : 28);
                  
                default:
                    return -1;
            }
        }
        static void Main(string[] args)
        {
            try{
                 Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Nhập tháng: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Nhập năm: ");
            int year = int.Parse(Console.ReadLine());
            int songay = NgayTrongThang(year, month);
            if (songay == -1)
            {
                Console.WriteLine($"{month}/{year} không hợp lệ!");
            }
            else
            {
                Console.WriteLine($"{month}/{year} có {songay} ngày!");
            }
            }
            catch (Exception ex) { 
       Console.WriteLine("Lỗi: "+ ex.Message);
 }   
        }
    }
}
