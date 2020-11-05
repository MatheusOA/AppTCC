using System;
using System.Collections.Generic;
using System.Text;

namespace AppTCC.Models
{
    public class UserMessage
    {
        public string Text { get; set; }
        public DateTime MessageDateTime { get; set; }
        public bool IsAuthor { get; set; }
    }
}
