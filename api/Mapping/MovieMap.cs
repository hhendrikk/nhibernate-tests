using api.Entities;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;

namespace api.Mapping
{
    public class MovieMap : SubclassMapping<Movie>
    {
        public MovieMap()
        {
            DiscriminatorValue(ProductType.Movie.GetHashCode());

            Property(p => p.Director, m =>
            {
                m.Column("director");
                m.Length(255);
                m.Type(NHibernateUtil.String);
            });
        }
    }
}