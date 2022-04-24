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
    public class IndexModel : PageModel
    {
        private readonly NumberShop.Data.DataContext _context;

        public IndexModel(NumberShop.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Parfum> Parfum { get;set; }

        public async Task OnGetAsync()
        {
            Parfum = await _context.Parfums.ToListAsync();
        }
    }
}
