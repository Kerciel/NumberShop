using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NumberShop.Data;
using NumberShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberShop.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        DataContext dataContext;
        public PrivacyModel(ILogger<PrivacyModel> logger, DataContext dataContext)
        {
            _logger = logger;
            this.dataContext = dataContext;
        }

        public void OnGet()
        {
            var categories = new Categories() { CategorieName = "Parfum"};
            dataContext.Categories.Add(categories);
            dataContext.SaveChanges();

            var parfum = new Parfum() { nom="fdgdfgfhfnfn", prix=50 };
            dataContext.Parfums.Add(parfum);
            dataContext.SaveChanges();
        }
    }
}
