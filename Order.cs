using System;
using System.Collections.Generic;

namespace WpfApp3;

public partial class Order
{
    public int Id { get; set; }

    public string IdUser { get; set; } = null!;

    public string Names { get; set; } = null!;

    public virtual Login IdUserNavigation { get; set; } = null!;
}
