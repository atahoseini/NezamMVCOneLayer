using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NezamMVCOneLayer.Models
{
    public partial class Field
    {
        public Field()
        {
            Members = new HashSet<Member>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string FieldName { get; set; }

        [InverseProperty("Field")]
        public virtual ICollection<Member> Members { get; set; }
    }



}
