using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP3WinForms
{
    class Email : IComparable<Email>
    {
        public int Nr { get; set; }
        public String Sender { get; set; }
        public String Text { get; set; }

        public int CompareTo(Email other)
        {
            return this.Nr.CompareTo(other.Nr);
        }
    }
}
