using BlockBaster.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Data.Repositories.Abstract
{
    public interface IUserMovieRepository
    {
        IQueryable<UserMovie> GetUserMovies();
        UserMovie GetUserMovieById(int id);
        void SaveUserMovie(UserMovie entity);
        void DeleteUserMovie(int id);
    }
}
