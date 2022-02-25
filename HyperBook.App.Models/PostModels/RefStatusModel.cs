using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperBook.App.Models.PostModels
{
    public class RefStatusModel
    {
        [Required]
        public string Description { get; set; }
    }
}
