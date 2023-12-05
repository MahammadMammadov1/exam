using Exam.Core.Models;
using Exam.Core.Repostories;
using Exam.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.Repostories
{
    public class SliderRepository : GenericRepostory<Slider>, ISliderRepository
    {
        public SliderRepository(AppDbContext appDb) : base(appDb)
        {
        }
    }
}
