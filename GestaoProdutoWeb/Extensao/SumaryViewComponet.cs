using Microsoft.AspNetCore.Mvc;

namespace GestaoProduto.API.Extensao
{
    public class SumaryViewComponet : ViewComponent
    {
        public async Task<IViewComponentResult> TaksAsync()
        {
            return View();
        }
    }
}
