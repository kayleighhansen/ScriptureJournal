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
        public string SearchString { get; set; }
        public SelectList Books { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Book { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> bookQuery = from m in _context.Entry
                                                orderby m.Book
                                                select m.Book;

            var entries = from m in _context.Entry
                        select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                entries = entries.Where(s => s.Book.Contains(SearchString));
            }
            
            // if (!string.IsNullOrEmpty(Book))
            // {
            //     entries = entries.Where(x => x.Book == Book);
            // }

            Books = new SelectList(await bookQuery.Distinct().ToListAsync());
            Entry = await entries.ToListAsync();
        }
    }
}
