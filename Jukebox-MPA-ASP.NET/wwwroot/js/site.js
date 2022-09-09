var userinput = document.getElementById(userinput);
var genrefront = document.getElementById('Genres')

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
        Error: function (a, b, c) { console.log(a); console.log(b); console.log(c); }
    });
    
}

function Login(Id)
{
    console.log(Id)

    $.ajax({
        type: "Post",
        dataType: "Json",
        url: '/User/login',
        data: JSON.stringify(Id),
        contentType: "application/json",
        success: function () { console.log(Id); },
        Error: function (a, b, c) { console.log(a); console.log(b); console.log(c); }
    });
    /*location.reload();*/
}
function Deleteuser(Id)
{
    $.ajax({
        type: "Post",
        dataType: "Json",
        url: '/User/Delete',
        data: JSON.stringify(Id),
        contentType: "application/json",
        success: function () { console.log(Id); },
        Error: function (a, b, c) { console.log(a); console.log(b); console.log(c); }
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
//* Saves playlist and promps user for name*//
function save(user)
{ var name = prompt("Playlist name")
    $.ajax({
        type: "Post",
        dataType: "Json",
        url: '/EditPlaylists/uploadLocalPlaylist',
        data: JSON.stringify(name),
        contentType: "application/json",
        success: function () { console.log(Id); },
        Error: function (a, b, c) {console.log(a); console.log(b); console.log(c);}

    })
}
//* total duration of playlist */
function duration(Duration)
{
    alert("This playlist is " + Duration + "Minutes long");
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
    genrefront.style.visibility = "hidden"
    var Genreselect = document.getElementById(Genre);
    Genreselect.style.visibility = "Visible"
    console.log(Genre)
}
function Deletesong(song)
{
    $.ajax({
        type: "Post",
        dataType: "Json",
        url: '/EditPlaylists/Deletesongfromplaylist',
        data: JSON.stringify(song),
        contentType: "application/json",
        success: function () { console.log(Id); },
        Error: function (a, b, c) { console.log(a); console.log(b); console.log(c); }

    })
}