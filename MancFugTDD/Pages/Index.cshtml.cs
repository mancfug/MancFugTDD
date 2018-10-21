using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MancFugTDD.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Code { get; set; }
        [BindProperty]
        public string Quantity { get; set; }
        [BindProperty]
        public Domain.BasketItemView[] Items {get;set;}

        public void OnGet()
        {
            Items = new Domain.BasketItemView[0];
        }

        public void OnPost()
        {
        }
    }
}
