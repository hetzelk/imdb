<%@ Page Title="Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Favorite.aspx.cs" Inherits="MYIMBD.Search" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>My Favorites.</h3>
    <div class="row">
    <div class="form-group">
        <div class="col-md-2">
            <asp:TextBox ID="SearchTitle" runat="server" Text="" Placeholder="Search for a Title"/><br /><br />
            <asp:Button runat="server" OnClick="SearchFor" Text="Search" CssClass="btn btn-success" /><br /><br />
            <asp:Button runat="server" OnClick="addToFavs" Text="Add to Favs" CssClass="btn btn-warning" /><br /><br />
            <asp:Button runat="server" OnClick="addToWants" Text="Add to Want-To-Sees" CssClass="btn btn-info" /><br /><br />
            <asp:Button runat="server" OnClick="addToNew" Text="Add to New Releases" CssClass="btn btn-danger" /><br />
        </div>
    </div>
    <div class="col-md-7">        
        <asp:Label ID="Title1" runat="server" Text="Title" CssClass="white"></asp:Label><br />
        <asp:Label ID="Year" runat="server" Text="Year" CssClass="white"></asp:Label><br />
        <asp:Label ID="Rated" runat="server" Text="Rated" CssClass="white"></asp:Label><br />
        <asp:Label ID="Released" runat="server" Text="Released" CssClass="white"></asp:Label><br />
        <asp:Label ID="Runtime" runat="server" Text="Runtime" CssClass="white"></asp:Label><br />
        <asp:Label ID="Genre" runat="server" Text="Genre" CssClass="white"></asp:Label><br />
        <asp:Label ID="Plot" runat="server" Text="Plot" CssClass="white"></asp:Label><br />
        <asp:Label ID="Director" runat="server" Text="Director" CssClass="white"></asp:Label><br />
        <asp:Label ID="Writer" runat="server" Text="Writer" CssClass="white"></asp:Label><br />
        <asp:Label ID="IMDbRating" runat="server" Text="IMDb Rating" CssClass="white"></asp:Label><br />
        <asp:Label ID="PosterUrl" runat="server" Text="PosterUrl" CssClass="white"></asp:Label><br />
        <asp:Label ID="Url" runat="server" Text="Url" CssClass="white"></asp:Label><br />
    </div>

    <div class="col-md-2">
        <asp:Image runat="server" ID="movieposter" src=""/>
    </div>
</div>
</asp:Content>