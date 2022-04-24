using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NumberShop.Data;
using NumberShop.Models;

namespace NumberShop.Pages.Admin.Produits
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public IList<Categories> categories { get; set; }
        private readonly NumberShop.Data.DataContext _context;

        public EditModel(NumberShop.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Parfum Parfum { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            categories = await _context.Categories.ToListAsync();
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Parfum).State = EntityState.Modified;
            
            string nomimage = HttpContext.Request.Form["ajoutimage"];
            if (nomimage != null)//verifie si elle est vide ou pas 
            {
                Debug.WriteLine(nomimage);
                Debug.WriteLine("c est bon !!!!!");
                //outImage("testdossier", nomimage);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParfumExists(Parfum.ParfumId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ParfumExists(int id)
        {
            return _context.Parfums.Any(e => e.ParfumId == id);
        }
        //ajoute une image dans un dossier 
        public void AjoutImage (string d, string image)
        {
            WebClient myWebClient = new WebClient();
            string pathString = "wwwroote/images/" + d;
         string fichier = System.IO.Path.Combine(pathString, image);
            //verifie si le dossier existe 
            if (!System.IO.File.Exists(pathString))
            {
                //creation d'un dossier et du fichier 
                System.IO.Directory.CreateDirectory(pathString);
                myWebClient.UploadFile(pathString,image);
                    Debug.WriteLine(" Creation du dosier reussi.");

                
            }
            else
            {
                Debug.WriteLine(" already exists.");
                return;
            }
        }
    }
}
