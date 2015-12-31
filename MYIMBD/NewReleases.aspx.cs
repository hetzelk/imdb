using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MYIMBD
{
    public partial class NewReleases : Page
    {
        public List<Models.NewReleaseMovy> newmovies;

        protected void Page_init(object sender, EventArgs e)
        {
            Models.MovieClassDataContext manager = new Models.MovieClassDataContext();
            newmovies = new List<Models.NewReleaseMovy>();
            Models.NewReleaseMovy empty = new Models.NewReleaseMovy();
            newmovies.Add(empty);
            var q =
            from c in manager.NewReleaseMovies
            select c;
            foreach (Models.NewReleaseMovy c in q)
            {
                newmovies.Add(c);
            }
            if (!IsPostBack)
            {
                NewMovieDropdown.DataSource = newmovies;
                NewMovieDropdown.DataTextField = "Title";
                NewMovieDropdown.DataValueField = "P_Id";
                NewMovieDropdown.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void NewMovieDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            NewMovieDropdown.DataBind();
            Title1.Text = newmovies[NewMovieDropdown.SelectedIndex].Title;
            Year.Text = newmovies[NewMovieDropdown.SelectedIndex].Year;
            Rated.Text = newmovies[NewMovieDropdown.SelectedIndex].Rated;
            Released.Text = newmovies[NewMovieDropdown.SelectedIndex].Released;
            Runtime.Text = newmovies[NewMovieDropdown.SelectedIndex].Runtime;
            Genre.Text = newmovies[NewMovieDropdown.SelectedIndex].Genre;
            Plot.Text = newmovies[NewMovieDropdown.SelectedIndex].Plot;
            Director.Text = newmovies[NewMovieDropdown.SelectedIndex].Director;
            Writer.Text = newmovies[NewMovieDropdown.SelectedIndex].Writer;
            IMDbRating.Text = newmovies[NewMovieDropdown.SelectedIndex].IMDbRating;
            movieposter.Attributes["src"] = newmovies[NewMovieDropdown.SelectedIndex].PosterUrl;


        }
    }
}