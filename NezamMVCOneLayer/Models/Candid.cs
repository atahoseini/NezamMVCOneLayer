using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NezamMVCOneLayer.Models
{
    public partial class Candid
    {
        public Candid()
        {
            Elects = new HashSet<Elect>();
        }

        [Key]
        public int Id { get; set; }
        public int? CandidCode { get; set; }
        [StringLength(50)]
        public string CodeMeli { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        public int? FiledId { get; set; }
        public int? CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty(nameof(Models.City.Candids))]
        public virtual City City { get; set; }
        [InverseProperty("Candid")]
        public virtual ICollection<Elect> Elects { get; set; }
    }
}
