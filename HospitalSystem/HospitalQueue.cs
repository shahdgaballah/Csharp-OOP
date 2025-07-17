namespace HospitalSystem
{
    public class HospitalQueue
    {
        const int MAX_QUEUE = 5;
        public int Specialization { get; set; }

        Patient[] patients = new Patient[MAX_QUEUE]; //array to store patients of size 5
        int patients_count = 0;

        
        //add new patient
        public void Add_patient(Patient patient)
        {
            if (patients_count >= MAX_QUEUE)
            {
                Console.WriteLine("Sorry, we can’t add more patients for this specialization");
                return;
            }

            
            if (patient.Status == 1) { //urgent
                for(int i =patients_count -1; i>=0; i--)
                {
                    patients[i + 1] = patients[i];
                }
                patients[0] = patient;

            }
            else{ //regular
                patients[patients_count] = patient;
            }
            patients_count++;
           
        }

        //remove patient
        public void Remove_patient()
        {

            if (patients_count == 0)
            {
                Console.WriteLine("No patients at the moment. Have rest, Dr");
                return;
            }
            Console.WriteLine($"{patients[0].Name} go with the doctor");


            for (int i = 1; i < patients_count; i++)
            {
                patients[i - 1] = patients[i];
            }

            patients_count--;
        }

        public void Print_Queue()
        {
            if (patients_count == 0) return;
            else
            {
                Console.WriteLine($"There are {patients_count} in Specialization {Specialization}");
            }

            for(int i =0; i<patients_count; i++)
            {
                Console.WriteLine($"{patients[i].Name} {(patients[i].Status == 1 ? "urgent" : "regular")}");

            }
        }


    }
}
