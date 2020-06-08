using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Otdelenie.Logic
{
    public static class ChequeBuilder
    {
        public static FlowDocument GetCheque()
        {
            FlowDocument doc = new FlowDocument
            {

                //Задаем белый фон
                Background = Brushes.White,

                //Задем красивый шрифт
                FontFamily = new FontFamily("Lucida Console"),

                //Задаем размер шрифта
                FontSize = 14,

                //Задем стиль шрифта
                FontStyle = FontStyles.Normal,

                //Устанавливаем ширину печатаемого документа
                PageWidth = 790,
                ColumnWidth = 790
            };

            #region Строковые шаблоны
            string hr = "------------------------------------------------------------------------------------------\n";    //90
            string hr2 = "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - \n";

            //Формирование шапки
            string up = hr;
            up += new string(' ',37) + "ВЫДАЧА СТИПЕНДИИ" + new string(' ', 37) + "\n";
            up += "\n";
            up += new string(' ', 34) + "ПЕРВЫЙ КАЗАЧИЙ КОЛЛЕДЖ" + new string(' ', 34) + "\n";
            up += hr2;

            string student = CurrentStudent.LastName + " " + CurrentStudent.FirstName + " " + CurrentStudent.Patronom;

            string bod = "\nСТУДЕНТ: " + student + "\n";

            bod += "\n";

            bod += "НОМЕР КАРТЫ СТУДЕНТА: " + CurrentStudent.CardID + "\n\n";

            bod += "БАЛАНС: "+ CurrentCheque.Balance + " ₽" + "\n\n";

            bod += "ВЫДАНО: " + CurrentCheque.Get + " ₽"+ "\n\n";

            bod += "ОСТАТОК НА СЧЕТЕ: "+ CurrentCheque.Ostatok + " ₽"+ "\n\n";

            string bot = "";

            bot += hr2 + "\n";

            bot += new string(' ', 41) + "СПАСИБО" + new string(' ', 42) + "\n\n";
            bot += hr;

            #endregion

            //Формируем параграфы
            Paragraph head = new Paragraph(new Run(up));
            Paragraph body = new Paragraph(new Run(bod));
            Paragraph bottom = new Paragraph(new Run(bot));

            //Все собираем вместе
            doc.Blocks.Add(head);
            doc.Blocks.Add(body);
            doc.Blocks.Add(bottom);


            return doc;
        }

    }
}
