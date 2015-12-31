<%@ Page Title="New Releases" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewReleases.aspx.cs" Inherits="MYIMBD.NewReleases" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>New releases in the theatres.</h3>

    <div class="row">
        <div class="col-md-2">
        <asp:DropDownList ID="NewMovieDropdown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="NewMovieDropdown_SelectedIndexChanged" EnableViewState="true" AppendDataBoundItems="true"></asp:DropDownList>
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
    </div>

    <div class="col-md-2">
        <asp:Image runat="server" ID="movieposter" src=""/>
    </div>
</div>    
</asp:Content>
