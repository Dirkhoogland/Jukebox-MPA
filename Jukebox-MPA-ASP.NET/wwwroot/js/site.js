

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

function Detailsshow(Duration)
{
    console.log(Duration)
    alert('This song is ' + Duration + " minutes long")

}

function specificgenre(Genre, Author)
{
    console.log(Genre)
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