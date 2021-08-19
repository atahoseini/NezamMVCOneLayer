using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NezamMVCOneLayer.Models
{
    public partial class Member
    {
        public Member()
        {
            Elects = new HashSet<Elect>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string FatherFirstName { get; set; }
        [StringLength(50)]
        public string FatherLastName { get; set; }
        [StringLength(50)]
        public string MotherFirstName { get; set; }
        [StringLength(50)]
        public string MotherLastName { get; set; }
        [StringLength(50)]
        public string Shsh { get; set; }
        [StringLength(50)]
        public string CodeMeli { get; set; }
        public int Byear { get; set; }
        public int Bmonth { get; set; }

        [StringLength(50)]
        public string CityBorn { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [StringLength(15)]
        public string Parvandeh { get; set; }

        [StringLength(50)]
        public string Ozviat { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public int? CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public  City City { get; set; }

        public int  FieldId { get; set; }
        [ForeignKey(nameof(FieldId))]
        public Field Field { get; set; }

        public virtual ICollection<Elect> Elects { get; set; }
    }



}
