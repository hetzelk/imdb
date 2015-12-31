using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using HtmlAgilityPack;
using System.Xml;
using System.IO;
using Newtonsoft.Json;
using System.Net;

namespace MYIMBD //MovieClassDataContext
{
    public partial class Favorite : Page
    {
        public List<Models.FavoriteMovy> favs;

        protected void Page_init(object sender, EventArgs e)
        {
            Models.MovieClassDataContext manager = new Models.MovieClassDataContext();
            favs = new List<Models.FavoriteMovy>();
            Models.FavoriteMovy empty = new Models.FavoriteMovy();
            favs.Add(empty);
            var q =
            from c in manager.FavoriteMovies
            select c;
            foreach (Models.FavoriteMovy c in q)
            {
                favs.Add(c);
            }
            if (!IsPostBack)
            {
                FavMovieDropdown.DataSource = favs;
                FavMovieDropdown.DataTextField = "Title";
                FavMovieDropdown.DataValueField = "P_Id";
                FavMovieDropdown.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        public void FavMovieDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            FavMovieDropdown.DataBind();
            Title1.Text = favs[FavMovieDropdown.SelectedIndex].Title;
            Year.Text = favs[FavMovieDropdown.SelectedIndex].Year;
            Rated.Text = favs[FavMovieDropdown.SelectedIndex].Rated;
            Released.Text = favs[FavMovieDropdown.SelectedIndex].Released;
            Runtime.Text = favs[FavMovieDropdown.SelectedIndex].Runtime;
            Genre.Text = favs[FavMovieDropdown.SelectedIndex].Genre;
            Plot.Text = favs[FavMovieDropdown.SelectedIndex].Plot;
            Director.Text = favs[FavMovieDropdown.SelectedIndex].Director;
            Writer.Text = favs[FavMovieDropdown.SelectedIndex].Writer;
            IMDbRating.Text = favs[FavMovieDropdown.SelectedIndex].IMDbRating;
            movieposter.Attributes["src"] = favs[FavMovieDropdown.SelectedIndex].PosterUrl;
            
            
        }
    }

}