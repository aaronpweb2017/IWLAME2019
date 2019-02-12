using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        private readonly AppDbContext DataBase;

        public IndexModel(AppDbContext DataBase)
        {
            this.DataBase = DataBase;
        }

        public IList<Customer> Customers { get; private set; }

        public async Task OnGetAsync() //async --> to avoid bottlenecks:
        {
            Customers = await DataBase.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var Customer = await DataBase.Customers.FindAsync(id);
            if (Customer != null)
            {
                DataBase.Customers.Remove(Customer);
                await DataBase.SaveChangesAsync();
                Message = $"Customer '{Customer.Name}' deleted!!!";
            }
            return RedirectToPage();
        }
    }
}