using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolflix.Domain.Entities;
using Wolflix.Domain.Exceptions;

namespace Wolflix.Tests.Domain.Entity
{
    public class UserUnitTest
    {

        [Fact(DisplayName = nameof(ShouldNotBeNullAfterSaving))]
        [Trait("User","Aggregation")]
        public void ShouldNotBeNullAfterSaving()
        {
            var initialData = new
            {
                Name = "João",
                Email = "contato@joao.com",
                FavoriteGenrer = "Terror"

            };
            var user = new User(initialData.Name, initialData.Email, initialData.FavoriteGenrer);

            Assert.NotNull(user);
            Assert.Equal(initialData.Name, user.Name);
            Assert.Equal(initialData.Email, user.Email);
        }

        [Fact(DisplayName = nameof(IDMustNotBeNullAfterCreation))]
        [Trait("User","Aggregation")]
        public void IDMustNotBeNullAfterCreation()
        {
            var initialData = new
            {
                Name = "Lucas",
                Email = "contato@lucas.com",
                FavoriteGenrer = "Terror"
            };

            var user = new User(initialData.Name, initialData.Email, initialData.FavoriteGenrer);
            Assert.NotEqual(default(Guid), user.Id);
        }

        [Theory(DisplayName =nameof(ShouldThrowExceptionWhenTryingSaveUserWithEmptyName))]
        [Trait("User","Aggregation")]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void ShouldThrowExceptionWhenTryingSaveUserWithEmptyName(string? name)
        {

            var email = "teste@teste";
            var favoriteGenre = "Terror";

            Action action = () => new User(name, email, favoriteGenre);
            var exception = Assert.Throws<EntityValidRequest>(action);
            Assert.Equal("O Nome é obrigatório", exception.Message);

        }

        [Theory(DisplayName = nameof(ShouldThrowExceptionWhentryingSaveUserWithEmptyEmail))]
        [Trait("User","Aggregation")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void ShouldThrowExceptionWhentryingSaveUserWithEmptyEmail(string? email)
        {
            var name = "Jonas";
            var favoriteGenre = "Terror";

            Action action = () => new User(name, email!, favoriteGenre);
            var exception = Assert.Throws<EntityValidRequest>(action);
            Assert.Equal("O E-mail é obrigatório", exception.Message);
        }

        [Theory(DisplayName = nameof(ShouldThrowExceptionWhenTryingSaveUserWithEmptyFavoriteGenrer))]
        [Trait("User", "Aggregation")]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void ShouldThrowExceptionWhenTryingSaveUserWithEmptyFavoriteGenrer(string? favoriteGenre)
        {

            var email = "teste@teste";
            var name = "Lucas";

            Action action = () => new User(name, email, favoriteGenre!);
            var exception = Assert.Throws<EntityValidRequest>(action);
            Assert.Equal("O gênero favorito é obrigatório.", exception.Message);

        }
    }
}
