using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Business.Validators;
using Villa.Dto.Dtos.DealDtos;
using Villa.Dto.Dtos.QADtos;
using Villa.Entity.Entities;

namespace Villa.WebUI.Controllers
{
    public class QAController : Controller
    {
        private readonly IQAService _qAService;
        private readonly IMapper _mapper;

        public QAController(IQAService qAService, IMapper mapper)
        {
            _qAService = qAService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _qAService.TGetListAsync();
            var qAList = _mapper.Map<List<ResultQADto>>(values);
            return View(qAList);
        }

        public async Task<IActionResult> DeleteQA(ObjectId id)
        {
            await _qAService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateQA()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateQA(CreateQADto createQADto)
        {
            ModelState.Clear();
            var newQA = _mapper.Map<QA>(createQADto);
            var validator = new QAValidator();
            var result = validator.Validate(newQA);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }
            await _qAService.TCreateAsync(newQA);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateQA(ObjectId id)
        {
            var value = await _qAService.TGetByIdAsync(id);
            var updateQA = _mapper.Map<UpdateQADto>(value);
            return View(updateQA);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateQA(UpdateQADto updateQA)
        {
            ModelState.Clear();
            var qA = _mapper.Map<QA>(updateQA);
            var validator = new QAValidator();
            var result = validator.Validate(qA);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }
            await _qAService.TUpdateAsync(qA);
            return RedirectToAction("Index");
        }
    }
}
