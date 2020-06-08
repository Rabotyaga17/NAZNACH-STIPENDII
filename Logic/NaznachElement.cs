using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otdelenie.Logic
{
     public class NaznachElement
    {
        public string ID_Student { get; set; }
        public string ID_Semestr { get; set; }
        public string Date_Viplat { get; set; }
        public string Date_Nznacheniya { get; set; }
        public string ID_Vid { get; set; }



        public NaznachElement(string id_student, string id_semester, string data_viplat, string data_nznach, string id_vid)
        {
            this.ID_Student = id_student;
            this.ID_Semestr = id_semester;
            this.Date_Viplat = data_viplat;
            this.Date_Nznacheniya = data_nznach;
            this.ID_Vid = id_vid;

        }
    }
}
