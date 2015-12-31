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
            Title2.Text = favs[FavMovieDropdown.SelectedIndex].Title;
            Year2.Text = favs[FavMovieDropdown.SelectedIndex].Year;
            Rated2.Text = favs[FavMovieDropdown.SelectedIndex].Rated;
            Released2.Text = favs[FavMovieDropdown.SelectedIndex].Released;
            /*
            Title2.Text = string.Format("Title: {0}", (string)dynObj["Title"]);
            Year2.Text = string.Format("Year: {0}", (string)dynObj["Year"]);
            Rated2.Text = string.Format("Rated: {0}", (string)dynObj["Rated"]);
            Released2.Text = string.Format("Released: {0}", (string)dynObj["Released"]);
            Runtime2.Text = string.Format("Runtime: {0}", (string)dynObj["Runtime"]);
            Genre2.Text = string.Format("Genre: {0}", (string)dynObj["Genre"]);
            Plot2.Text = string.Format("Plot: {0}", (string)dynObj["Plot"]);
            Director2.Text = string.Format("Director: {0}", (string)dynObj["Director"]);
            Writer2.Text = string.Format("Writer: {0}", (string)dynObj["Writer"]);
            IMDbRating2.Text = string.Format("IMDb Rating: {0}", (string)dynObj["imdbRating"]);
            PosterUrl2.Text = string.Format("Poster Url: {0}", (string)dynObj["Poster"]);

            movieposter2.Attributes["src"] = (string)dynObj["Poster"];*/
        }
    }

}