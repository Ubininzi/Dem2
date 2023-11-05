using System;
using System.Collections.Generic;

namespace WpfApp3;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Author { get; set; } = null!;

    public decimal? Price { get; set; }

    public string? Desciption { get; set; }

    public string? PathToImage { get; set; }
}
