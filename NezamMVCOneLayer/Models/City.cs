using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NezamMVCOneLayer.Models
{
    public partial class City
    {
        public City()
        {
            Candids = new HashSet<Candid>();
            Members = new HashSet<Member>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string CityName { get; set; }

        [InverseProperty("City")]
        public virtual ICollection<Candid> Candids { get; set; }
        [InverseProperty("City")]
        public virtual ICollection<Member> Members { get; set; }
    }

}
