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
let menuOpen;
function scrollMenuLeft(){
    if(menuOpen){
        $('#slide-menu').each(function() {
            $(this).animate({
                left: '-30rem',
            }, 300 );
        });
        $('#hamburger-icon').attr("src","https://upload.wikimedia.org/wikipedia/commons/thumb/b/b2/Hamburger_icon.svg/1200px-Hamburger_icon.svg.png")
    }
    else{
        $('#slide-menu').each(function() {
            $(this).animate({
                left: '0',
            }, 300 );
        });
        $('#hamburger-icon').attr("src","https://icons-for-free.com/download-icon-close+cross+delete+exit+remove+icon-1320085939816384527_512.png")
    }
    menuOpen= !menuOpen;
}
// Write your JavaScript code.