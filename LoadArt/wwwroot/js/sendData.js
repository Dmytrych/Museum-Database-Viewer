function SendPicData(){
    let name = document.getElementById("name");
    let author = document.getElementById("author");
    let creationYear = document.getElementById("creationYear");
    let style = document.getElementById("style");
    let epoch = document.getElementById("epoch");
    let medium = document.getElementById("medium");
    let width = document.getElementById("width");
    let height = document.getElementById("height");
    let plot = document.getElementById("plot");
    let cost = document.getElementById("cost");
    let image = document.getElementById("image");

    var req = new XMLHttpRequest();
    req.open('POST', 'https://localhost:44378/dataadding/uploaddata?name=' + name.value +
    '&author=' + author.value +
    '&creationYear=' + creationYear.value +
    '&style=' + style.value +
    '&epoch=' + epoch.value + 
    '&medium=' + medium.value +
    '&width=' + width.value +
    '&height=' + height.value +
    '&plot=' + plot.value +
    '&cost=' + cost.value, false)
    req.send()
    let statusMessage;
    if(req.status != 200){
        statusMessage = "Data sending error:" + req.status
    }
    else{
        statusMessage = "Data sent successfully"
    }
    alert(statusMessage)
    document.location.replace("https://localhost:44378/home");
}