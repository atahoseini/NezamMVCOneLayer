using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NezamMVCOneLayer.Models
{
    public partial class Elect
    {
        public int Id { get; set; }
        [Key]
        public int CandidId { get; set; }
        [Key]
        public int MemberId { get; set; }
        [StringLength(50)]
        public string Date { get; set; }
        [StringLength(50)]
        public string Time { get; set; }

        [ForeignKey(nameof(CandidId))]
        [InverseProperty(nameof(Models.Candid.Elects))]
        public virtual Candid Candid { get; set; }
        [ForeignKey(nameof(MemberId))]
        [InverseProperty(nameof(Models.Member.Elects))]
        public virtual Member Member { get; set; }
    }



}
