using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Phone iPhone1 = new iPhone("iPhone 12", 1000, "Một chiếc điện thoại tuyệt vời của Apple", "iOS", 800, 12, 2815);
            Phone iPhone2 = new iPhone("iPhone SE", 400, "Một chiếc điện thoại giá rẻ nhưng mạnh mẽ của Apple", "iOS", 500, 7, 1821);
            Phone Samsung1 = new Samsung("Galaxy S21", 1000, "Một chiếc điện thoại đỉnh cao của Samsung", "Android", 800, 6.2, 8);
            Phone Samsung2 = new Samsung("Galaxy A71", 600, "Một chiếc điện thoại giá rẻ nhưng có nhiều tính năng tốt của Samsung", "Android", 700, 6.7, 6);

            PhoneStore store = new PhoneStore();
            store.AddPhone(iPhone1);
            store.AddPhone(iPhone2);
            store.AddPhone(Samsung1);
            store.AddPhone(Samsung2);

            List<Phone> bestSellingPhones = new List<Phone>();
            bestSellingPhones = store.FindBestSellingPhone();
            Console.WriteLine("Điện thoại có doanh thu cao nhất là:");
            foreach (Phone phone in bestSellingPhones)
            {
                Console.WriteLine(phone.GetDetails());
            }

            double totalRevenue = store.CalculateTotalRevenue();
            Console.WriteLine("Tổng doanh thu của cửa hàng là: " + totalRevenue);
            Console.ReadLine();
        }

        abstract class Phone
        {
            private string name;
            private double price;
            private string description;
            private string os;
            private int sales;

            public Phone(string name, double price, string description, string os, int sales)
            {
                this.name = name;
                this.price = price;
                this.description = description;
                this.os = os;
                this.sales = sales;
            }

            public string GetName()
            {
                return name;
            }
            public double GetPrice()
            {
                return price;
            }

            public string GetDescription()
            {
                return description;
            }

            public string GetOS()
            {
                return os;
            }

            public int GetSales()
            {
                return sales;
            }
            public abstract string GetDetails();
        }

        class iPhone : Phone
        {
            private int camera;
            private int batteryCapacity;

            public iPhone(string name, double price, string description, string os, int sales, int camera, int batteryCapacity) : base(name, price, description, os, sales)
            {
                this.camera = camera;
                this.batteryCapacity = batteryCapacity;
            }

            public int GetCamera()
            {
                return camera;
            }

            public int GetBatteryCapacity()
            {
                return batteryCapacity;
            }
            public override string GetDetails()
            {
                return $"\nTên: {GetName()} \nGiá: {GetPrice()} \nMô tả: {GetDescription()}\nHệ điều hành: {GetOS()}\nĐã bán: {GetSales()}\nCamera: {GetCamera()}\nDung lượng pin: {GetBatteryCapacity()}";
            }
        }

        class Samsung : Phone
        {
            private double screenSize;
            private int ram;

            public Samsung(string name, double price, string description, string os, int sales, double screenSize, int ram) : base(name, price, description, os, sales)
            {
                this.screenSize = screenSize;
                this.ram = ram;
            }

            public double GetScreenSize()
            {
                return screenSize;
            }

            public int GetRam()
            {
                return ram;
            }
            public override string GetDetails()
            {
                return $"\nTên: {GetName()}\nGiá: {GetPrice()}\nMô tả: {GetDescription()}\nHệ điều hành: {GetOS()}\nĐã bán: {GetSales()}\nMàn hình: {GetScreenSize()}\nRAM: {GetRam()}";
            }
        }

        class PhoneStore
        {
            private List<Phone> phones = new List<Phone>();

            public void AddPhone(Phone phone)
            {
                phones.Add(phone);
            }

            public double CalculateTotalRevenue()
            {
                double totalRevenue = 0;
                foreach (Phone phone in phones)
                {
                    totalRevenue += phone.GetPrice() * phone.GetSales();
                }
                return totalRevenue;
            }

            public List<Phone> FindBestSellingPhone()
            {
                List<Phone> bestSellingPhones = new List<Phone>();
                double maxRevenue = 0;

                foreach (var phone in phones)
                {
                    double revenue = phone.GetPrice() * phone.GetSales();
                    if (revenue > maxRevenue)
                    {
                        bestSellingPhones.Clear();
                        bestSellingPhones.Add(phone);
                        maxRevenue = revenue;
                    }
                    else if (revenue == maxRevenue)
                    {
                        bestSellingPhones.Add(phone);
                    }
                }

                return bestSellingPhones;
            }
        }
    }
}

