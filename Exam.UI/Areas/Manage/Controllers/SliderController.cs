using Exam.Business.Services.Interfaces;
using Exam.Core.Models;
using Exam.Core.Repostories;
using Exam.Data.DAL;
using Exam.Data.Repostories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam.UI.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SliderController : Controller
    {
        
        private readonly ISliderService _sliderService;
        private readonly ISliderRepository _sliderRepository;

        public SliderController(AppDbContext appDb,ISliderService sliderService,ISliderRepository sliderRepository )
        {
            
            _sliderService = sliderService;
            _sliderRepository = sliderRepository;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _sliderRepository.Table.ToList();
            return View(sliders);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Slider slider)
        {
            if(!ModelState.IsValid) return View(); 
            if (slider == null)  return View();   
            await _sliderService.CreateAsync(slider);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var exist =await _sliderRepository.GetAsync(x=>x.Id == id);
            return View(exist);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Slider slider)
        {
            if (!ModelState.IsValid) return View();
            
            await _sliderService.UpdateAsync(slider);  

            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            var exist = await _sliderRepository.GetAsync(x => x.Id == id);
            if (exist == null) return NotFound();
             _sliderService.DeleteAsync(exist);
            return RedirectToAction("Index");
        }
    }
}
