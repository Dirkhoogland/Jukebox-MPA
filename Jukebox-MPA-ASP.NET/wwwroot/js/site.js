var userinput = document.getElementById(userinput);


//* user related functions */
function Newuser()
{
    
    console.log(username)
    var userinputj = document.getElementById(userinput).value;
    $.ajax({
        type: "Post",
        dataType: "Json",
        url: '/User/Newuser',
        data: JSON.stringify(userinputj.innerHTML),
        contentType: "application/json",
        success: function () { console.log(Id); },
        Error: function (a, b, c) { console.log(a); console.log(b); console.log(c); }
    });
    location.reload();
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

    location.reload();

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
    location.reload();
};
function save(user)
{
    $.ajax({
        type: "Post",
        dataType: "Json",
        url: '/EditPlaylists/uploadLocalPlaylist',
        data: JSON.stringify(user),
        contentType: "application/json",
        success: function () { console.log(Id); },
        Error: function (a, b, c) {console.log(a); console.log(b); console.log(c);}

    })
}


/*-----------------------------------------------------------------------------------------------------*/
//* detail/song functions*/
function Detailsshow(Duration)
{
    console.log(Duration)
    alert('This song is ' + Duration + " minutes long")

}

function specificgenre(Genre)
{   
    console.log(Genre)
}