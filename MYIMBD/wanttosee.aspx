<%@ Page Title="Want-To-See" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WantToSee.aspx.cs" Inherits="MYIMBD.WantToSee" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Movies I want to see.</h3>

    <div class="row">
        <div class="col-md-3">
        <asp:DropDownList ID="WantMovieDropdown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="WantMovieDropdown_SelectedIndexChanged" EnableViewState="true" AppendDataBoundItems="true"></asp:DropDownList>
        </div>
    <div class="col-md-6">        
        Title: <asp:Label ID="Title1" runat="server" Text="Title" CssClass="white"></asp:Label><br />
        Year: <asp:Label ID="Year" runat="server" Text="Year" CssClass="white"></asp:Label><br />
        Rated: <asp:Label ID="Rated" runat="server" Text="Rated" CssClass="white"></asp:Label><br />
        Released: <asp:Label ID="Released" runat="server" Text="Released" CssClass="white"></asp:Label><br />
        Runtime: <asp:Label ID="Runtime" runat="server" Text="Runtime" CssClass="white"></asp:Label><br />
        Genre: <asp:Label ID="Genre" runat="server" Text="Genre" CssClass="white"></asp:Label><br />
        Plot: <asp:Label ID="Plot" runat="server" Text="Plot" CssClass="white"></asp:Label><br />
        Director: <asp:Label ID="Director" runat="server" Text="Director" CssClass="white"></asp:Label><br />
        Writer: <asp:Label ID="Writer" runat="server" Text="Writer" CssClass="white"></asp:Label><br />
        IMDbRating: <asp:Label ID="IMDbRating" runat="server" Text="IMDb Rating" CssClass="white"></asp:Label><br />
    </div>

    <div class="col-md-2">
        <asp:Image runat="server" ID="movieposter" src=""/>
    </div>
</div>    
</asp:Content>
