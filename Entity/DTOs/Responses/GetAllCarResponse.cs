using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Responses
{
    public class GetAllCarResponse : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }


        public List<CarImageDto> CarImages { get; set; }
    }

}
