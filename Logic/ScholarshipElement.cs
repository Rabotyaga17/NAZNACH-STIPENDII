using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otdelenie.Logic
{
    public class ScholarshipElement
    {
        public string ID_Vid { get; set; }
        public string Name_Scholarship { get; set; }
        public string Razmer { get; set; }
        public string ID_Scholarship { get; set; }
        public string Academic_Year { get; set; }
        public string ID_Semestr { get; set; }



        public ScholarshipElement(string id_vid, string name_scholarship, string razmer, string id_scholarship, string academic_year,string id_semestr)
        {
            this.ID_Vid = id_vid;
            this.Name_Scholarship = name_scholarship;
            this.Razmer = razmer;
            this.ID_Scholarship = id_scholarship;
            this.Academic_Year = academic_year;
            this.ID_Semestr = id_semestr;
        }
    
    }
}
