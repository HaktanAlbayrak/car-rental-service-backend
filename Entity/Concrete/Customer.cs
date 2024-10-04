using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;

public class Customer : IEntity
{
    [Key, ForeignKey("User")]
    public int UserId { get; set; }
    public string CompanyName { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public User User { get; set; }
    public ICollection<Rental> Rentals { get; set; }  // Bir müşteri birden fazla kiralama yapabilir


}
