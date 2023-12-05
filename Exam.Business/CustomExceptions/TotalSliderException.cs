using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.CustomExceptions
{
    
    public class TotalSliderException : Exception
    {
        public string Prop { get; set; }
        public TotalSliderException()
        {
        }

        public TotalSliderException(string prop , string? message) : base(message)
        {
            Prop = prop;
         
        }
    }
}
