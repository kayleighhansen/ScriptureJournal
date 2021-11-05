using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


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

        [BindProperty(SupportsGet = true)]
        public string SearchStringBook { get; set; }
        public SelectList Books { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Book { get; set; }

        [BindProperty(SupportsGet = true)]        
        public string SearchStringText { get; set; }
        public SelectList Texts { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Text { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> bookQuery = from m in _context.Entry orderby m.Book select m.Book;

            var entries = from m in _context.Entry select m;

            if (!string.IsNullOrEmpty(SearchStringBook))
            {
                entries = entries.Where(s => s.Book.Contains(SearchStringBook));
            }

            Books = new SelectList(await bookQuery.Distinct().ToListAsync());
            Entry = await entries.ToListAsync();

            if (!string.IsNullOrEmpty(SearchStringText))
            {
                entries = entries.Where(s => s.Text.Contains(SearchStringText));
            }

            Texts = new SelectList(await bookQuery.Distinct().ToListAsync());
            Entry = await entries.ToListAsync();
        }
    }
}
