using System;
using System.Collections.Generic;

namespace WpfApp3;

public partial class Login
{
    public string Login1 { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Role { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role RoleNavigation { get; set; } = null!;
}
