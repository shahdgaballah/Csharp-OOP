using System.Xml.Linq;

namespace OnlineBookReader
{
    public class User
    {
        const int MAX_USERS = 100;

      public static string[] admin_usernames = new string[MAX_USERS];
      public static string[] admin_passwords = new string[MAX_USERS];
      public static string[] admin_names = new string[MAX_USERS];
       
      public static int admin_count = 0;
       
      public static string[] customer_usernames = new string[MAX_USERS];
      public static string[] customer_passwords = new string[MAX_USERS];
      public static string[] customer_names = new string[MAX_USERS];
       
      public static int customer_count = 0;



        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? Name { get; set; }

        public override string ToString()
        {
            return $"Username = {Username}, Password = {Password}, Name = {Name}";
        }

        //login
        public virtual void Log_in()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            bool flag = false;
            for (int i = 0; i < admin_count; i++)
            {
                if (username == admin_usernames[i] && password == admin_passwords[i])
                {
                    Admin_User admin = new Admin_User(username, password);
                    admin.Admin_menu();
                    flag = true;
                    break;
                }
            }

            for (int i = 0; i < customer_count; i++)
            {

                if (username == customer_usernames[i] && password == customer_passwords[i])
                {
                    Customer_User customer = new Customer_User(username, password);

                    customer.Customer_menu();
                    flag = true;
                    break;
                }
            }
            if (!flag) Console.WriteLine("User is not registered. Sign up!");
        }

        //sign up
        public virtual void Sign_up()
        {
            Console.WriteLine("Sign up as:\n1. Admin user\n2. Customer User");
            Console.Write("Enter a choice: ");

            int choice = Convert.ToInt16(Console.ReadLine());
            if (choice == 1)
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine();

                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                Console.Write("Enter a name: ");
                string name = Console.ReadLine();

                Console.WriteLine("User registered. Login!");

                admin_usernames[admin_count] = username;
                admin_passwords[admin_count] = password;
                admin_names[admin_count] = name;
                admin_count++;


            }
            else if (choice == 2)
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine();

                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                Console.Write("Enter a name: ");
                string name = Console.ReadLine();

                Console.WriteLine("User registered. Log in!");
                customer_usernames[customer_count] = username;
                customer_passwords[customer_count] = password;
                customer_names[customer_count] = name;

                customer_count++;

            }
        }
        public static void Log_out()
        {
            Console.WriteLine("Logged out!");
            return;
            
        }
        public virtual void View_profile()
        {
            Console.WriteLine($"Name: {Name}\nUsername: {Username}\nPassword: {Password}");

        }
    }
}
