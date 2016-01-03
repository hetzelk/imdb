<%@ Page Title="Edit Db" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="MYIMBD.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %>.</h2>
    <h3>Edit Any Entry.</h3>
    <div class="row">
        <div class="col-md-3">
            <p>Pick a DataTable to edit a movie from.</p>
        <asp:DropDownList ID="MovieDBDropdown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="MovieDBDropdown_SelectedIndexChanged" EnableViewState="true" AppendDataBoundItems="true"></asp:DropDownList><br /><br />
            <p>Pick a Movie to edit.</p>
        <asp:DropDownList ID="MovieChoiceDropdown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="MovieChoice_SelectedIndexChanged" EnableViewState="true" AppendDataBoundItems="true"></asp:DropDownList>

            <br /><br /><br />
            <asp:Button ID="Update" runat="server" OnClick="Update_Movie" Text="Update Movie" CssClass="btn btn-success" /><br /><br />
            <asp:Button ID="Delete" runat="server" OnClick="Delete_Movie" Text="Delete Movie" CssClass="btn btn-danger" />
        </div>
    <div class="col-md-1">    
        <label for="Title1">Title: </label>
        <label for="Year">Year: </label>
        <label for="Rated">Rated: </label>
        <label for="Released">Released: </label>
        <label for="Runtime">Runtime: </label>
        <label for="Genre">Genre: </label>
        <label for="Plot">Plot: </label>
        <label for="Director">Director: </label>
        <label for="Writer">Writer: </label>
        <label for="IMDbRating">IMDbRating: </label>
        <label for="MyRating">My Rating: </label>
        <label for="MyComments">My Comments: </label>
    </div>
    <div class="col-md-5">    
        <asp:TextBox ID="Title1" runat="server" Text="Title" CssClass="white"></asp:TextBox><br />
        <asp:TextBox ID="Year" runat="server" Text="Year" CssClass="white"></asp:TextBox><br />
        <asp:TextBox ID="Rated" runat="server" Text="Rated" CssClass="white"></asp:TextBox><br />
        <asp:TextBox ID="Released" runat="server" Text="Released" CssClass="white"></asp:TextBox><br />
        <asp:TextBox ID="Runtime" runat="server" Text="Runtime" CssClass="white"></asp:TextBox><br />
        <asp:TextBox ID="Genre" runat="server" Text="Genre" CssClass="white"></asp:TextBox><br />
        <asp:TextBox ID="Plot" runat="server" Text="Plot" CssClass="white"></asp:TextBox><br />
        <asp:TextBox ID="Director" runat="server" Text="Director" CssClass="white"></asp:TextBox><br />
        <asp:TextBox ID="Writer" runat="server" Text="Writer" CssClass="white"></asp:TextBox><br />
        <asp:TextBox ID="IMDbRating" runat="server" Text="IMDb Rating" CssClass="white"></asp:TextBox><br /><br />
        <asp:TextBox ID="MyRating" runat="server" Text="My Rating" CssClass="white"></asp:TextBox><br /><br />
        <asp:TextBox ID="MyComments" runat="server" Text="My Comments" CssClass="white"></asp:TextBox><br />
    </div>

    <div class="col-md-2">
        <asp:Image runat="server" ID="movieposter" src=""/>
    </div>
</div>    

</asp:Content>
