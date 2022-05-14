// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function hideElement(elementId) {
    document.getElementById(elementId).style.display = "none"
}

function showElement(elementId) {
    document.getElementById(elementId).style.display = "block"
}

function openShipment(shipmentId) {
    $("#articleList").empty();
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
        let date = new Date(res.shipment.Date)
        $("#info-box-date").text(date.toISOString().substring(0,10));
        let x = 0;
        alert("0")
        res.shipmentArticles.forEach(element => {
            alert("1")
            clonedContent = $("#article-container").clone(true, true)
                .attr('id', "shipmentArticle-" + x)
                .show();
            $("#articleList").append($(clonedContent));
            $(clonedContent).find(".article-container-name").text(element.Article.Name)
            $(clonedContent).find(".article-container-amount").text(element.ScannedAmount + "/" + element.Amount)
            $(clonedContent).find(".article-image").attr('src', element.Article.ImgRef)
            $(clonedContent).find(".article-barcode").text(element.Article.Barcode)
            x++;
        });
        showElement('delivery-modal');
        alert("2")
    });
}

//adds 1 to the amount of scanned articles from this barcode
function scanArticle(barcode) {
    $("#delivery-container").children().each(function (element) {
        if ($(element).find(".article-barcode").text() === barcode) {
            let values = $(clonedContent).find(".article-container-amount").text().split("/");
            if (values[0] < values[1]) {
                $(element).find(".article-container-amount").text(parseInt(values[0]) + 1 + "/" + values[1]);
            } else {
                alert("Article max amount is already scanned");
            }
        }
    });
}

//adds the given amount to the amount of scanned articles from this barcode
function scanArticleAmount(barcode, amount) {
    if (amount > 0) {
        $("#delivery-container").children().each(function (element) {
            if ($(element).find(".article-barcode").text() === barcode) {
                let values = $(clonedContent).find(".article-container-amount").text().split("/");
                if (values[0] + amount <= values[1]) {
                    $(element).find(".article-container-amount").text(parseInt(values[0]) + amount + "/" + values[1]);
                } else {
                    alert("This amount is too high");
                }
            }
        });
    } else {
        alert("Amount must be greater than 0");
    }
}

//submits the scanned articles to the server
function submitShipment() {
    let shipmentId = $("#info-box-id").text();
    let shipmentArticles = [];
    $("#delivery-container").children().each(function (element) {
        let values = $(element).find(".article-container-amount").text().split("/");
        shipmentArticles.push({
            ShipmentId: shipmentId,
            ArticleId: $(element).find(".article-barcode").text(),
            ScannedAmount: values[0]
        });
    });
    var settings = {
        "url": "https://localhost:5001/Shipment/PostShipmentProcess/",//todo test this
        "method": "Post",
        "timeout": 0,
        "headers": {
            "Content-Type": "application/json"
        },
        data: JSON.stringify(shipmentArticles)
    };
    $.ajax(settings).done(function (response) {
        if (response.success) {
            hideElement('delivery-modal');
            alert("Shipment submitted");
        } else {
            alert("Shipment could not be submitted");
        }
    });
}
        

function showArticleElement(elementId, name, category, price, description, imgurl) {
    $("#" + elementId).show()
    $("#articleImg").attr("src", imgurl)
    $("#articleName").text(name)
    $("#articleCategory").text(category)
    $("#articlePrice").text(price)
    $("#articleDescription").text(description)
}

function showArticleView(elementId, name, category, quantity, locations) {
    $("#" + elementId).show()
    $("#view-article-modal-name-label").text(name)
    $("#view-article-modal-category-label").text(category)
    $("#view-article-modal-quantity-label").text(quantity)
    $("#view-article-modal-textarea").text(locations)
}

let menuOpen;

function scrollMenuLeft() {
    if (menuOpen) {
        $('#slide-menu').each(function () {
            $(this).animate({
                left: '-30rem',
            }, 300);
        });
        $('#hamburger-icon').attr("src", "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b2/Hamburger_icon.svg/1200px-Hamburger_icon.svg.png")
    } else {
        $('#slide-menu').each(function () {
            $(this).animate({
                left: '0',
            }, 300);
        });
        $('#hamburger-icon').attr("src", "https://icons-for-free.com/download-icon-close+cross+delete+exit+remove+icon-1320085939816384527_512.png")
    }
    menuOpen = !menuOpen;
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