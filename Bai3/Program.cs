using System;
using System.Globalization;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        CultureInfo viVN = new CultureInfo("vi-VN");
        Thread.CurrentThread.CurrentCulture = viVN;
        Thread.CurrentThread.CurrentUICulture = viVN;

        while (true)
        {
            DateTime now = DateTime.Now;

            string thu = viVN.DateTimeFormat.GetDayName(now.DayOfWeek);
            string ngay = now.ToString("d/M/yyyy");
            string gio = now.ToString("H:mm:ss");

            Console.WriteLine($"Thời gian hiện tại: {thu}, ngày {ngay}, thời gian: {gio}");

            Thread.Sleep(1000); 
        }
    }
}
