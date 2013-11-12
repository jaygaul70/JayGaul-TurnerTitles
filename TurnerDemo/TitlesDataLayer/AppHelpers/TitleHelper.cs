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
        public List<MovieTitle> SearchTitles(string titleString, int pageStart, int pageSize)
        {
            return _titlebll.SearchTitles(titleString, pageStart, pageSize);
        }

        public MovieDetailsModel GetMovieDetails(int id)
        {
            return _titlebll.GetMovieDetails(id);
        }

        public List<StorylineModel> GetStoryTypes(int titleId)
        {
            return _titlebll.GetStoryTypes(titleId);
        }

        public string GetStoryline(int storyId)
        {
            return _titlebll.GetStoryline(storyId);
        }
    }
}
