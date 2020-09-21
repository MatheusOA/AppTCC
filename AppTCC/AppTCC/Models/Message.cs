using System;
using System.Collections.Generic;
using System.Text;

namespace AppTCC.Models
{
    public class Message
    {
        public string Text { get; set; }
        public DateTime MessageDateTime { get; set; }
        public bool IsTextIn { get; set; }
        public string TimeDisplay => MessageDateTime.ToLocalTime().ToString();
    }
}
