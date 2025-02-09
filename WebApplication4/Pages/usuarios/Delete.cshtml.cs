using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.model;

namespace WebApplication4.Pages.usuarios
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication4.Data.WebApplication4Context _context;

        public DeleteModel(WebApplication4.Data.WebApplication4Context context)
        {
            _context = context;
        }

        [BindProperty]
        public usuario usuario { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.usuario.FirstOrDefaultAsync(m => m.id == id);

            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                usuario = usuario;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.usuario.FindAsync(id);
            if (usuario != null)
            {
                usuario = usuario;
                _context.usuario.Remove(usuario);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
