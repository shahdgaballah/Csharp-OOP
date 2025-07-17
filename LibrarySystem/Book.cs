

using System.Numerics;

namespace LibrarySystem
{
   
    public class Book
    {

        public const int MAX_BORROWED = 100;
      
        public int Id { get; set; }

        public string? Name { get; set; }

        public int Total_Quantity { get; set; }
        public int Total_Borrowed { get; set; } = 0;

       
   

        public override string ToString()
        {
            return $"Id = {Id}, Name = {Name}, Total Quantity = {Total_Quantity}, Total Borrowed= {Total_Borrowed}";
        }

        public bool Borrow_book(int user_id)
        {
            if (Total_Quantity - Total_Borrowed > 0)
            {
                Total_Borrowed++;
                return true;
            }
            return false;
        }

        public void Return_book()
        {
            if (Total_Borrowed > 0) Total_Borrowed--;
        }

    }
}
