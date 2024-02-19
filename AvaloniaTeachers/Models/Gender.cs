using System;
using System.Collections.Generic;

namespace AvaloniaTeachers.Models;

public partial class Gender
{
    public int IdGender { get; set; }

    public string Gender1 { get; set; } = null!;

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
