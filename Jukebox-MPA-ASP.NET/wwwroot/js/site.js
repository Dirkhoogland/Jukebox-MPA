

function addtoqueue(Id)
{    
    console.log(Id)

    $.ajax({
        type: "Post",
        dataType: "Json",
        url: '/Home/addtoqueue',
        data: JSON.stringify(Id),
        contentType: "application/json",
        success: function () { console.log(Id);},
        Error: function (a, b, c) { console.log(a); console.log(b); console.log(c); }
    });
};

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