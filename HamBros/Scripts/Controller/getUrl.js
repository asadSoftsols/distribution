var id;
function getid() {
    var url = window.location.pathname;
    id = url.substring(url.lastIndexOf('/') + 1);

    //if (id === parseInt(id, 10))
    {

        document.getElementById("ProductTypeID").value = id;
    }

}
//Getting Id from URL
getid();

