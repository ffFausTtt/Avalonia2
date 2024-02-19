using System;
using System.Collections.Generic;

namespace AvaloniaTeachers.Models;

public partial class Curse
{
    public int IdCurse { get; set; }

    public string Curse1 { get; set; } = null!;

    public virtual ICollection<TeacherCurse> TeacherCurses { get; set; } = new List<TeacherCurse>();
}
