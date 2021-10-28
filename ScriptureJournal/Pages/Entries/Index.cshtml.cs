using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal.Models;

namespace ScriptureJournal.Pages.Entries
{
    public class IndexModel : PageModel
    {
        private readonly ScriptureJournalContext _context;

        public IndexModel(ScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Entry> Entry { get;set; }

        public async Task OnGetAsync()
        {
            Entry = await _context.Entry.ToListAsync();
        }
    }
}
