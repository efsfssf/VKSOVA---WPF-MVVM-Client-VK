using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF.Messages
{
    public class TextMessage : IMessage
    {
        public TextMessage(string text)
        {
            Text = text;
        }

        public string Text { get; set; }
    }
}
