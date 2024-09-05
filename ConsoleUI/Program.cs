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

            var result = carManager.GetAll();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0} {1}", car.Description, car.ModelYear);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }
    }
}


