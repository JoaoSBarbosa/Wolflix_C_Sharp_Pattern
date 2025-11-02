using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolflix.Domain.Exceptions;

namespace Wolflix.Domain.Entities
{
    public class Movie
    {

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Genre { get;  private set; }
        public double Rating { get; private set; }

        public Movie(string title, string genre, double rating)
        {
            Id = Guid.NewGuid();
            Title = title;
            Genre = genre;
            Rating = rating;
            validation();
        }


        private void validation ()
        {
            if (String.IsNullOrWhiteSpace(Title)) throw new EntityValidRequest("O título do filme é obrigatório.");
            if (String.IsNullOrWhiteSpace(Genre)) throw new EntityValidRequest("O gênero do filme é obrigatorio");
            if (Rating < 0) throw new EntityValidRequest("A nota do filme deve ser maior do que 0");
            if (Rating > 5) throw new EntityValidRequest("A nota do filme deve ser menor do que 5");
            Title = Title.Trim();
            Genre = Genre.Trim();
        }

    }
}
