using System.ComponentModel.DataAnnotations.Schema;

namespace TestAPI.Models
{
    public class Member
    {

        public long Id { get; set; }

        public int MemberNumber { get; set; }

        public string Name { get; set; } = String.Empty;

        public string LastName { get; set; } = String.Empty;

        public string Barcode { get; set; } = String.Empty;

        public DateTime BirthDate { get; set; }

        public int ClubId { get; set; }

        [ForeignKey("ClubId")]
        public Club Club { get; set; }

        public int Age 
        { 
            get 
            {
                return (DateTime.Now.Year - BirthDate.Year);
            } 
        }

        public void Update(Member member)
        {
            Name = member.Name;
            LastName = member.LastName; 
            Barcode = member.Barcode;
            BirthDate = member.BirthDate;
            MemberNumber = member.MemberNumber;
        }
    
    }
}
