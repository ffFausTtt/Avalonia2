using System;
using System.Collections.Generic;

namespace AvaloniaTeachers.Models;

public partial class Teacher
{
    public int IdTeacher { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Softname { get; set; }

    public int IdGender { get; set; }

    public DateOnly Birthday { get; set; }

    public int Experience { get; set; }

    public string EMail { get; set; } = null!;

    public string? Phone { get; set; }

    public virtual Gender IdGenderNavigation { get; set; } = null!;

    public virtual ICollection<TeacherCurse> TeacherCurses { get; set; } = new List<TeacherCurse>();

    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
}
