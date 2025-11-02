
using Wolflix.Domain.Entities;
using Wolflix.Domain.Exceptions;

namespace Wolflix.Tests.Domain.Entity
{
    public class MovieUnitTest
    {


        [Fact(DisplayName = nameof(ShouldCreateValidMovie))]
        [Trait("Movie", "Aggregation")]
        public void ShouldCreateValidMovie()
        {
            var initialData = new
            {
                Title = "Cidade de Deus",
                Genre = "Drama",
                Rating = 4.9

            };
            var movie = new Movie(initialData.Title, initialData.Genre, initialData.Rating);
            Assert.NotNull(movie);
            Assert.Equal(initialData.Title, movie.Title);
            Assert.Equal(initialData.Genre, movie.Genre);
            Assert.Equal(initialData.Rating, movie.Rating);
        }

        [Fact(DisplayName = nameof(ShouldCreateValidMovieAndGenerateId))]
        [Trait("Movie","Aggregation")]
        public void ShouldCreateValidMovieAndGenerateId()
        {
            // Arrage
            var initialData = new
            {
                Title = "O grito",
                Genre = "Terror",
                Rating = 4.9

            };
            // Act
            var movie = new Movie(initialData.Title, initialData.Genre, initialData.Rating);
            // Assert
            Assert.NotEqual(default(Guid), movie.Id);
        }

        [Theory(DisplayName =nameof(ShouldThrowExceptionWhenSavingEmptyTitleMovie))]
        [Trait("Movie","Aggregation")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void ShouldThrowExceptionWhenSavingEmptyTitleMovie(string? title)
        {
           
            Action action = () => new Movie(title, "Teste de Descrição", 1.2);
            var exception = Assert.Throws<EntityValidRequest>(action);
            Assert.Equal("O título do filme é obrigatório.", exception.Message);

        }

        [Theory(DisplayName = nameof(ShouldThrowExceptionWhenSavingEmptyGenreMovie))]
        [Trait("Movie","Aggregation")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void ShouldThrowExceptionWhenSavingEmptyGenreMovie(string? genre)
        {
            Action action = () => new Movie("Interestelar", genre, 5.0);
            var exception = Assert.Throws<EntityValidRequest>(action);
            Assert.Equal("O gênero do filme é obrigatorio", exception.Message);
        }

        [Theory(DisplayName =nameof(ShouldCauseExceptionWhenSavingMovieWithRatingLessThan0))]
        [Trait("Movie","Aggregation")]
        [InlineData(-1.0)]
        [InlineData(-15.0)]
        [InlineData(-100.5)]
        public void ShouldCauseExceptionWhenSavingMovieWithRatingLessThan0(double rating)
        {
            Action action = () => new Movie("Invocação do Mal", "Terror", rating);
            var exception = Assert.Throws<EntityValidRequest>(action);
            Assert.Equal("A nota do filme deve ser maior do que 0", exception.Message);
        }

        [Theory(DisplayName = nameof(ShouldCauseExceptionWhenSavingMovieWithRatingHigherThan5))]
        [Trait("Movie","Aggregation")]
        [InlineData(6.0)]
        [InlineData(5.1)]
        [InlineData(10.2)]
        [InlineData(1000000.5)]
        public void ShouldCauseExceptionWhenSavingMovieWithRatingHigherThan5(double rating)
        {
            Action action = () => new Movie("Kong Fun Panda","Animação/Comédia",rating);
            var exception = Assert.Throws<EntityValidRequest>(action);
            Assert.Equal("A nota do filme deve ser menor do que 5", exception.Message);
        }


        [Theory(DisplayName =nameof(ShouldAcceptRatingOnLimits))]
        [Trait("Movie","Aggregation")]
        [InlineData(0.0)]
        [InlineData(5.0)]
        public void ShouldAcceptRatingOnLimits(double rating)
        {
            var movie = new Movie("Matrix", "Ficção Científica", rating);
            Assert.Equal(rating, movie.Rating);
        }

        [Fact(DisplayName = nameof(ShouldTrimTitleAndGenre))]
        [Trait("Movie","Aggregation")]
        public void ShouldTrimTitleAndGenre()
        {

            var movie = new Movie(" Batman ", " Ação ", 4.5);
            Assert.Equal("Batman", movie.Title);
            Assert.Equal("Ação", movie.Genre);

        }

    }
}
