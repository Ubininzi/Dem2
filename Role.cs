using System;
using System.Collections.Generic;

namespace WpfApp3;

public partial class Role
{
    public int Id { get; set; }

    public string Rolename { get; set; } = null!;

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();
}
