using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otdelenie.Logic
{
    public class StudentElement
    {
        public string ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronom { get; set; }
        public string Serial { get; set; }
        public string Number { get; set; }
        public string Card { get; set; }
        public string Balance { get; set;}

        public string StatusS { get; set; }

        public StudentElement(string id, string lastname, string firstname, string patronom, string serial, string number, string card, string balance, string st)
        {
            this.ID = id;
            this.LastName = lastname;
            this.FirstName = firstname;
            this.Patronom = patronom;
            this.Serial = serial;
            this.Number = number;
            this.Card = card;
            this.Balance = balance;
            this.StatusS = st;
        }
    }
}
