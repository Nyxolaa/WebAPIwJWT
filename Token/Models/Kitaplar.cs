using System;
using System.Collections.Generic;

namespace Token.Models
{
    public partial class Kitaplar
    {
        public int KitapId { get; set; }
        public string KitapAdi { get; set; } = null!;
        public int KategoriId { get; set; }
        public decimal Fiyat { get; set; }
        public string? KapakResmi { get; set; }

        public virtual Kategoriler Kategori { get; set; } = null!;
    }
}
