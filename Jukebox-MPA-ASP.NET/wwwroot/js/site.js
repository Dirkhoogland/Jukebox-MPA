﻿var userinput = document.getElementById(userinput);
var select = document.getElementById("Select");
/*select.style.visibility = "hidden";*/
//* user related functions */
function Newuser()
{
    
    
    var userinputj = prompt("New user name")
    $.ajax({
        type: "Post",
        dataType: "Json",
        url: '/User/Newuser',
        data: JSON.stringify(userinputj),
        contentType: "application/json",
        success: function () { console.log(Id); },
        Error: function (a, b, c) { console.log(a); console.log(b); console.log(c); },
        complete: function () { location.reload(); }
    });
    
}
// logs in user into session
function Login(Id, user)
{/*, user*/
    console.log(Id)
    if (user == "Login")
    {
        $.ajax({
            type: "Post",
            dataType: "Json",
            url: '/User/login',
            data: JSON.stringify(Id),
            contentType: "application/json",
            success: function (response) { console.log(JSON.stringify(response)); },
            error: function (a, b, c) { console.log(a); console.log(b); console.log(c); },
            complete: function (message) { location.reload(); }
        });
    }
    else
    {
        $.ajax({
            type: "Post",
            dataType: "Json",
            url: '/User/relogin',
            data: JSON.stringify(Id),
            contentType: "application/json",
            success: function (response) { console.log(JSON.stringify(response)); },
            error: function (a, b, c) { console.log(a); console.log(b); console.log(c); },
            complete: function (message) { location.reload(); }
        });
    }
    
}
// deletes user 
function Deleteuser(Id)
{
    $.ajax({
        type: "Post",
        dataType: "Json",
        url: '/User/Delete',
        data: JSON.stringify(Id),
        contentType: "application/json",
        success: function () { console.log(Id); },
        Error: function (a, b, c) { console.log(a); console.log(b); console.log(c); },
        complete: function () { location.reload(); }
    });
}
/*-----------------------------------------------------------------------------------------------------*/
//* playlist related functions */
function addtoqueue(Id)
{    
    console.log(Id)

    $.ajax({
        type: "Post",
        dataType: "Json",
        url: '/EditPlaylists/UpdateLocalPlaylist',
        data: JSON.stringify(Id),
        contentType: "application/json",
        success: function () { console.log(Id);},
        Error: function (a, b, c) { console.log(a); console.log(b); console.log(c); }
    });
    
};
//remove from local playlist
function Removefromqueue(i)
{
    $.ajax({
        type: "Post",
        dataType: "Json",
        url: '/EditPlaylists/deletefromLocalPlaylist',
        data: JSON.stringify(i),
        contentType: "application/json",
        success: function () { console.log(i); },
        Error: function (a, b, c) { console.log(a); console.log(b); console.log(c); },
        complete: function (message) { location.reload(); }

    })
}
//* Saves playlist and prompts user for name*//
function save(user)
{ var name = prompt("Playlist name")
    $.ajax({
        type: "Post",
        dataType: "Json",
        url: '/EditPlaylists/uploadLocalPlaylist',
        data: JSON.stringify(name, user),
        contentType: "application/json",
        success: function () { console.log(Id); },
        Error: function (a, b, c) { console.log(a); console.log(b); console.log(c); },
        complete: function (message) { location.reload(); }

    })
}
//* total duration of playlist */
function duration(Duration)
{
    alert("This playlist is " + Duration + "Minutes long");
}
//sets playlist for adding songs
function Addsongplaylist(playlist)
{
    console.log(playlist)
    $.ajax({
        type: "Post",
        dataType: "Json",
        url: '/EditPlaylists/addsingleplaylist',
        data: JSON.stringify(playlist),
        contentType: "application/json",
        success: function () { console.log(playlist); },
        Error: function (a, b, c) { console.log(a); console.log(b); console.log(c); },
        complete: function () { location.reload(); }
    });
}
//adds song to existing playlist
function Addsong(IdSong)
{
    $.ajax({
        type: "Post",
        dataType: "Json",
        url: '/EditPlaylists/addsingle',
        data: JSON.stringify(IdSong),
        contentType: "application/json",
        success: function () { console.log(IdSong); },
        Error: function (a, b, c) { console.log(a); console.log(b); console.log(c); },
        complete: function () { location.reload(); }
    });
}
//update db playlistname
function Updatename(Id)
{
    var Name = prompt('New playlist name');

    var list = JSON.stringify(
        {
            'Id': Id,
            'Name': Name
        });
    $.ajax({
        type: "Post",
        dataType: "Json",
        traditional: true,
        url: '/EditPlaylists/Updatename',
        data: list,
        contentType: "application/json",
        success: function () { console.log(IdSong); },
        Error: function (a, b, c) { console.log(a); console.log(b); console.log(c); },
        complete: function () { location.reload(); }
    });
}

/*-----------------------------------------------------------------------------------------------------*/
//* detail/song functions*/
function Detailsshow(Duration)
{
    console.log(Duration)
    alert('This song is ' + Duration + " minutes long")

}
//* only shows specific genre */
function specificgenre(Genre)
{
    $.ajax({
        type: "Post",
        dataType: "Json",
        url: '/EditPlaylists/Songsingenre',
        data: JSON.stringify(Genre),
        contentType: "application/json",
        success: function () { console.log(Id); },
        Error: function (a, b, c) { console.log(a); console.log(b); console.log(c); },
        
    })
    select.style.visibility = "visible"
    //    $.ajax({
    //    type: "Post",
    //    dataType: "Json",
    //    url: '/Home/Songs',
    //    data: JSON.stringify(Genre),
    //    contentType: "application/json",
    //    success: function () { console.log(Id); },
    //    Error: function (a, b, c) { console.log(a); console.log(b); console.log(c); },
    //})



    //var genrefront = document.getElementsByClassName("Genres");

    //for (var i = 0; i < genrefront.length; i++)
    //{
    //    genrefront[i].style.display = "None";
    //}
    //var Genreselect = document.getElementById(Genre);
    //Genreselect.style.display = "block"
    //console.log(Genre)
}
//*deletes song from playlist */
function Deletesong(Id) {
    $.ajax({
        type: "Post",
        dataType: "Json",
        url: '/EditPlaylists/Deletesongfromplaylist',
        data: JSON.stringify(Id),
        contentType: "application/json",
        success: function () { console.log(Id); },
        Error: function (a, b, c) { console.log(a); console.log(b); console.log(c); },
        complete: function (message) { location.reload(); }

    })
}
// sends id for specific song view 
function specificgenreview(Id)
{
    $.ajax({
        type: "Post",
        dataType: "Json",
        url: '/EditPlaylists/specificsongview',
        data: JSON.stringify(Id),
        contentType: "application/json",
        success: function () { console.log(Id); },
        Error: function (a, b, c) { console.log(a); console.log(b); console.log(c); },
    })
    select.style.visibility = "visible"
}
