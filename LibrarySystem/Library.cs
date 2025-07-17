
namespace LibrarySystem
{
    public class Library
    {
        #region Books
        static Book[] books = new Book[1000]; //an array to store books
        static int books_count = 0;
        #endregion

        #region Users
        static User[] users = new User[1000]; //an array to store users of size 1000

        static int users_count = 0; 
        #endregion

        //library menu
        public static void DisplayMenu()
        {
            Console.WriteLine("Library Menu:");
            Console.WriteLine("1. add book");
            Console.WriteLine("2. search books by prefix");
            Console.WriteLine("3. print who borrowed book by name");
            Console.WriteLine("4. print library by id");
            Console.WriteLine("5. print library by name");
            Console.WriteLine("6. add user");
            Console.WriteLine("7. user borrow book");
            Console.WriteLine("8. user return book");
            Console.WriteLine("9. print users");
            Console.WriteLine("10. Exit");
            Console.Write("Enter your choice [1-10]: ");
          
        }

        //add book
        public static void Add_book()
        {
            if (books_count > 1000) Console.WriteLine("Library is full. Cant add more books");

            Book book1 = new Book();

            Console.Write("Enter book info: Id, Name & Total Quantity: ");


            book1.Id = Convert.ToInt32(Console.ReadLine());
            book1.Name = Console.ReadLine();
            book1.Total_Quantity = Convert.ToInt32(Console.ReadLine());

            books[books_count] = book1;
            books_count++;
        }


        //search book by prefix
        public static void Search_books_by_prefix()
        {
            Console.Write("Enter book name prefix");
            string prefix = Console.ReadLine();
            bool flag = false;
            for (int i = 0; i < books_count; i++)
            {
                if (books[i] is not null && books[i].Name is not null && books[i].Name.StartsWith(prefix))
                {

                    Console.WriteLine(books[i]);
                    flag = true;
                }

            }
            if (!flag) Console.WriteLine("No Matching books");


        }


        //Print_who_borrowed_book_by_name
        public static void Print_who_borrowed_book_by_name()
        {
            Console.Write("Enter book name: ");
            string book_name = Console.ReadLine();

            int book_id = -1;

            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].Name == book_name )
                {
                    book_id = books[i].Id;
                    break;
                }
                
            }

            if (book_id == -1)
            {
                Console.WriteLine("Book not found");
                return;
            }

            bool flag = false;

            for (int i =0; i<users.Length; i++)
            {
                if (users[i].Is_borrowed(book_id))
                {
                    Console.WriteLine(users[i].Name);
                    flag = true;
                }
            }
            if (!flag)
            {
                Console.WriteLine("No user borrowed this book");
            }

        }

        //print lib by id
        public static void Print_library_by_id()
        {
            Book[] sortedBooks = new Book[books_count];


            for (int i = 0; i < books_count; i++) {
                sortedBooks[i] = books[i];

            }

            Array.Sort(sortedBooks, (a, b) => a.Id.CompareTo(b.Id));

            for (int i = 0; i < sortedBooks.Length; i++)
            {
                Console.WriteLine($"id={sortedBooks[i].Id}  name={sortedBooks[i].Name}  total quantity={sortedBooks[i].Total_Quantity}  total borrowed={sortedBooks[i].Total_Borrowed}");
            }
        }

        //print lib by name
        public  static void Print_library_by_name()
        {
            Book[] sortedBooks = new Book[books_count];


            for (int i = 0; i < books_count; i++)
            {
                sortedBooks[i] = books[i];

            }

            Array.Sort(sortedBooks, (a, b) => a.Name.CompareTo(b.Name));

            for (int i = 0; i < sortedBooks.Length; i++)
            {
                Console.WriteLine($"id={sortedBooks[i].Id}  name={sortedBooks[i].Name}  total quantity={sortedBooks[i].Total_Quantity}  total borrowed={sortedBooks[i].Total_Borrowed}");
            }
        }

        //add user
        public static void Add_user()
        {
            User user1 = new User();
            Console.Write("Enter username & national id: ");

            user1.Name = Console.ReadLine();
            user1.Id = Convert.ToInt32(Console.ReadLine());

            users[users_count] = user1;
            users_count++;

        }

        //user_borrow_book
        public static void User_borrow_book()
        {
            Console.Write("Enter username & bookname: ");
            string username = Console.ReadLine();
            string bookname = Console.ReadLine();

            int user_index = -1, book_index = -1;

            for (int i = 0; i < users_count; i++)
            {
                if (users[i].Name == username)
                {
                    user_index = i;
                    break;
                }
            }

            if (user_index == -1)
            {
                Console.WriteLine("User not found");
                return;
            }

            for (int i = 0; i < books_count; i++)
            {
                if (books[i].Name == bookname)
                {
                    book_index = i;
                    break;
                }
            }

            if (book_index == -1)
            {
                Console.WriteLine("Book not found");
                return;
            }

            if (!books[book_index].Borrow_book(users[user_index].Id))
            {
                Console.WriteLine("No more copies available");
                return;
            }

            users[user_index].Can_Borrow(books[book_index].Id);
        }

        //user return book
        public static void User_return_book()
        {
            Console.Write("Enter username & book name: ");
            string username = Console.ReadLine();
            string bookname = Console.ReadLine();

            int user_index = -1, book_index = -1;

            for(int i=0; i<users_count; i++)
            {
                if (users[i].Name == username)
                {
                    user_index = i;
                    break;
                } 
                
            }
            if (user_index == -1)
            {
                Console.WriteLine("User not found");
                return;
            }

            for (int i = 0; i < books_count; i++)
            {
                if (books[i].Name == bookname)
                {
                    book_index = i;
                    break;
                }
                
            }
            if (book_index == -1)
            {
                Console.WriteLine("Book not found");
                return;
            }

            int book_id = books[book_index].Id;
            if (!users[user_index].Is_borrowed(book_id))
            {
                Console.WriteLine("User never borrowed this book");
            }
            else
            {
                users[user_index].Return_book(book_id);
                books[book_index].Return_book();
            }
        }

        //print users
        public static void Print_users()
        {
            foreach (User user in users)
            {
                if (user == null) // Skip null users
                    continue;

                Console.Write($"User {user.Name} id={user.Id} borrowed books ids: ");

                if (user.borrowed_books_ids.Count() == 0)
                {
                    Console.WriteLine("None");
                }
                else
                {
                    for (int i = 0; i < user.borrowed_books_ids.Count(); i++)
                    {
                        Console.Write(user.borrowed_books_ids[i]);
                        if (i != user.borrowed_books_ids.Count() - 1)
                            Console.Write(", ");
                    }
                }
            }
        }

        public static void run()
        {

            while (true)
            {
                DisplayMenu();

                int choice = Convert.ToInt16(Console.ReadLine());
                if (choice < 1 || choice > 10)
                {
                    Console.WriteLine("Enter a choice between 1 & 10");
                    continue;
                }

                if (choice == 10) break;

                if (choice == 1) Add_book();
                else if (choice == 2) Search_books_by_prefix();
                else if (choice == 3) Console.WriteLine("who borrowed book by name");
                else if (choice == 4) Print_library_by_id();
                else if (choice == 5) Print_library_by_name();
                else if (choice == 6) Add_user();
                else if (choice == 7) User_borrow_book();
                else if (choice == 8) User_return_book();
                else if (choice == 9) Print_users();
            }
        }

         

            
           


    }
}





