namespace OnlineBookReader
{
    public class Customer_User: User
    {
        public override string ToString()
        {
            return $"Username = {Username}, Password = {Password}, Name = {Name}";

        }
        public Customer_User(string username, string password)
        {
            Username = username;
            Password = password;
            
        }

        //menu
        public void Customer_menu()
        {
            while (true) {
                Console.WriteLine("1. View Profile\n2. List all books \n3. View sessions\n4. Log out\n");
                Console.Write("Enter a choice: ");
                int choice = Convert.ToInt16(Console.ReadLine());
                if (choice == 1)
                {
                    View_profile();
                }
                else if (choice == 2)
                {
                    List_Books();
                }
                else if (choice == 3)
                {

                    View_sessions();
                }
                else if(choice == 4){
                    Log_out();
                    break;
                }
                else Console.Write("Enter a valid choice!");
            }
        }

        public static void List_Books()
        {
            if(Book.books_count == 0)
            {
                Console.WriteLine("No books available");
                return;
            }

            for(int i=0; i<Book.books_count; i++)
            {
                Console.Write(Book.books[i].ToString());
            }

        }
        public static void View_sessions()
        {
           // Console.WriteLine("view sessions");
        }


        }
}
