using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static bool tvOn = false;
    static int currentChannel = 1;
    static bool eating = false;

    static async Task Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Bắt đầu nấu mì...");

        LayMiVaTo();

        Console.WriteLine("Bỏ mì vào tô...");
        await Task.Delay(1000);

        var taskNuoc = DunNuoc();

        var taskTrung = ChienTrung();

        var taskGiaVi = ChuanBiGiaVi();

        await taskNuoc;
        Console.WriteLine("Đổ nước sôi vào tô mì...");
        await Task.Delay(1000);

        Console.WriteLine("Chờ mì chín...");
        await Task.Delay(2000);

        await Task.WhenAll(taskTrung, taskGiaVi);

        Console.WriteLine("Mì đã sẵn sàng để thưởng thức!\n");

        eating = true;
        Task tvTask = DieuKhienTV();

        Console.WriteLine("Đang ăn mì... (Bấm B để bật/chuyển kênh TV, T để tắt TV)");

        await Task.Delay(10000); // Ăn mì trong 10 giây

        eating = false;

        if (tvOn)
        {
            Console.WriteLine("Ăn xong rồi! Tắt TV...");
            tvOn = false;
        }

        Console.WriteLine("Ăn mì xong! Kết thúc chương trình.");
    }

    static void LayMiVaTo()
    {
        Console.WriteLine("Lấy gói mì...");
        Thread.Sleep(500);
        Console.WriteLine("Lấy tô...");
        Thread.Sleep(500);
    }

    static async Task DunNuoc()
    {
        Console.WriteLine("Đun nước...");
        await Task.Delay(3000);
        Console.WriteLine("Nước đã sôi!");
    }

    static async Task ChienTrung()
    {
        Console.WriteLine("Chiên trứng...");
        await Task.Delay(2000);
        Console.WriteLine("Trứng chiên xong.");
    }

    static async Task ChuanBiGiaVi()
    {
        Console.WriteLine("Chuẩn bị rau củ...");
        await Task.Delay(2000);
        Console.WriteLine("Gia vị đã chuẩn bị xong.");
    }

    static async Task DieuKhienTV()
    {
        while (eating)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.B)
                {
                    if (!tvOn)
                    {
                        tvOn = true;
                        currentChannel = 1;
                        Console.WriteLine($"TV đã bật - Đang xem kênh {currentChannel}");
                    }
                    else
                    {
                        currentChannel++;
                        Console.WriteLine($"Chuyển sang kênh {currentChannel}");
                    }
                }
                else if (key.Key == ConsoleKey.T)
                {
                    if (!tvOn)
                    {
                        Console.WriteLine("TV đã tắt rồi!");
                    }
                    else
                    {
                        tvOn = false;
                        Console.WriteLine("TV đã được tắt");
                    }
                }
            }

            await Task.Delay(1000); 
        }
    }
}
