using Wolflix.Domain.Entities;

namespace Wolflix.Domain.Strategies
{
    public interface IRecomendationStrategy
    {

        List<Movie> Recommend(User user, List<Movie> allMovies);


    }
}
