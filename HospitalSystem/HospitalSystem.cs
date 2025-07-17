namespace HospitalSystem
{
    public class HospitalSystem
    {
     
        const int MAX_PATIENTS = 1000;

        static Patient[] patients = new Patient[MAX_PATIENTS]; //an array to store patients of size 1000

        static int patients_count = 0;

        public const int MAX_SPECIALIZATION = 20;

       static HospitalQueue[] queues = new HospitalQueue[MAX_SPECIALIZATION];

        //menu
        public static void DisplayMenu()
        {
            Console.WriteLine("1. Add new patient");
            Console.WriteLine("2. Print all patients");
            Console.WriteLine("3. Get next patient");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            


        }

        //add new patient
        public static void Add_new_patient()
        {
            if (patients_count >= MAX_PATIENTS)
            {
                Console.WriteLine("Hospital is full. Cant add more patients");
                return;
            }
            Console.Write("Enter specialization, name, status: ");

            int spec = Convert.ToInt16(Console.ReadLine());
            string name = Console.ReadLine();
            int status = Convert.ToInt16(Console.ReadLine());

            if (spec < 1 || spec > MAX_SPECIALIZATION)
            {
                Console.WriteLine("Invalid specialization.");
                return;
            }

            Patient patient = new Patient(name, status, spec);
            queues[spec - 1].Add_patient(patient);

        }

        //print patients
        public static void Print_patients()
        {
            for (int i = 0; i < MAX_SPECIALIZATION; i++)
            {
                queues[i].Print_Queue();
            }
        }

        //Get next patient
        public static void Get_next_patient()
        {
            Console.Write("Enter specialization: ");
            int spec = Convert.ToInt16(Console.ReadLine());

            if (spec < 1 || spec > MAX_SPECIALIZATION)
            {
                Console.WriteLine("Invalid specialization.");
                return;
            }

            queues[spec - 1].Remove_patient();
        }
        public static void run()
        {
            for (int i = 0; i < MAX_SPECIALIZATION; i++)
            {
                queues[i] = new HospitalQueue { Specialization = i + 1 };
            }

            while (true)
            {
                DisplayMenu();

                int choice = Convert.ToInt16(Console.ReadLine());
                if (choice < 1 || choice > 4)
                {
                    Console.WriteLine("Enter a choice between 1 & 4");
                    continue;
                }

                if (choice == 4) break;

                if (choice == 1) Add_new_patient();
                else if (choice == 2) Print_patients();
                else if (choice == 3) Get_next_patient();
            }

        }
    }
}
