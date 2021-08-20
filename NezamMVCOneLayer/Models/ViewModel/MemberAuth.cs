namespace NezamMVCOneLayer.Models
{
    public class MemberAuth
    {
        public int id { get; set; }

        public string FatherName { get; set; }
        public bool IsFather { get; set; }
        public string MotherName { get; set; }
        public bool IsMother { get; set; }
        public string ShSH { get; set; }
        public bool IsSHSH { get; set; }
    }
}
