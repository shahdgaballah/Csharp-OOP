namespace OnlineBookReader
{
    public class Admin_User : User
    {
       
        public override string ToString()
        {
            return $"Username = {Username}, Password = {Password}, Name = {Name}";

        }
        public Admin_User(string username, string password)
        {
            Username = username;
            Password = password;
            
        }

        //menu
        public void Admin_menu()
        {
            while (true) {
                Console.WriteLine("1.View Profile\n2. Add Book\n3. Logout");
                Console.Write("Enter a choice: ");
                int choice = Convert.ToInt16(Console.ReadLine());
                if (choice == 1)
                {
                    View_profile();
                }
                else if (choice == 2)
                {
                    Add_books();
                }
                else if (choice == 3)
                {

                    Log_out();
                    break;
                }
                else Console.WriteLine("Enter a valid choice!");
            }
        }
        public void Add_books()
        {
            if (Book.books_count >= Book.MAX_BOOKS)
            {
                Console.Write("Can't add more books");
                return;
            }

            Console.Write("Enter book title and author: ");

            string title = Console.ReadLine();

            string author = Console.ReadLine();

            Book book1 = new Book(title, author);

            Book.books[Book.books_count] = book1;
            Book.books_count++;


        }
        

       

    }
}
