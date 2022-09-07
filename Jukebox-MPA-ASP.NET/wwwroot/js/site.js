var userinputj = document.getElementById(userinput).value;

function Newuser()
{
    console.log(username)
    
    $.ajax({
        type: "Post",
        dataType: "Json",
        url: '/User/Newuser',
        data: JSON.stringify(userinputj),
        contentType: "application/json",
        success: function () { console.log(Id); },
        Error: function (a, b, c) { console.log(a); console.log(b); console.log(c); }
    });
    /*location.reload();*/
}

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

function Detailsshow(Duration)
{
    console.log(Duration)
    alert('This song is ' + Duration + " minutes long")

}

function specificgenre(Genre)
{   
    console.log(Genre)
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

//function addtoqueue(Id)
//{   
//    $.ajax({
//        type: "Post",
//        dataType: "Json",
//        url: 'GenreQueue',
//        data: JSON.stringify(Id),
//        contentType: "application/json",
//        success: function () { console.log(Id);},
//        Error: function (a, b, c) { console.log(a); console.log(b); console.log(c); }
//    });
//};