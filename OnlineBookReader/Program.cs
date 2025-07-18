using OnlineBookReader;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true) {
            Console.WriteLine("1. Log in\n2. Sign up");
            Console.Write("Enter a choice: ");
            int choice1 = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("1.Admin user\n2.Customer user");
            Console.Write("Enter a choice: ");
 
            int choice2 = Convert.ToInt16(Console.ReadLine());

            if (choice1 == 1)
            {
                if (choice2 == 1)
                {
                    Admin_User admin = new Admin_User("", "");
                    admin.Log_in();
                }
                else if (choice2 == 2)
                {
                    Customer_User customer = new Customer_User("", "");
                    customer.Log_in();
                }
            }

            else if (choice1 == 2)
            {
                if (choice2 == 1)
                {
                    Admin_User admin = new Admin_User("", "");
                    admin.Sign_up();
                }
                else if (choice2 == 2)
                {
                    Customer_User customer = new Customer_User("", "");
                    customer.Sign_up();
                }
            }
            else
            {
                Console.Write("Enter a valid choice!");
                return;
            }


        }
        
    }
}