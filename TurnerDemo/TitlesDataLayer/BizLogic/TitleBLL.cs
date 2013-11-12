using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TitlesModel;
using TitlesDataLayer.Entities;

namespace TitlesDataLayer.BizLogic
{
    internal class TitleBLL
    {
        private TitlesEntities db = new TitlesEntities();

        public TitleBLL()
        {
            
        }

        public List<MovieTitle> SearchTitles(string titleString, int pageStart, int pageSize)
        {
            var m = from t in db.Titles.Where(f => f.TitleName.StartsWith(titleString) || titleString == "" ).OrderBy(s => s.TitleNameSortable)
                         select new MovieTitle
                         {
                             TitleId = t.TitleId,
                             TitleName = t.TitleName,
                             ReleaseYear = t.ReleaseYear
                         };

            return m.ToList();
        }

        public MovieDetailsModel GetMovieDetails(int id)
        {
            //Include("TitleGenres").Include("Genres")
            var t = db.Titles.Include("Storylines").Include("TitleGenres.Genre").Include("TitleParticipants.Participant").Where(f => f.TitleId == id).FirstOrDefault();

            MovieDetailsModel m = new MovieDetailsModel();
            m.TitleId =  t.TitleId;
            m.TitleName = t.TitleName;
            m.ReleaseYear = t.ReleaseYear;
            m.Storylines = new List<StorylineModel>();
            t.StoryLines.ToList().ForEach(sl => m.Storylines.Add( new StorylineModel { slid = sl.Id, StoryType = sl.Type }));
            m.Genres = new List<MovieGenre>();
            t.TitleGenres.ToList().ForEach(tg => m.Genres.Add( new MovieGenre { id = tg.Genre.Id, Name = tg.Genre.Name }));
            m.Actors = new List<ActorModel>();
            t.TitleParticipants.Where(f => f.RoleType == "Actor").ToList().ForEach(tp => m.Actors.Add( new ActorModel { Name = tp.Participant.Name, RoleType = tp.RoleType }));
            m.Participants = new List<ParticipantModel>();
            t.TitleParticipants.Where(f => f.RoleType != "Actor").ToList().ForEach(tp => m.Participants.Add(new ParticipantModel { Name = tp.Participant.Name, RoleType = tp.RoleType }));

            m.Actors = m.Actors.OrderBy(s => s.Name).ToList();
            m.Participants = m.Participants.OrderBy(s => s.Name).ToList();

            return m;
        }

        internal List<StorylineModel> GetStoryTypes(int titleId)
        {
            List<StorylineModel> types = new List<StorylineModel>();
            db.StoryLines.Where(f => f.TitleId == titleId).ToList().ForEach(sl => types.Add(new StorylineModel { slid = sl.Id, StoryType = sl.Type }));
            return types;
        }

        internal string GetStoryline(int storyId)
        {
            return db.StoryLines.Where(s => s.Id == storyId).Select(f => f.Description).FirstOrDefault();
        }
    }
}
