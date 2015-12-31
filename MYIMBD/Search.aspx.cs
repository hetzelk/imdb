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
            string stmt = "SELECT COUNT(*) FROM dbo.FavoriteMovies";
            int count = 0;

            string connectionString = "workstation id = dccmoviestorage.mssql.somee.com; packet size = 4096; user id = keithlogin1; pwd = keithlogin1; data source = dccmoviestorage.mssql.somee.com; persist security info = True; initial catalog = dccmoviestorage";

            using (SqlConnection thisConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmdCount = new SqlCommand(stmt, thisConnection))
                {
                    thisConnection.Open();
                    count = (int)cmdCount.ExecuteScalar();
                    thisConnection.Close();
                }
            }
            count++;
            return count;
        }

        public int getHighWant()
        {
            string stmt = "SELECT COUNT(*) FROM dbo.WantToSeeMovies";
            int count = 0;

            string connectionString = "workstation id = dccmoviestorage.mssql.somee.com; packet size = 4096; user id = donaldIMBD_SQLLogin_2; pwd = 123123123; data source = dccmoviestorage.mssql.somee.com; persist security info = False; initial catalog = dccmoviestorage";

            using (SqlConnection thisConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmdCount = new SqlCommand(stmt, thisConnection))
                {
                    thisConnection.Open();
                    count = (int)cmdCount.ExecuteScalar();
                    thisConnection.Close();
                }
            }
            count++;
            return count;
        }

        public int getHighNew()
        {
            string stmt = "SELECT COUNT(*) FROM dbo.NewReleaseMovies";
            int count = 0;

            string connectionString = "workstation id = dccmoviestorage.mssql.somee.com; packet size = 4096; user id = donaldIMBD_SQLLogin_2; pwd = 123123123; data source = dccmoviestorage.mssql.somee.com; persist security info = False; initial catalog = dccmoviestorage";

            using (SqlConnection thisConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmdCount = new SqlCommand(stmt, thisConnection))
                {
                    thisConnection.Open();
                    count = (int)cmdCount.ExecuteScalar();
                    thisConnection.Close();
                }
            }
            count++;
            return count;
        }

        public void SearchFor(object sender, EventArgs e)
        {
            string searchtitle = SearchTitle.Text;
            string title = searchtitle.Replace(' ', '+');
            string url = "http://www.omdbapi.com/?t=" + title;
            Url1.Text = url;
            var json = new WebClient().DownloadString(url);

            dynamic dynObj = JsonConvert.DeserializeObject(json);
            Title1.Text = string.Format("{0}", (string)dynObj["Title"]);
            Year1.Text = string.Format("{0}", (string)dynObj["Year"]);
            Rated1.Text = string.Format("{0}", (string)dynObj["Rated"]);
            Released1.Text = string.Format("{0}", (string)dynObj["Released"]);
            Runtime1.Text = string.Format("{0}", (string)dynObj["Runtime"]);
            Genre1.Text = string.Format("{0}", (string)dynObj["Genre"]);
            Plot1.Text = string.Format("{0}", (string)dynObj["Plot"]);
            Director1.Text = string.Format("{0}", (string)dynObj["Director"]);
            Writer1.Text = string.Format("{0}", (string)dynObj["Writer"]);
            IMDbRating1.Text = string.Format("{0}", (string)dynObj["imdbRating"]);
            PosterUrl1.Text = string.Format("{0}", (string)dynObj["Poster"]);

            movieposter1.Attributes["src"] = (string)dynObj["Poster"];
        }

        public void addToFavs(object sender, EventArgs e)
        {
            string connectionString = "workstation id = dccmoviestorage.mssql.somee.com; packet size = 4096; user id = keithlogin1; pwd = keithlogin1; data source = dccmoviestorage.mssql.somee.com; persist security info = True; initial catalog = dccmoviestorage";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            string query = "INSERT INTO FavoriteMovies (P_Id, Title, Year, Rated, Released, Runtime, Genre, Plot, Director, Writer, IMDbRating, PosterUrl, Url)";
            query += " VALUES (@P_Id, @Title, @Year, @Rated, @Released, @Runtime, @Genre, @Plot, @Director, @Writer, @IMDbRating, @PosterUrl, @Url)";

            SqlCommand myCommand = new SqlCommand(query, myConnection);
            myCommand.Parameters.AddWithValue("@P_Id", getHighFav());
            myCommand.Parameters.AddWithValue("@Title", Title1.Text);
            myCommand.Parameters.AddWithValue("@Year", Year1.Text);
            myCommand.Parameters.AddWithValue("@Rated", Rated1.Text);
            myCommand.Parameters.AddWithValue("@Released", Released1.Text);
            myCommand.Parameters.AddWithValue("@Runtime", Runtime1.Text);
            myCommand.Parameters.AddWithValue("@Genre", Genre1.Text);
            myCommand.Parameters.AddWithValue("@Plot", Plot1.Text);
            myCommand.Parameters.AddWithValue("@Director", Director1.Text);
            myCommand.Parameters.AddWithValue("@Writer", Writer1.Text);
            myCommand.Parameters.AddWithValue("@IMDbRating", IMDbRating1.Text);
            myCommand.Parameters.AddWithValue("@PosterUrl", PosterUrl1.Text);
            myCommand.Parameters.AddWithValue("@Url", Url1.Text);
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }

        public void addToWants(object sender, EventArgs e)
        {
            string connectionString = "workstation id = dccmoviestorage.mssql.somee.com; packet size = 4096; user id = donaldIMBD_SQLLogin_2; pwd = 123123123; data source = dccmoviestorage.mssql.somee.com; persist security info = False; initial catalog = dccmoviestorage";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            string query = "INSERT INTO WantToSeeMovies (P_Id, Title, Year, Rated, Released, Runtime, Genre, Plot, Director, Writer, IMDbRating, PosterUrl, Url)";
            query += " VALUES (@P_Id, @Title, @Year, @Rated, @Released, @Runtime, @Genre, @Plot, @Director, @Writer, @IMDbRating, @PosterUrl, @Url)";

            SqlCommand myCommand = new SqlCommand(query, myConnection);
            myCommand.Parameters.AddWithValue("@P_Id", getHighWant());
            myCommand.Parameters.AddWithValue("@Title", Title1.Text);
            myCommand.Parameters.AddWithValue("@Year", Year1.Text);
            myCommand.Parameters.AddWithValue("@Rated", Rated1.Text);
            myCommand.Parameters.AddWithValue("@Released", Released1.Text);
            myCommand.Parameters.AddWithValue("@Runtime", Runtime1.Text);
            myCommand.Parameters.AddWithValue("@Genre", Genre1.Text);
            myCommand.Parameters.AddWithValue("@Plot", Plot1.Text);
            myCommand.Parameters.AddWithValue("@Director", Director1.Text);
            myCommand.Parameters.AddWithValue("@Writer", Writer1.Text);
            myCommand.Parameters.AddWithValue("@IMDbRating", IMDbRating1.Text);
            myCommand.Parameters.AddWithValue("@PosterUrl", PosterUrl1.Text);
            myCommand.Parameters.AddWithValue("@Url", Url1.Text);
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }

        public void addToNew(object sender, EventArgs e)
        {
            string connectionString = "workstation id = dccmoviestorage.mssql.somee.com; packet size = 4096; user id = donaldIMBD_SQLLogin_2; pwd = 123123123; data source = dccmoviestorage.mssql.somee.com; persist security info = False; initial catalog = dccmoviestorage";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            string query = "INSERT INTO NewReleaseMovies (P_Id, Title, Year, Rated, Released, Runtime, Genre, Plot, Director, Writer, IMDbRating, PosterUrl, Url)";
            query += " VALUES (@P_Id, @Title, @Year, @Rated, @Released, @Runtime, @Genre, @Plot, @Director, @Writer, @IMDbRating, @PosterUrl, @Url)";

            SqlCommand myCommand = new SqlCommand(query, myConnection);
            myCommand.Parameters.AddWithValue("@P_Id", getHighNew());
            myCommand.Parameters.AddWithValue("@Title", Title1.Text);
            myCommand.Parameters.AddWithValue("@Year", Year1.Text);
            myCommand.Parameters.AddWithValue("@Rated", Rated1.Text);
            myCommand.Parameters.AddWithValue("@Released", Released1.Text);
            myCommand.Parameters.AddWithValue("@Runtime", Runtime1.Text);
            myCommand.Parameters.AddWithValue("@Genre", Genre1.Text);
            myCommand.Parameters.AddWithValue("@Plot", Plot1.Text);
            myCommand.Parameters.AddWithValue("@Director", Director1.Text);
            myCommand.Parameters.AddWithValue("@Writer", Writer1.Text);
            myCommand.Parameters.AddWithValue("@IMDbRating", IMDbRating1.Text);
            myCommand.Parameters.AddWithValue("@PosterUrl", PosterUrl1.Text);
            myCommand.Parameters.AddWithValue("@Url", Url1.Text);
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }

    }

}