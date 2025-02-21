namespace DoctorPatientProject.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
       
        public DateTime Dob { get; set; }
        public string? MobileNo { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}


