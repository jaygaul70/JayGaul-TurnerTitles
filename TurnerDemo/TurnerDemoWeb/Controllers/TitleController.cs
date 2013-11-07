using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TitlesModel;
using TitlesDataLayer;
using TitlesDataLayer.AppHelpers;

namespace TurnerDemoWeb.Controllers
{
    public class TitleController : Controller
    {
        //
        // GET: /Title/
        private TitleHelper th = new TitleHelper();
        public ActionResult Index()
        {
            MovieTitlesPagedModel m = new MovieTitlesPagedModel();
            m.MovieTitles = th.SearchMovies("", 0, 25);
            return View(m);
        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {
            if (Request.IsAjaxRequest())
            {
                List<MovieTitle> movies = th.SearchMovies(searchString, 0, 25);
                return PartialView("_TitleSearchPartial", movies);
            }

            MovieTitlesPagedModel m = new MovieTitlesPagedModel();
            m.MovieTitles = th.SearchMovies(searchString, 0, 25);
            return View(m);
        }

        public ActionResult View(int id)
        {
            MovieDetailsModel m = th.GetMovieDetails(id);
            return PartialView("_MovieDetailsPartial", m);
        }

        public ActionResult ViewMovie(int id)
        {
            MovieDetailsModel m = th.GetMovieDetails(id);
            return View(m);
        }

        public JsonResult GetStoryline(int storyId)
        {
            return Json(new { story = th.GetStoryline(storyId) });

        }

    }
}
