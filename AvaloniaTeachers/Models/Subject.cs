using System;
using System.Collections.Generic;

namespace AvaloniaTeachers.Models;

public partial class Subject
{
    public int IdSubject { get; set; }

    public string Subject1 { get; set; } = null!;

    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
}
