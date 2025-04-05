using System;
using System.Collections.Generic;

class PhanSo : IComparable<PhanSo>
{
    public int Tu { get; set; }
    public int Mau { get; set; }

    public PhanSo()
    {
        Tu = 0;
        Mau = 1;
    }

    public PhanSo(int tu, int mau)
    {
        if (mau == 0)
            throw new ArgumentException("Mau so phai khac 0!!!");
        Tu = tu;
        Mau = mau;
        RutGon();
    }

    public void Nhap()
    {
        Console.Write("Nhap tu so: ");
        Tu = int.Parse(Console.ReadLine());
        Console.Write("Nhap mau so: ");
        Mau = int.Parse(Console.ReadLine());
        if (Mau == 0) Mau = 1;
        RutGon();
    }

    public void Xuat()
    {
        Console.WriteLine($"{Tu}/{Mau}");
    }

    private int UCLN(int a, int b)
    {
        while (b != 0)
        {
            int r = a % b;
            a = b;
            b = r;
        }
        return Math.Abs(a);
    }

    public void RutGon()
    {
        int gcd = UCLN(Tu, Mau);
        Tu /= gcd;
        Mau /= gcd;
        if (Mau < 0)
        {
            Tu = -Tu;
            Mau = -Mau;
        }
    }
    public static PhanSo operator +(PhanSo a, PhanSo b) =>
        new PhanSo(a.Tu * b.Mau + b.Tu * a.Mau, a.Mau * b.Mau);

    public static PhanSo operator -(PhanSo a, PhanSo b) =>
        new PhanSo(a.Tu * b.Mau - b.Tu * a.Mau, a.Mau * b.Mau);

    public static PhanSo operator *(PhanSo a, PhanSo b) =>
        new PhanSo(a.Tu * b.Tu, a.Mau * b.Mau);

    public static PhanSo operator /(PhanSo a, PhanSo b)
    {
        if (b.Tu == 0)
            throw new DivideByZeroException("Khong the chia cho 0");
        return new PhanSo(a.Tu * b.Mau, a.Mau * b.Tu);
    }

    public int CompareTo(PhanSo other)
    {
        return (this.Tu * other.Mau).CompareTo(other.Tu * this.Mau);
    }

    public override string ToString()
    {
        return $"{Tu}/{Mau}";
    }
}

class Program
{
    static void Main()
    {
        List<PhanSo> ds = new List<PhanSo>();
        Console.Write("Nhap so luong phan so: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nPhan so thu {i + 1}:");
            PhanSo ps = new PhanSo();
            ps.Nhap();
            ds.Add(ps);
        }

        Console.WriteLine("\nDanh sach phan so sau rut gon:");
        ds.ForEach(p => p.Xuat());

        PhanSo tong = new PhanSo(0, 1);
        foreach (var p in ds)
            tong += p;

        Console.WriteLine($"\nTong cac phan so: {tong}");

        ds.Sort();
        Console.WriteLine("\nSap xep tang dan:");
        ds.ForEach(p => Console.WriteLine(p));

        ds.Sort((a, b) => b.CompareTo(a));
        Console.WriteLine("\nSap xep giam dan:");
        ds.ForEach(p => Console.WriteLine(p));
    }
}
