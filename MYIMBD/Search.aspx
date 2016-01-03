<%@ Page Title="Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="MYIMBD.Search" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Search through IMDB.</h3>
    <div class="row">
    <div class="form-group">
        <div class="col-md-3">
            <asp:TextBox ID="SearchTitle" runat="server" Text="" Placeholder="Search for a Title"/><br /><br />
            <asp:Button runat="server" OnClick="SearchFor" Text="Search" CssClass="btn btn-success" /><br /><br />
            <asp:Button runat="server" OnClick="addToFavs" Text="Add to Favs" CssClass="btn btn-warning" /><br /><br />
            <asp:Button runat="server" OnClick="addToWants" Text="Add to Want-To-Sees" CssClass="btn btn-info" /><br /><br />
            <asp:Button runat="server" OnClick="addToNew" Text="Add to New Releases" CssClass="btn btn-danger" /><br />
        </div>
    </div>
    <div class="col-md-6">
        Title: <asp:Label ID="Title1" runat="server" Text="Title" CssClass="white"></asp:Label><br />
        Year: <asp:Label ID="Year1" runat="server" Text="Year" CssClass="white"></asp:Label><br />
        Rated: <asp:Label ID="Rated1" runat="server" Text="Rated" CssClass="white"></asp:Label><br />
        Released: <asp:Label ID="Released1" runat="server" Text="Released" CssClass="white"></asp:Label><br />
        Runtime: <asp:Label ID="Runtime1" runat="server" Text="Runtime" CssClass="white"></asp:Label><br />
        Genre: <asp:Label ID="Genre1" runat="server" Text="Genre" CssClass="white"></asp:Label><br />
        Plot: <asp:Label ID="Plot1" runat="server" Text="Plot" CssClass="white"></asp:Label><br />
        Director: <asp:Label ID="Director1" runat="server" Text="Director" CssClass="white"></asp:Label><br />
        Writer: <asp:Label ID="Writer1" runat="server" Text="Writer" CssClass="white"></asp:Label><br />
        IMDb Rating: <asp:Label ID="IMDbRating1" runat="server" Text="IMDb Rating" CssClass="white"></asp:Label><br />
        PosterUrl: <asp:Label ID="PosterUrl1" runat="server" Text="PosterUrl" CssClass="white"></asp:Label><br />
        Url: <asp:Label ID="Url1" runat="server" Text="Url" CssClass="white"></asp:Label><br />
    </div>

    <div class="col-md-2">
        <asp:Image runat="server" ID="movieposter1" src=""/>
    </div>
</div>
</asp:Content>