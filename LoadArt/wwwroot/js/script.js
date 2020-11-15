function browseData(){
    let requestData = [];
    let request = new XMLHttpRequest();

    request.open('GET', 'https://localhost:44378/home/LoadData/', false);

    request.send();

    if(request.status != 200){
        alert("Browsing problems: " + request.status)
    }
    else{
        let dataBox = document.getElementById("data-display")
        requestData = JSON.parse(request.response)
        for(i = 0; i < requestData.length; i++){
            dataBox.innerHTML += "<div class=\"data-container\">" +
            "<div class=\"picture\">" +
            "<img src=\"images/image.jpg\">" +
            "</div>" +
            "<div class=\"picture-info\">" +
                "<a>Author: " + requestData[i].Author + "</a><br>" +
                "<a>Name: " + requestData[i].Name + " </a>" +
            "</div>"+
        "</div>";
        }
    }
}

//browseData()