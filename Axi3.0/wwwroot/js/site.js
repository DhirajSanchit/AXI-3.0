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

function showArticleView(elementId, name, category, quantity, locations){
    $("#" + elementId).show()
    $("#view-article-modal-name-label").text(name)
    $("#view-article-modal-category-label").text(category)
    $("#view-article-modal-quantity-label").text(quantity)
    $("#view-article-modal-textarea").text(locations)
}
// Write your JavaScript code.