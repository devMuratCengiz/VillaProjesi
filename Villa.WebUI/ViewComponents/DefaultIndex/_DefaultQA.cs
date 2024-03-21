using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.QADtos;

namespace Villa.WebUI.ViewComponents.DefaultIndex
{
    public class _DefaultQA : ViewComponent
    {
        private readonly IQAService _qAService;
        private readonly IMapper _mapper;

        public _DefaultQA(IQAService qAService, IMapper mapper)
        {
            _qAService = qAService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _qAService.TGetListAsync();
            var qAList = _mapper.Map<List<ResultQADto>>(values);
            return View(qAList);
        }
    }
}
