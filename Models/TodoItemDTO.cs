using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace todoApi.Models
{
    public class TodoItemDTO
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DefaultValue(false)]
        public bool IsComplete { get; set; }
    }
}
