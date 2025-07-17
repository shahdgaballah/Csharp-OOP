

namespace LibrarySystem
{
    public class User
    {
        static User[] users = new User[1000]; //an array to store users of size 1000

        static int users_count = 0;

        public const int MAX_BORROWED = 100;

        public int[] borrowed_books_ids = new int[MAX_BORROWED]; //array to store borrowed books of size 100
        public  int borrowed_count = 0;

        public int Id { get; set; }
        public string? Name { get; set; }


        public override string ToString()
        {
            return $"Id = {Id}, Name = {Name}";
        }

       
        public void Can_Borrow(int book_id)
        {
            
           if (borrowed_count < MAX_BORROWED)
            {
                borrowed_books_ids[borrowed_count] = book_id;
                borrowed_count++;

            }
           else Console.WriteLine($"Borrow limit reached for user {Name}");
           

        }

        public bool Is_borrowed(int book_id)
        {
            foreach(var id in borrowed_books_ids)
            {
                if (book_id == id) return true;
            }
            return false;
        }

        public void Return_book(int book_id)
        {
            for (int i = 0; i < borrowed_count; i++)
            {
                if (borrowed_books_ids[i] == book_id)
                {
                    for (int j = i; j < borrowed_count - 1; j++)
                    {
                        borrowed_books_ids[j] = borrowed_books_ids[j + 1];
                    }
                    borrowed_books_ids[borrowed_count - 1] = 0;
                    borrowed_count--;
                    return;
                }
                
            }
            Console.WriteLine("User never borrowed this book");


        }




    }
}
