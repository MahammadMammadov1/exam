using Exam.Business.CustomExceptions;
using Exam.Business.Services.Interfaces;
using Exam.Core.Models;
using Exam.Core.Repostories;
using Exam.Data.DAL;
using Exam.Data.Repostories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.Services.Implementations
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _sliderRepository;

        public SliderService(ISliderRepository sliderRepository) 
        {
            _sliderRepository = sliderRepository;
        }



        public async Task CreateAsync(Slider slider)
        {
            if (slider.FormFile != null)
            {
                string fileName = slider.FormFile.FileName;
                if (slider.FormFile.ContentType != "image/jpeg" && slider.FormFile.ContentType != "image/png")
                {
                    throw new TotalSliderException("FormFile", "pls add png or jpeg file");
                }

                if (slider.FormFile.Length > 2000000)
                {
                    throw new TotalSliderException("FormFile", "pls add lower than 2 mb");
                }

                if (slider.FormFile.FileName.Length > 64)
                {
                    fileName = fileName.Substring(fileName.Length - 64, 64);
                }

                fileName = Guid.NewGuid().ToString() + fileName;

                string path = "C:\\Users\\II Novbe\\Desktop\\TasksCode\\Exam\\Exam.UI\\wwwroot\\uploads\\sliders\\" + fileName;
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    slider.FormFile.CopyTo(fileStream);
                }
                slider.BackgroundImg = fileName;
            }
            else
            {
                throw new TotalSliderException("FormFile","image is required");
            }
            await _sliderRepository.CreateAsync(slider);
            await _sliderRepository.CommitAsync();

        }

        public void DeleteAsync(Slider slider)
        {
            slider.IsDeleted = true;
            _sliderRepository.CommitAsync();
        }

        public Task<List<Slider>> GetAll(Expression<Func<Slider, bool>>? expression = null, params string[]? include)
        {
            throw new NotImplementedException();
        }

        public Task<Slider> GetAsync(Expression<Func<Slider, bool>>? expression = null, params string[]? include)
        {
            throw new NotImplementedException();
        }

        public async  Task UpdateAsync(Slider slider)
        {
            var existslider =await _sliderRepository.GetAsync(x=>x.Id == slider.Id && x.IsDeleted == false);
            if (slider.FormFile != null)
            {
                string fileName = slider.FormFile.FileName;
                if (slider.FormFile.ContentType != "image/jpeg" && slider.FormFile.ContentType != "image/png")
                {
                    throw new TotalSliderException("FormFile", "pls add png or jpeg file");
                }

                if (slider.FormFile.Length > 2000000)
                {
                    throw new TotalSliderException("FormFile", "pls add lower than 2 mb");
                }

                if (slider.FormFile.FileName.Length > 64)
                {
                    fileName = fileName.Substring(fileName.Length - 64, 64);
                }

                fileName = Guid.NewGuid().ToString() + fileName;

                if (existslider.BackgroundImg != null)
                {
                    string path1 = "C:\\Users\\II Novbe\\Desktop\\TasksCode\\Exam\\Exam.UI\\wwwroot\\uploads\\sliders\\"  +existslider.BackgroundImg;

                    if (File.Exists(path1))
                    {
                        File.Delete(path1);
                    }
                }

                string path = "C:\\Users\\II Novbe\\Desktop\\TasksCode\\Exam\\Exam.UI\\wwwroot\\uploads\\sliders\\" + fileName;
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    slider.FormFile.CopyTo(fileStream);
                }
                slider.BackgroundImg = fileName;
            }

            existslider.Title = slider.Title;
            existslider.Description = slider.Description;
            existslider.ButtonText = slider.ButtonText;
            existslider.BackgroundImg = slider.BackgroundImg;
            existslider.RedirctUrl = slider.RedirctUrl;

            await _sliderRepository.CommitAsync();

        }
    }
}
