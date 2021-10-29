using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//using ScriptureJournal.Data;
using System;
using System.Linq;

namespace ScriptureJournal.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ScriptureJournalContext>>()))
            {
                // Look for any movies.
                if (context.Entry.Any())
                {
                    return;   // DB has been seeded
                }

                context.Entry.AddRange(
                    new Entry
                    {
                        DateAdded = DateTime.Parse("1989-2-12"),
                        Book = "Mosiah",
                        Chapter = "12",
                        Keyword = "Forgiveness",
                        Text = "This is the best chapter ever"
                    },
                    new Entry
                    {
                        DateAdded = DateTime.Parse("1989-2-12"),
                        Book = "Mosiah",
                        Chapter = "12",
                        Keyword = "Forgiveness",
                        Text = "This is the best chapter ever"
                    },
                    new Entry
                    {
                        DateAdded = DateTime.Parse("1989-2-12"),
                        Book = "Mosiah",
                        Chapter = "12",
                        Keyword = "Forgiveness",
                        Text = "This is the best chapter ever"
                    },
                    new Entry
                    {
                        DateAdded = DateTime.Parse("1989-2-12"),
                        Book = "Mosiah",
                        Chapter = "12",
                        Keyword = "Forgiveness",
                        Text = "This is the best chapter ever"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}