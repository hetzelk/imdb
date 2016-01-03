using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MYIMBD
{
    public partial class Edit : Page
    {
        public List<Models.FavoriteMovy> favs;
        public List<Models.WantToSeeMovy> wants;
        public List<Models.NewReleaseMovy> news;

        protected void Page_init(object sender, EventArgs e)
        {
            List<string[]> datatablelist = new List<string[]> { new string[] { "0", " " }, new string[] { "1", "FavoriteMovies" }, new string[] { "2", "WantToSeeMovies" }, new string[] { "3", "NewReleaseMovies" } };
            MovieDBDropdown.DataSource = from movieobject in datatablelist
                                         select new
                                       {
                                           Id = movieobject[0],
                                           Name = movieobject[1]
                                       };
            if (!IsPostBack)
            { 
            MovieDBDropdown.DataTextField = "Name";
            MovieDBDropdown.DataValueField = "Name";
            MovieDBDropdown.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void MovieDBDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(MovieDBDropdown.SelectedValue == "FavoriteMovies")
            {
                MovieChoiceDropdown.Items.Clear();
                Models.MovieClassDataContext manager = new Models.MovieClassDataContext();
                favs = new List<Models.FavoriteMovy>();
                Models.FavoriteMovy empty = new Models.FavoriteMovy();
                favs.Add(empty);
                var query =
                from c in manager.FavoriteMovies
                select c;
                foreach (Models.FavoriteMovy c in query)
                {
                    favs.Add(c);
                }
                if (IsPostBack)
                {
                    MovieChoiceDropdown.DataSource = favs;
                    MovieChoiceDropdown.DataTextField = "Title";
                    MovieChoiceDropdown.DataValueField = "P_Id";
                    MovieChoiceDropdown.DataBind();
                }
            }

            if (MovieDBDropdown.SelectedValue == "WantToSeeMovies")
            {
                MovieChoiceDropdown.Items.Clear();
                Models.MovieClassDataContext manager = new Models.MovieClassDataContext();
                wants = new List<Models.WantToSeeMovy>();
                Models.WantToSeeMovy empty = new Models.WantToSeeMovy();
                wants.Add(empty);
                var query =
                from c in manager.WantToSeeMovies
                select c;
                foreach (Models.WantToSeeMovy c in query)
                {
                    wants.Add(c);
                }
                if (IsPostBack)
                {
                    MovieChoiceDropdown.DataSource = wants;
                    MovieChoiceDropdown.DataTextField = "Title";
                    MovieChoiceDropdown.DataValueField = "P_Id";
                    MovieChoiceDropdown.DataBind();
                }
            }

            if (MovieDBDropdown.SelectedValue == "NewReleaseMovies")
            {
                MovieChoiceDropdown.Items.Clear();
                Models.MovieClassDataContext manager = new Models.MovieClassDataContext();
                news = new List<Models.NewReleaseMovy>();
                Models.NewReleaseMovy empty = new Models.NewReleaseMovy();
                news.Add(empty);
                var query =
                from c in manager.NewReleaseMovies
                select c;
                foreach (Models.NewReleaseMovy c in query)
                {
                    news.Add(c);
                }
                if (IsPostBack)
                {
                    MovieChoiceDropdown.DataSource = news;
                    MovieChoiceDropdown.DataTextField = "Title";
                    MovieChoiceDropdown.DataValueField = "P_Id";
                    MovieChoiceDropdown.DataBind();
                }
            }

        }
            
        public void MovieChoiceDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MovieDBDropdown.SelectedValue == "FavoriteMovies")
            {
                MovieChoiceDropdown.DataBind();
                Title1.Text = favs[MovieChoiceDropdown.SelectedIndex].Title;
                Year.Text = favs[MovieChoiceDropdown.SelectedIndex].Year;
                Rated.Text = favs[MovieChoiceDropdown.SelectedIndex].Rated;
                Released.Text = favs[MovieChoiceDropdown.SelectedIndex].Released;
                Runtime.Text = favs[MovieChoiceDropdown.SelectedIndex].Runtime;
                Genre.Text = favs[MovieChoiceDropdown.SelectedIndex].Genre;
                Plot.Text = favs[MovieChoiceDropdown.SelectedIndex].Plot;
                Director.Text = favs[MovieChoiceDropdown.SelectedIndex].Director;
                Writer.Text = favs[MovieChoiceDropdown.SelectedIndex].Writer;
                IMDbRating.Text = favs[MovieChoiceDropdown.SelectedIndex].IMDbRating;
                MyRating.Text = favs[MovieChoiceDropdown.SelectedIndex].MyRating;
                MyComments.Text = favs[MovieChoiceDropdown.SelectedIndex].MyComments;
                movieposter.Attributes["src"] = favs[MovieChoiceDropdown.SelectedIndex].PosterUrl;
            }

            if (MovieDBDropdown.SelectedValue == "WantToSeeMovies")
            {
                MovieChoiceDropdown.DataBind();
                Title1.Text = wants[MovieChoiceDropdown.SelectedIndex].Title;
                Year.Text = wants[MovieChoiceDropdown.SelectedIndex].Year;
                Rated.Text = wants[MovieChoiceDropdown.SelectedIndex].Rated;
                Released.Text = wants[MovieChoiceDropdown.SelectedIndex].Released;
                Runtime.Text = wants[MovieChoiceDropdown.SelectedIndex].Runtime;
                Genre.Text = wants[MovieChoiceDropdown.SelectedIndex].Genre;
                Plot.Text = wants[MovieChoiceDropdown.SelectedIndex].Plot;
                Director.Text = wants[MovieChoiceDropdown.SelectedIndex].Director;
                Writer.Text = wants[MovieChoiceDropdown.SelectedIndex].Writer;
                IMDbRating.Text = wants[MovieChoiceDropdown.SelectedIndex].IMDbRating;
                movieposter.Attributes["src"] = wants[MovieChoiceDropdown.SelectedIndex].PosterUrl;
            }

            if (MovieDBDropdown.SelectedValue == "NewReleaseMovies")
            {
                MovieChoiceDropdown.DataBind();
                Title1.Text = news[MovieChoiceDropdown.SelectedIndex].Title;
                Year.Text = news[MovieChoiceDropdown.SelectedIndex].Year;
                Rated.Text = news[MovieChoiceDropdown.SelectedIndex].Rated;
                Released.Text = news[MovieChoiceDropdown.SelectedIndex].Released;
                Runtime.Text = news[MovieChoiceDropdown.SelectedIndex].Runtime;
                Genre.Text = news[MovieChoiceDropdown.SelectedIndex].Genre;
                Plot.Text = news[MovieChoiceDropdown.SelectedIndex].Plot;
                Director.Text = news[MovieChoiceDropdown.SelectedIndex].Director;
                Writer.Text = news[MovieChoiceDropdown.SelectedIndex].Writer;
                IMDbRating.Text = news[MovieChoiceDropdown.SelectedIndex].IMDbRating;
                movieposter.Attributes["src"] = news[MovieChoiceDropdown.SelectedIndex].PosterUrl;
            }

        }

        public void Update_Movie(object sender, EventArgs e)
        {
            if (MovieDBDropdown.SelectedValue == "FavoriteMovies")
            {
                string connectionString = "workstation id=dccmoviestorage.mssql.somee.com;packet size=4096;user id=donaldIMBD_SQLLogin_3;pwd=w7bfccaw49;data source=dccmoviestorage.mssql.somee.com;persist security info=False;initial catalog=dccmoviestorage";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            string query = "UPDATE FavoriteMovies SET (Title, Year, Rated, Released, Runtime, Genre, Plot, Director, Writer, IMDbRating, MyRating, MyComments)" + "WHERE P_Id=@P_Id";
            query += " VALUES (@Title, @Year, @Rated, @Released, @Runtime, @Genre, @Plot, @Director, @Writer, @IMDbRating, @MyRating, @MyComments)";

            SqlCommand myCommand = new SqlCommand(query, myConnection);
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
            myCommand.Parameters.AddWithValue("@MyRating", MyRating.Text);
            myCommand.Parameters.AddWithValue("@MyComments", MyComments.Text);
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            }

            if (MovieDBDropdown.SelectedValue == "WantToSeeMovies")
            {
                string connectionString = "workstation id=dccmoviestorage.mssql.somee.com;packet size=4096;user id=donaldIMBD_SQLLogin_3;pwd=w7bfccaw49;data source=dccmoviestorage.mssql.somee.com;persist security info=False;initial catalog=dccmoviestorage";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            string query = "UPDATE WantToSeeMovies SET (Title, Year, Rated, Released, Runtime, Genre, Plot, Director, Writer, IMDbRating)" + "WHERE P_Id=@P_Id";
            query += " VALUES (@Title, @Year, @Rated, @Released, @Runtime, @Genre, @Plot, @Director, @Writer, @IMDbRating)";

            SqlCommand myCommand = new SqlCommand(query, myConnection);
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
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            }

            if (MovieDBDropdown.SelectedValue == "NewReleaseMovies")
            {
                string connectionString = "workstation id=dccmoviestorage.mssql.somee.com;packet size=4096;user id=donaldIMBD_SQLLogin_3;pwd=w7bfccaw49;data source=dccmoviestorage.mssql.somee.com;persist security info=False;initial catalog=dccmoviestorage";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            string query = "UPDATE NewReleaseMovies SET (Title, Year, Rated, Released, Runtime, Genre, Plot, Director, Writer, IMDbRating)" + "WHERE P_Id=@P_Id";
            query += " VALUES (@Title, @Year, @Rated, @Released, @Runtime, @Genre, @Plot, @Director, @Writer, @IMDbRating)";

            SqlCommand myCommand = new SqlCommand(query, myConnection);
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
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            }
        }

        public void Delete_Movie(object sender, EventArgs e)
        {
            if (MovieDBDropdown.SelectedValue == "FavoriteMovies")
            {
                string connectionString = "workstation id=dccmoviestorage.mssql.somee.com;packet size=4096;user id=donaldIMBD_SQLLogin_3;pwd=w7bfccaw49;data source=dccmoviestorage.mssql.somee.com;persist security info=False;initial catalog=dccmoviestorage";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            string query = "DELETE FROM FavoriteMovies " +
                    "WHERE P_Id=@P_Id";

            SqlCommand myCommand = new SqlCommand(query, myConnection);
            myConnection.Close();
            }

            if (MovieDBDropdown.SelectedValue == "WantToSeeMovies")
            {
                string connectionString = "workstation id=dccmoviestorage.mssql.somee.com;packet size=4096;user id=donaldIMBD_SQLLogin_3;pwd=w7bfccaw49;data source=dccmoviestorage.mssql.somee.com;persist security info=False;initial catalog=dccmoviestorage";
                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();

                string query = "DELETE FROM WantToSeeMovies " +
                        "WHERE P_Id=@P_Id";

                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Close();
            }

            if (MovieDBDropdown.SelectedValue == "NewReleaseMovies")
            {
                string connectionString = "workstation id=dccmoviestorage.mssql.somee.com;packet size=4096;user id=donaldIMBD_SQLLogin_3;pwd=w7bfccaw49;data source=dccmoviestorage.mssql.somee.com;persist security info=False;initial catalog=dccmoviestorage";
                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();

                string query = "DELETE FROM NewReleaseMovies " +
                        "WHERE P_Id=@P_Id";

                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Close();
            }
        }
    }
}