namespace api.Entities
{
    public class Movie : Product
    {
        public virtual string Director { get; protected set; }
        public override ProductType ProductType
        {
            get
            {
                return ProductType.Movie;
            }
        }

        protected Movie() { }

        public Movie(string name, string description, decimal unitPrice,
            string director)
            : base(name, description, unitPrice)
        {
            Director = director;
        }
    }
}