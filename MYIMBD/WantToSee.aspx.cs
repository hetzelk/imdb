using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MYIMBD
{
    public partial class WantToSee : Page
    {
        public List<Models.WantToSeeMovy> wants;

        protected void Page_init(object sender, EventArgs e)
        {
            Models.MovieClassDataContext manager = new Models.MovieClassDataContext();
            wants = new List<Models.WantToSeeMovy>();
            Models.WantToSeeMovy empty = new Models.WantToSeeMovy();
            wants.Add(empty);
            var q =
            from c in manager.WantToSeeMovies
            select c;
            foreach (Models.WantToSeeMovy c in q)
            {
                wants.Add(c);
            }
            if (!IsPostBack)
            {
                WantMovieDropdown.DataSource = wants;
                WantMovieDropdown.DataTextField = "Title";
                WantMovieDropdown.DataValueField = "P_Id";
                WantMovieDropdown.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void WantMovieDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            WantMovieDropdown.DataBind();
            Title1.Text = wants[WantMovieDropdown.SelectedIndex].Title;
            Year.Text = wants[WantMovieDropdown.SelectedIndex].Year;
            Rated.Text = wants[WantMovieDropdown.SelectedIndex].Rated;
            Released.Text = wants[WantMovieDropdown.SelectedIndex].Released;
            Runtime.Text = wants[WantMovieDropdown.SelectedIndex].Runtime;
            Genre.Text = wants[WantMovieDropdown.SelectedIndex].Genre;
            Plot.Text = wants[WantMovieDropdown.SelectedIndex].Plot;
            Director.Text = wants[WantMovieDropdown.SelectedIndex].Director;
            Writer.Text = wants[WantMovieDropdown.SelectedIndex].Writer;
            IMDbRating.Text = wants[WantMovieDropdown.SelectedIndex].IMDbRating;
            movieposter.Attributes["src"] = wants[WantMovieDropdown.SelectedIndex].PosterUrl;


        }
    }
}