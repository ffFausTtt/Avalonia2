using Avalonia.Controls.Shapes;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaTeachers.Models
{
    public partial class Teacher
    {
        public string FIO
        {
            get
            {
                return Surname + " " + Name + " " + Softname;
            }
        }
        public string GND
        {
            get
            {
                switch (IdGenderNavigation.IdGender)
                {
                    case 1: return "Пол: мужской";
                    case 2: return "Пол: женский";
                }
                return "Пол не определён";
            }
        }
        public string Date
        {
            get
            {
                return Convert.ToString("Дата рождения: " + Birthday + " года");
            }
        }
        public string EXP
        {
            get
            {
                int year;
                int month;
                year = Experience / 12;
                month = Experience % 12;
                return Convert.ToString("Стаж работы: " + year + " года " + month + " месяцев");
            }
        }
        public string Mail
        {
            get
            {
                return "Почта: " + EMail;
            }
        }
        public string PHN
        {
            get
            {
                if(Phone != null || Phone != "NULL")
                {
return "Телефон: " + Phone;
                }
                else
                {
                    return "Номер телефона не указан";
                }
            }
        }
        public string SBJ
        {
            get
            {
                string sb = "";
                foreach(var item in TeacherSubjects)
                {
                    sb += "-" + item.IdSubjectNavigation.Subject1 + "\n";
                }
                sb += (sb == "") ? "Предметов нет" : "";
                return sb;
            }
        }
        public string Curse
        {
            get
            {
                string s = "";
                int hours = 0;

                foreach (var item in TeacherCurses)
                {
                   
s += "-" + item.IdCurseNavigation.Curse1 + "\n";
                    hours += item.Hours;
                }
                s += "Общий объём курсов в часах: " + hours;
                s += (s == "") ? "Пройденных курсов нет" : "";
                return s;
            }
        }
    }

}
