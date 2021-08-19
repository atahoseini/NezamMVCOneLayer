using System.ComponentModel.DataAnnotations;

namespace NezamMVCOneLayer.Models
{
    public class test
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string city { get; set; }

        public string citieCodesss { get; set; }
    }

}
