// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function hideElement(elementId){
    document.getElementById(elementId).style.display = "none"
}
function showElement(elementId){
    document.getElementById(elementId).style.display = "block"
}

function showArticleElement(elementId, name, category, price, description, imgurl){
    $("#" + elementId).show()
    $("#articleImg").attr("src", imgurl)
    $("#articleName").text(name)
    $("#articleCategory").text(category)
    $("#articlePrice").text(price)
    $("#articleDescription").text(description)
}
// Write your JavaScript code.