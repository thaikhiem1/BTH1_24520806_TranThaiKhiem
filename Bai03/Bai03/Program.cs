using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bai03
{
    internal class Program
    {
        static bool kt_nhuan(int years)
        {
            return (years % 400 == 0) || (years % 4 == 0 && years % 100 != 0);
        }
        static bool NgayHopLe(int days, int month, int years)
        {
            if (years <= 0)
            {
                return false;
            }
            if (month < 1 || month > 12)
            {
                return false;
            }
            int daysinmonth;
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    daysinmonth = 31;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    daysinmonth = 30;
                    break;
                case 2:
                    daysinmonth = (kt_nhuan(years)) ? 29 : 28;
                    break;
                default:
                    return false;
            }
            return (days >= 1 && days <= daysinmonth);
        }
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Nhập ngày: ");
            int day = int.Parse(Console.ReadLine());

            Console.Write("Nhập tháng: ");
            int month = int.Parse(Console.ReadLine());

            Console.Write("Nhập năm: ");
            int year = int.Parse(Console.ReadLine());
            if (NgayHopLe(day, month, year))
                Console.WriteLine($"Ngày {day}/{month}/{year} hợp lệ");
            else
                Console.WriteLine($"Ngày {day}/{month}/{year} không hợp lệ");
        }
    }

}
