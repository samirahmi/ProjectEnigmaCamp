﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4_EnigpusKakRifqi.Models
{
    public class Novel :Book
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }
        public string Author { get; set; }

        public override string GetTitle()
        {
            return Title;
        }
        public override string ToString()
        {
            return $"Type: {nameof(Novel)} {nameof(Code)}: {Code}, {nameof(Title)}: {Title}, " +
                $"{nameof(Publisher)}: {Publisher}, {nameof(PublicationYear)}: {PublicationYear}, " +
                $"{nameof(Author)}: {Author}";
        }
    }
}
