using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TitlesModel
{
    public class MovieTitle
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; }
        public string TitleNameSortable { get; set; }
        public int? ReleaseYear { get; set; }
    }

    public class MovieTitlesPagedModel
    {
        public List<MovieTitle> MovieTitles { get; set; }
        public int PageSize { get; set; }
        public int TotalRows { get; set; }
    }

    public class MovieDetailsModel
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; }
        public string TitleNameSortable { get; set; }
        [Display(Name="Release Year")]
        public int? ReleaseYear { get; set; }

        public List<StorylineModel> Storylines { get; set; }
        public List<MovieGenre> Genres { get; set; }
        public List<ActorModel> Actors { get; set; }
        public List<ParticipantModel> Participants { get; set; }
        public List<AwardModel> Awards { get; set; }
    }

    public class MovieGenre
    {
        public int id { get; set; }
        public string Name { get; set; }
    }

    public class AwardModel
    {
        public bool AwardWon { get; set; }
        public int AwardYear { get; set; }
        public string Award { get; set; }
        public string AwardCompany { get; set; }
    }

    public class StorylineModel
    {
        public int slid { get; set; }
        public string StoryType { get; set; }
        //public string Story { get; set; }
    }

    public interface iParticipant
    {
        string Name { get; set; }
        string RoleType { get; set; }
    }

    public class ActorModel : iParticipant
    {
        public string Name { get; set; }
        public string RoleType { get; set; }
    }

    public class ParticipantModel : iParticipant
    {
        public string Name { get; set; }
        public string RoleType { get; set; }
    }



}
