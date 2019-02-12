using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Pages
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext DataBase;

        [BindProperty]
        public Customer Customer { get; set; }

        [TempData]
        public string Message { get; set; }

        public EditModel(AppDbContext DataBase) { this.DataBase = DataBase; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer = await DataBase.Customers.FindAsync(id);
            if (Customer == null)
                return RedirectToPage("/Index");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
                return Page();

            DataBase.Attach(Customer).State = EntityState.Modified;
            try
            {
                await DataBase.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Customer '{Customer.Name}' not found!!!");
            }
            Message = $"Customer '{Customer.Name}' edited!!!";
            return RedirectToPage("/Index");
        }
    }
}