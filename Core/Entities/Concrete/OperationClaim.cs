using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete;

public class OperationClaim : IEntity
{
    [Key]
    public int Id { get; set; }
    [MaxLength(250)]
    public string Name { get; set; }

    public ICollection<UserOperationClaim> UserOperationClaims { get; set; }
}
