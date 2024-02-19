using System;
using System.Collections.Generic;

namespace AvaloniaTeachers.Models;

public partial class TeacherSubject
{
    public int IdTeacherSubjects { get; set; }

    public int IdTeacher { get; set; }

    public int IdSubject { get; set; }

    public virtual Subject IdSubjectNavigation { get; set; } = null!;

    public virtual Teacher IdTeacherNavigation { get; set; } = null!;
}
