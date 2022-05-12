// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function hideElement(elementId){
    document.getElementById(elementId).style.display = "none"
}
function showElement(elementId){
    document.getElementById(elementId).style.display = "block"
}

function openShipment(shipmentId) {
    $("#info-box-back-wall").children().each(function(element){
        $(element).hide();
    });
    var settings = {
        "url": "https://localhost:5001/Shipment/GetShipmentArticles/" + shipmentId,//todo test this
        "method": "GET",
        "timeout": 0,
        "headers": {
            "Content-Type": "application/json"
        }
    };
    $.ajax(settings).then((response) => {
        let res = JSON.parse(response);
        //fill in modal with data
        $("#info-box-id").text(shipmentId);
        $("#info-box-date").text(res.shipment.Date);
        let x = 0;
        res.shipmentArticles.forEach(element => {
            clonedContent = $("#article-container").clone(true, true)
                .attr('id', "shipmentArticle-" + x)
                .show();
            $("#delivery-modal").append($(clonedContent));
            $(clonedContent).find(".article-container-name").attr('src', element.Article.Name)
            $(clonedContent).find(".article-container-amount").attr('src', element.Article.Amount)
            $(clonedContent).find(".article-image").attr('src', element.Article.ImgRef)
            x++;
        });
        showElement('delivery-modal');
    });
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



// var settings = {
//         "url": "https://server.kattenradar.nl/CRB/contact-ticket",
//         "method": "POST",
//         "timeout": 0,
//         "headers": {
//             "Content-Type": "application/x-www-form-urlencoded"
//         },
//         "data": {
//             tip: {
//                 content: tip.content,
// 
//             },
//             email: email,
//             phone: phone
//         }
//     };
//     $.ajax(settings).done(function (response) {
//         if (response !== 'failed') {
// 
//         }
//     });