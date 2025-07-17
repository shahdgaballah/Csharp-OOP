namespace HospitalSystem
{
    public class Patient
    {
        public string? Name { get; set; }
        public int Status { get; set; } //regular = 0 , urgent = 1;
        public int Specialization { get; set; }
        public override string ToString()
        {
            return $"Name= {Name}, Status= {Status}";
        }

        public Patient(string name, int status, int spec)
        {
            Name = name;
            Status = status;
            Specialization = spec;
        }

    }
}
