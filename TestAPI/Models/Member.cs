namespace TestAPI.Models
{
    public class Member
    {

        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public string LastName { get; set; } = String.Empty;

        public string Barcode { get; set; } = String.Empty;

        public DateTime BirthDate { get; set; }


        public void Update(Member member)
        {
            Name = member.Name;
            LastName = member.LastName; 
            Barcode = member.Barcode;
            BirthDate = member.BirthDate;
        }
    
    }
}
