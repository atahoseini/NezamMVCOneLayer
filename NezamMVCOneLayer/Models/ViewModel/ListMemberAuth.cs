using System.Collections.Generic;

namespace NezamMVCOneLayer.Models
{
    public class ListMemberAuth
    {
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string ShSH { get; set; }
        public List<MemberAuth> MemberAuth { get; set; }
    }
}
