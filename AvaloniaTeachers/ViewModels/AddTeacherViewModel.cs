using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using AvaloniaTeachers.Models;
using ReactiveUI;

namespace AvaloniaTeachers.ViewModels
{
	public class AddTeacherViewModel : ReactiveObject
	{
		string fio;
		string mail;
		string phone;
        string experience;
		DateTime date = DateTime.Now;
        DateTime newdate = DateTime.Now;
        int gender = -1;
		List<string> selectedSubjects = new List<string>();	
		public string FIO { get => fio; set => fio = value; }
	public int Gender {get => gender; set => gender = value; }
		public string Date { get => date.ToString(); set => date = DateTime.Parse(value); }
		public string Mail { get => mail; set => mail = value; }
		public string Phone { get => phone; set => phone = value; }
        public string Exp { get => experience; set => experience = value; }
		public List<string> NewSubjects
		{
			get => MainWindowViewModel.entity.Subjects.Select(x=> x.Subject1).ToList();
		}
        public List<string> SelectedSubjects
        {
            get => selectedSubjects;
            set => this.RaiseAndSetIfChanged(ref selectedSubjects, value);
        }
        public string SelectedSubjectTeacher
        {
            get => null;
            set
            {
                selectedSubjects.Add(value);
                SelectedSubjects = new List<string>(SelectedSubjects);
            }

        }
        Canvas can;
        public Canvas Can
        {
            get => can;
            set => this.RaiseAndSetIfChanged(ref can, value);
        }
        public void AddNewTeacher()
		{

            if (FIO == null)
            {
                Canvas canvas = new Canvas()
                {
                    Width = 700,
                    Height = 50
                };
                TextBlock text = new TextBlock()
                {
                    Text = "Поле с ФИО обязательно для заполнения!",
                    FontSize = 25
                };
                canvas.Children.Add(text);
                Can = canvas;
            }
            else if (Gender == -1)
            {
                Canvas canvas = new Canvas()
                {
                    Width = 700,
                    Height = 50
                };
                TextBlock text = new TextBlock()
                {
                    Text = "Вы не выбрали пол преподавателя!",
                    FontSize = 25
                };
                canvas.Children.Add(text);
                Can = canvas;
            }
            else if (DateTime.Compare(DateTime.Now.Date.AddYears(-18), date.Date) < 0)
            {
                Canvas canvas = new Canvas()
                {
                    Width = 700,
                    Height = 50
                };
                TextBlock text = new TextBlock()
                {
                    Text = "Преподавателю не может быть меньше 18 лет!",
                    FontSize = 25
                };
                canvas.Children.Add(text);
                Can = canvas;
            }
            else if (Exp == null)
            {
                Canvas canvas = new Canvas()
                {
                    Width = 700,
                    Height = 50
                };
                TextBlock text = new TextBlock()
                {
                    Text = "Стаж обязателен!",
                    FontSize = 25
                };
                canvas.Children.Add(text);
                Can = canvas;
            }
            else if (Mail == null)
            {
                Canvas canvas = new Canvas()
                {
                    Width = 700,
                    Height = 50
                };
                TextBlock text = new TextBlock()
                {
                    Text = "Ввод электронной почты обязателен!",
                    FontSize = 25
                };
                canvas.Children.Add(text);
                Can = canvas;
            }
            else
            {
                string[] snl = FIO.Split(' ');
                Teacher newTeacher = new Teacher()
   {
       Surname = snl[0],
       Name = snl[1],
       Softname = snl[2],
       Birthday = DateOnly.FromDateTime(date),
       IdGender = gender+1,
       Experience = Convert.ToInt32(experience),
       EMail = mail,
       Phone = phone
   };
            MainWindowViewModel.entity.Teachers.Add(newTeacher);
            MainWindowViewModel.entity.SaveChanges();
                Canvas canvas = new Canvas()
                {
                    Width = 700,
                    Height = 50
                };
                TextBlock text = new TextBlock()
                {
                    Text = "Добавление преподавателя успешно",
                    FontSize = 25
                };
                canvas.Children.Add(text);
                Can = canvas;
                foreach (string s in selectedSubjects)
            {
                Subject sb = MainWindowViewModel.entity.Subjects.FirstOrDefault(x => x.Subject1 == s);
                if(sb != null)
                {
TeacherSubject TS = new TeacherSubject();
                    TS.IdSubject = sb.IdSubject;
                    TS.IdTeacher = newTeacher.IdTeacher;
                    MainWindowViewModel.entity.TeacherSubjects.Add(TS);
                        MainWindowViewModel.entity.SaveChanges();
                    }
                }
            }
        }
    }
}