<%@ Page Title="Favorite" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Favorite.aspx.cs" Inherits="MYIMBD.Favorite" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="row">
    <div class="col-md-2">
    <h2><%: Title %>.</h2>
    <h3>My Favorites.</h3>
    <asp:DropDownList ID="FavMovieDropdown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="FavMovieDropdown_SelectedIndexChanged" EnableViewState="true" AppendDataBoundItems="true"></asp:DropDownList></div>
    <div class="col-md-7">        
        <asp:Label ID="Title2" runat="server" Text="Title" CssClass="white"></asp:Label><br />
        <asp:Label ID="Year2" runat="server" Text="Year" CssClass="white"></asp:Label><br />
        <asp:Label ID="Rated2" runat="server" Text="Rated" CssClass="white"></asp:Label><br />
        <asp:Label ID="Released2" runat="server" Text="Released" CssClass="white"></asp:Label><br />
        <asp:Label ID="Runtime2" runat="server" Text="Runtime" CssClass="white"></asp:Label><br />
        <asp:Label ID="Genre2" runat="server" Text="Genre" CssClass="white"></asp:Label><br />
        <asp:Label ID="Plot2" runat="server" Text="Plot" CssClass="white"></asp:Label><br />
        <asp:Label ID="Director2" runat="server" Text="Director" CssClass="white"></asp:Label><br />
        <asp:Label ID="Writer2" runat="server" Text="Writer" CssClass="white"></asp:Label><br />
        <asp:Label ID="IMDbRating2" runat="server" Text="IMDb Rating" CssClass="white"></asp:Label><br />
        <asp:Label ID="PosterUrl2" runat="server" Text="PosterUrl" CssClass="white"></asp:Label><br />
        <asp:Label ID="Url2" runat="server" Text="Url" CssClass="white"></asp:Label><br />
    </div>

    <div class="col-md-2">
        <asp:Image runat="server" ID="movieposter2" src=""/>
    </div>
</div>    
</asp:Content>
