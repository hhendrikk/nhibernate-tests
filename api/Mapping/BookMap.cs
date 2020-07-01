using api.Entities;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;

namespace api.Mapping
{
    public class BookMap : SubclassMapping<Book>
    {
        public BookMap()
        {
            DiscriminatorValue(ProductType.Book);

            Property(p => p.Author, m =>
            {
                m.Column("author");
                m.Length(255);
                m.Type(NHibernateUtil.String);
            });

            Property(p => p.ISBN, m =>
            {
                m.Column("isbn");
                m.Length(255);
                m.Type(NHibernateUtil.String);
            });
        }
    }
}