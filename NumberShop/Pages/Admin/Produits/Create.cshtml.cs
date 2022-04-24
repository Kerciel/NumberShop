using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NumberShop.Data;
using NumberShop.Models;

namespace NumberShop.Pages.Admin.Produits
{
    public class CreateModel : PageModel
    {
        private readonly NumberShop.Data.DataContext _context;

        public CreateModel(NumberShop.Data.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Parfum Parfum { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Parfums.Add(Parfum);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
