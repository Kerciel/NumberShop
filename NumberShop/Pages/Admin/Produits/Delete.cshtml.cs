using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NumberShop.Data;
using NumberShop.Models;

namespace NumberShop.Pages.Admin.Produits
{
    public class DeleteModel : PageModel
    {
        private readonly NumberShop.Data.DataContext _context;

        public DeleteModel(NumberShop.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Parfum Parfum { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Parfum = await _context.Parfums.FirstOrDefaultAsync(m => m.ParfumId == id);

            if (Parfum == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Parfum = await _context.Parfums.FindAsync(id);

            if (Parfum != null)
            {
                _context.Parfums.Remove(Parfum);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
