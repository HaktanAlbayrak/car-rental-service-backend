using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car newCar = new Car
            {
                BrandId = 1,
                ColorId = 1,
                ModelYear = 2022,
                DailyPrice = 500,
                Description = "BMW"
            };

            carManager.Add(newCar);
            Console.WriteLine("\nAdded a new car:");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0} {1}", car.Description, car.ModelYear);
            }
        }
    }
}


