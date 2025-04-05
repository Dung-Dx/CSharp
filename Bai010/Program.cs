using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Nhập giá trị x: ");
        double x = Convert.ToDouble(Console.ReadLine());

        Console.Write("Nhập giá trị n: ");
        int n = Convert.ToInt32(Console.ReadLine());

        double S = 0;

        for (int i = 1; i <= n; i++)
        {
            if (i % 2 != 0)
            {
                S += Math.Pow(x, i);
            }
            else
            {
                S -= Math.Pow(x, i); // -x^i
            }
        }

        Console.WriteLine($"Tổng S = {S}");
    }
}
