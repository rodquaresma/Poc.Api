using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocApi.DTOs
{
    public class OrderDTO : BaseDTO
    {
        public int UserId { get; set; }
        public UserDTO UserDTO { get; set; } = default!;
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string Description { get; set; } = default!;
    }
}
