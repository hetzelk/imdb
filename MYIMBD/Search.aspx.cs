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
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace MYIMBD
{
    public partial class Search : Page
    {
        public List<Models.FavoriteMovy> favs;
        public List<Models.WantToSeeMovy> wants;
        public List<Models.NewReleaseMovy> news;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int getHighFav()
        {
            favs = new List<Models.FavoriteMovy>();
            int favid = 0;
            var q =
                    from c in favs
                    where c.P_Id < 100000
                    select c;
            foreach (Models.FavoriteMovy c in q)
            {
                favid += 1;
            }
            int highfavid = favid + 1;
            return highfavid;
        }

        public int getHighWant()
        {
            wants = new List<Models.WantToSeeMovy>();
            int wantid = 0;
            var q =
                    from c in wants
                    where c.P_Id < 100000
                    select c;
            foreach (Models.WantToSeeMovy c in q)
            {
                wantid += 1;
            }
            int highwantid = wantid + 1;
            return highwantid;
        }

        public int getHighNew()
        {
            news = new List<Models.NewReleaseMovy>();
            int newid = 0;
            var q =
                    from c in news
                    where c.P_Id < 100000
                    select c;
            foreach (Models.NewReleaseMovy c in q)
            {
                newid += 1;
            }
            int highnewid = newid + 1;
            return highnewid;
        }

        public void SearchFor(object sender, EventArgs e)
        {
            string searchtitle = SearchTitle.Text;
            string title = searchtitle.Replace(' ', '+');
            string url = "http://www.omdbapi.com/?t=" + title;
            Url.Text = url;
            var json = new WebClient().DownloadString(url);

            dynamic dynObj = JsonConvert.DeserializeObject(json);
            Title1.Text = string.Format("Title: {0}", (string)dynObj["Title"]);
            Year.Text = string.Format("Year: {0}", (string)dynObj["Year"]);
            Rated.Text = string.Format("Rated: {0}", (string)dynObj["Rated"]);
            Released.Text = string.Format("Released: {0}", (string)dynObj["Released"]);
            Runtime.Text = string.Format("Runtime: {0}", (string)dynObj["Runtime"]);
            Genre.Text = string.Format("Genre: {0}", (string)dynObj["Genre"]);
            Plot.Text = string.Format("Plot: {0}", (string)dynObj["Plot"]);
            Director.Text = string.Format("Director: {0}", (string)dynObj["Director"]);
            Writer.Text = string.Format("Writer: {0}", (string)dynObj["Writer"]);
            IMDbRating.Text = string.Format("IMDb Rating: {0}", (string)dynObj["imdbRating"]);
            PosterUrl.Text = string.Format("Poster Url: {0}", (string)dynObj["Poster"]);

            movieposter.Attributes["src"] = (string)dynObj["Poster"];
        }

        public void addToFavs(object sender, EventArgs e)
        {
            string connectionString = "workstation id = dccmoviestorage.mssql.somee.com; packet size = 4096; user id = donaldIMBD_SQLLogin_3; pwd = w7bfccaw49; data source = dccmoviestorage.mssql.somee.com; persist security info = False; initial catalog = dccmoviestorage";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            string query = "INSERT INTO FavoriteMovies (P_Id, Title, Year, Rated, Released, Runtime, Genre, Plot, Director, Writer, IMDbRating, PosterUrl, Url)";
            query += " VALUES (@P_Id, @Title, @Year, @Rated, @Released, @Runtime, @Genre, @Plot, @Director, @Writer, @IMDbRating, @PosterUrl, @Url)";

            SqlCommand myCommand = new SqlCommand(query, myConnection);
            myCommand.Parameters.AddWithValue("@P_Id", getHighFav());
            myCommand.Parameters.AddWithValue("@Title", Title1.Text);
            myCommand.Parameters.AddWithValue("@Year", Year.Text);
            myCommand.Parameters.AddWithValue("@Rated", Rated.Text);
            myCommand.Parameters.AddWithValue("@Released", Released.Text);
            myCommand.Parameters.AddWithValue("@Runtime", Runtime.Text);
            myCommand.Parameters.AddWithValue("@Genre", Genre.Text);
            myCommand.Parameters.AddWithValue("@Plot", Plot.Text);
            myCommand.Parameters.AddWithValue("@Director", Director.Text);
            myCommand.Parameters.AddWithValue("@Writer", Writer.Text);
            myCommand.Parameters.AddWithValue("@IMDbRating", IMDbRating.Text);
            myCommand.Parameters.AddWithValue("@PosterUrl", PosterUrl.Text);
            myCommand.Parameters.AddWithValue("@Url", Url.Text);
            myCommand.ExecuteNonQuery();
        }

        public void addToWants(object sender, EventArgs e)
        {
            string connectionString = "workstation id = dccmoviestorage.mssql.somee.com; packet size = 4096; user id = donaldIMBD_SQLLogin_3; pwd = w7bfccaw49; data source = dccmoviestorage.mssql.somee.com; persist security info = False; initial catalog = dccmoviestorage";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            string query = "INSERT INTO WantToSeeMovies (P_Id, Title, Year, Rated, Released, Runtime, Genre, Plot, Director, Writer, IMDbRating, PosterUrl, Url)";
            query += " VALUES (@P_Id, @Title, @Year, @Rated, @Released, @Runtime, @Genre, @Plot, @Director, @Writer, @IMDbRating, @PosterUrl, @Url)";

            SqlCommand myCommand = new SqlCommand(query, myConnection);
            myCommand.Parameters.AddWithValue("@P_Id", getHighWant());
            myCommand.Parameters.AddWithValue("@Title", Title1.Text);
            myCommand.Parameters.AddWithValue("@Year", Year.Text);
            myCommand.Parameters.AddWithValue("@Rated", Rated.Text);
            myCommand.Parameters.AddWithValue("@Released", Released.Text);
            myCommand.Parameters.AddWithValue("@Runtime", Runtime.Text);
            myCommand.Parameters.AddWithValue("@Genre", Genre.Text);
            myCommand.Parameters.AddWithValue("@Plot", Plot.Text);
            myCommand.Parameters.AddWithValue("@Director", Director.Text);
            myCommand.Parameters.AddWithValue("@Writer", Writer.Text);
            myCommand.Parameters.AddWithValue("@IMDbRating", IMDbRating.Text);
            myCommand.Parameters.AddWithValue("@PosterUrl", PosterUrl.Text);
            myCommand.Parameters.AddWithValue("@Url", Url.Text);
            myCommand.ExecuteNonQuery();
        }

        public void addToNew(object sender, EventArgs e)
        {
            string connectionString = "workstation id = dccmoviestorage.mssql.somee.com; packet size = 4096; user id = donaldIMBD_SQLLogin_3; pwd = w7bfccaw49; data source = dccmoviestorage.mssql.somee.com; persist security info = False; initial catalog = dccmoviestorage";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            string query = "INSERT INTO NewReleaseMovies (P_Id, Title, Year, Rated, Released, Runtime, Genre, Plot, Director, Writer, IMDbRating, PosterUrl, Url)";
            query += " VALUES (@P_Id, @Title, @Year, @Rated, @Released, @Runtime, @Genre, @Plot, @Director, @Writer, @IMDbRating, @PosterUrl, @Url)";

            SqlCommand myCommand = new SqlCommand(query, myConnection);
            myCommand.Parameters.AddWithValue("@P_Id", getHighNew());
            myCommand.Parameters.AddWithValue("@Title", Title1.Text);
            myCommand.Parameters.AddWithValue("@Year", Year.Text);
            myCommand.Parameters.AddWithValue("@Rated", Rated.Text);
            myCommand.Parameters.AddWithValue("@Released", Released.Text);
            myCommand.Parameters.AddWithValue("@Runtime", Runtime.Text);
            myCommand.Parameters.AddWithValue("@Genre", Genre.Text);
            myCommand.Parameters.AddWithValue("@Plot", Plot.Text);
            myCommand.Parameters.AddWithValue("@Director", Director.Text);
            myCommand.Parameters.AddWithValue("@Writer", Writer.Text);
            myCommand.Parameters.AddWithValue("@IMDbRating", IMDbRating.Text);
            myCommand.Parameters.AddWithValue("@PosterUrl", PosterUrl.Text);
            myCommand.Parameters.AddWithValue("@Url", Url.Text);
            myCommand.ExecuteNonQuery();
        }

    }

}