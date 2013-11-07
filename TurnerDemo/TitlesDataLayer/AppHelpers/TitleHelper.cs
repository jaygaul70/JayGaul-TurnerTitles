using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TitlesModel;
using TitlesDataLayer.BizLogic;

namespace TitlesDataLayer.AppHelpers
{
    public class TitleHelper
    {
        private TitleBLL _titlebll = new TitleBLL();
        public List<MovieTitle> SearchMovies(string titleString, int pageStart, int pageSize)
        {
            return _titlebll.SearchMovies(titleString, pageStart, pageSize);
        }

        public MovieDetailsModel GetMovieDetails(int id)
        {
            return _titlebll.GetMovieDetails(id);
        }

        public string GetStoryline(int storyId)
        {
            return _titlebll.GetStoryline(storyId);
        }
    }
}
