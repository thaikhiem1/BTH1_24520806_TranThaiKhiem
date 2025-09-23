using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai05
{
    internal class Program
    {
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
            try
            {
                DateTime date = new DateTime(year, month, day);
                string[] ThuTrongTuan =
                {
                        "Chủ Nhật","Thứ Hai", "Thứ Ba", "Thứ Tư","Thứ Năm", "Thứ Sáu"
                    };
                string date1 = ThuTrongTuan[(int)(date.DayOfWeek)];
                Console.WriteLine($"{day}/{month}/{year} là {date1} trong tuần!");
            }
            catch
            {
                Console.WriteLine("Ngày tháng năm không hợp lệ!");
            }
        }
    }
}

