using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext DataBase;

        [BindProperty]
        public Customer Customer { get; set; }

        [TempData]
        public string Message { get; set; }

        public CreateModel(AppDbContext DataBase) { this.DataBase = DataBase; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            DataBase.Customers.Add(Customer);
            await DataBase.SaveChangesAsync();
            Message = $"Customer '{Customer.Name}' added!!!";
            return RedirectToPage("/Index");
        }
    }
}