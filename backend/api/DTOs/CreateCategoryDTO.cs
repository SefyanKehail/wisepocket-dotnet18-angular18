using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class CreateCategoryDTO
    {
        public int? UserId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}