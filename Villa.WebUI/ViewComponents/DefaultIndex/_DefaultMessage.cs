using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;

namespace Villa.WebUI.ViewComponents.DefaultIndex
{
    public class _DefaultMessage : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
