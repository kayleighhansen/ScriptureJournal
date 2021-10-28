using System;
using System.ComponentModel.DataAnnotations;

namespace ScriptureJournal.Models
{
    public class Entry
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
        public string Book { get; set; }
        public string Chapter { get; set; }
        public string Keyword { get; set; }
        public string Text { get; set; }
    }
}