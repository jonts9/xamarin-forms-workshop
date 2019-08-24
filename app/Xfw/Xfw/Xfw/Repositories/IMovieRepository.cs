using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xfw.Api;
using Xfw.Models;

namespace Xfw.Repositories
{
    public interface IMovieRepository
    {
        Task<(string error, List<Movie>)> GetUpcoming();
    }

    public class MovieRepository : IMovieRepository
    {
        public readonly IMovieApi movieApi;
        public MovieRepository()
        {
            movieApi = RestService.For<IMovieApi>(AppConstants.API_ENDPOINT);
        }

        public async Task<(string error,List<Movie>)> GetUpcoming()
        {
            try
            {
                var response = await movieApi.GetUpcoming(AppConstants.API_KEY);

                if(response == null)
                    return ("falha", null);
                if (response.Movies.Count == 0)
                    return ("nenhum filme encontado", null);
                return (null, response.Movies);
            }
            catch (ApiException ex)
            {
                return (ex.Message, null);
            }
        }
    }
}
