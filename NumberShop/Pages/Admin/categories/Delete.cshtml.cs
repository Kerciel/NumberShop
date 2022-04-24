using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NumberShop.Data;
using NumberShop.Models;

namespace NumberShop.Pages.Admin.categories
{
    public class DeleteModel : PageModel
    {
        private readonly NumberShop.Data.DataContext _context;

        public DeleteModel(NumberShop.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Categories Categories { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Categories = await _context.Categories.FirstOrDefaultAsync(m => m.IdCategorie == id);

            if (Categories == null)
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

            Categories = await _context.Categories.FindAsync(id);

            if (Categories != null)
            {
                _context.Categories.Remove(Categories);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
