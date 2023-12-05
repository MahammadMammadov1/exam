using Exam.Core.Models;
using Exam.Core.Repostories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.Services.Interfaces
{
    public interface ISliderService
    {
        void DeleteAsync(Slider slider);
        Task CreateAsync(Slider slider);
        Task UpdateAsync(Slider slider);
        Task<List<Slider>> GetAll(Expression<Func<Slider, bool>>? expression = null, params string[]? include);
        Task<Slider> GetAsync(Expression<Func<Slider, bool>>? expression = null, params string[]? include);
    }
}
