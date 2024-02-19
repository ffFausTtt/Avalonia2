using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using AvaloniaTeachers.Models;
using ReactiveUI;

namespace AvaloniaTeachers.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public static Mdk0101Context entity = new Mdk0101Context();
        UserControl us = new Views.ShowTeachers();
        public UserControl US
        {
            get => us;
            set => this.RaiseAndSetIfChanged(ref us, value);
        }
        ShowTeachersViewModel showTeachersVM = new ShowTeachersViewModel();
        public ShowTeachersViewModel ShowTeachersVM
        {
            get => showTeachersVM;
            set => showTeachersVM = value;
        }
        AddTeacherViewModel addTeacherVM = new AddTeacherViewModel();
        public AddTeacherViewModel AddTeacherVM
        {
            get => addTeacherVM;
            set => addTeacherVM = value;
        }
        public void NewTeacherPage()
        {
            US = new Views.AddTeacher();
        }
        public void NewShowTeachers()
        {
            US = new Views.ShowTeachers();
        }
    }
}
