using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Core.Models
{
    public class Slider : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ButtonText { get; set; }

        public string BackgroundImg { get; set; }
        public string RedirctUrl { get; set; }
        [NotMapped]
        public IFormFile? FormFile { get; set; }    
    }
}
