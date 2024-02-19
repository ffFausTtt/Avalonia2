using System;
using System.Collections.Generic;
using System.Linq;
using AvaloniaTeachers.Models;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;

namespace AvaloniaTeachers.ViewModels
{
	public class ShowTeachersViewModel : ReactiveObject
	{
		public List<Teacher> TC => MainWindowViewModel.entity.Teachers.Include(x => x.IdGenderNavigation).Include(x => x.TeacherCurses).ThenInclude(x => x.IdCurseNavigation).Include(x => x.TeacherSubjects).ThenInclude(x => x.IdSubjectNavigation).ToList();
		
	}
}