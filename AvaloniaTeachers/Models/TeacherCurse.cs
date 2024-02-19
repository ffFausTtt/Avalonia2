using System;
using System.Collections.Generic;

namespace AvaloniaTeachers.Models;

public partial class TeacherCurse
{
    public int IdTeacherCurses { get; set; }

    public int IdTeacher { get; set; }

    public int IdCurse { get; set; }

    public int Hours { get; set; }

    public virtual Curse IdCurseNavigation { get; set; } = null!;

    public virtual Teacher IdTeacherNavigation { get; set; } = null!;
}
