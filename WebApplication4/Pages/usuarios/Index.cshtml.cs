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
    public class IndexModel : PageModel
    {
        private readonly WebApplication4.Data.WebApplication4Context _context;

        public IndexModel(WebApplication4.Data.WebApplication4Context context)
        {
            _context = context;
        }

        public IList<usuario> usuario { get;set; } = default!;

        public async Task OnGetAsync()
        {
            usuario = await _context.usuario.ToListAsync();
        }
    }
}
