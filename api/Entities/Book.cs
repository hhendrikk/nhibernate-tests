namespace api.Entities
{
    public class Book : Product
    {
        public virtual string ISBN { get; protected set; }
        public virtual string Author { get; protected set; }
        public override ProductType ProductType
        {
            get
            {
                return ProductType.Book;
            }
        }

        protected Book() { }

        public Book(string name, string description, decimal unitPrice,
            string author, string isbn)
            : base(name, description, unitPrice)
        {
            Author = author;
            ISBN = isbn;
        }
    }
}