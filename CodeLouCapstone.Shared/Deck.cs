using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLouCapstone.Shared
{
    public class Deck
    {
        public int DeckId { get; set; }

        public List<string> Cards { get; set; }

        public string DeckName { get; set; }
    }
}
