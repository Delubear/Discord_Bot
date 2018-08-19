using System;
using System.Collections.Generic;
using System.Text;

namespace Discord_Bot.Models
{
    class SarahsItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TypeOfItem { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateCompleted { get; set; }
    }
}
