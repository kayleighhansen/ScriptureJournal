using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScriptureJournal.Models
{
    public class Entry
    {
        public int ID { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
        public string Book { get; set; }
        public string Chapter { get; set; }
        public string Keyword { get; set; }
        public string Text { get; set; }
    }
}