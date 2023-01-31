using System;
using System.Collections.Generic;

namespace Token.Models
{
    public partial class Kategoriler
    {
        public Kategoriler()
        {
            Kitaplars = new HashSet<Kitaplar>();
        }

        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; } = null!;

        public virtual ICollection<Kitaplar> Kitaplars { get; set; }
    }
}
