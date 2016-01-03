<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MYIMBD._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Keith's Movie Database <a class="btn btn-default btn-lg" href="/Search">Search IMDb</a></h1>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Favorite Movie Choices</h2>
            <p>These are some of my favorites.</p>
            <p>
                <a class="btn btn-default" href="/Favorite">Favorites</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Want-To-See's</h2>
            <p>These are movies that I want to see.</p>
            <p>
                <a class="btn btn-default" href="/WantToSee">Want-To-See's</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>New Theatre Releases</h2>
            <p>These are some of the new theatre movie releases.</p>
            <p>
                <a class="btn btn-default" href="/NewReleases">New Releases</a>
            </p>
        </div>
    </div>

</asp:Content>
