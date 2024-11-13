using Core.Entities;

namespace Entities.DTOs.Responses
{
    public class CarImageDto : IDto
    {
        public int CarId { get; set; }
        public string ImagePath { get; set; }
    }

}
