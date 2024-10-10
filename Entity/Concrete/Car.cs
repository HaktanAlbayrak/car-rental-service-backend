using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;

public class Car : BaseEntity, IEntity
{
    public int UserId { get; set; }
    public int BrandId { get; set; }
    public int ColorId { get; set; }
    public int ModelYear { get; set; }
    public decimal DailyPrice { get; set; }
    public string Description { get; set; }

    public Brand Brand { get; set; }
    public Color Color { get; set; }
    public Rental Rental { get; set; }

    public ICollection<CarImage> CarImages { get; set; }
}
