// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
let menuOpen;
let wait = false;

//
function hideElement(elementId) {
    document.getElementById(elementId).style.display = "none"
}

//
function showElement(elementId) {
    document.getElementById(elementId).style.display = "block"
}

//
function openShipment(shipmentId) {
    //todo keep this?
    if(wait) {
        return;
    }
    wait = true;
    $("#article-list").empty();
    var settings = {
        "url": "https://localhost:5001/Shipment/GetShipmentArticles/",//todo test this
        "method": "GET",
        "timeout": 0,
        "headers": {
            "Content-Type": "application/json"
        },
        data: {shipmentId: shipmentId}
    };
    $.ajax(settings).then((response) => {
        let res = JSON.parse(response);
        //fill in modal with data
        $("#info-box-id").text(shipmentId);
        let date = new Date(res.shipment.Date)
        $("#info-box-date").text(date.toISOString().substring(0,10));
        let x = 0;
        res.shipmentArticles.forEach(element => {
            clonedContent = $("#article-container").clone(true, true)
                .attr('id', "shipmentArticle-" + x)
                .show();
            $("#article-list").append($(clonedContent));
            $(clonedContent).find(".article-container-name").text(element.Article.Name)
            $(clonedContent).find(".article-container-amount").text(element.ScannedAmount + "/" + element.Amount)
            $(clonedContent).find(".article-image").attr('src', element.Article.ImgRef)
            $(clonedContent).find(".article-barcode").text(element.Article.Barcode)
            $(clonedContent).find(".article-id").text(element.Article.Id)
            x++;
        });
        showElement('delivery-modal');
        wait = false;
    });
}

//
function openOrder(orderId) {
    //todo keep this?
    if(wait) {
        return;
    }
    wait = true;
    $("#article-list").empty();
    var settings = {
        "url": "https://localhost:5001/Order/GetOrderArticles/",//todo test this
        "method": "GET",
        "timeout": 0,
        "headers": {
            "Content-Type": "application/json"
        },
        data: {orderId: orderId}
    };
    $.ajax(settings).then((response) => {
        let res = JSON.parse(response);
        //fill in modal with data
        $("#info-box-id").text(orderId);
        let date = new Date(res.order.Date)
        $("#info-box-date").text(date.toISOString().substring(0,10));
        let x = 0;
        res.orderArticles.forEach(element => {
            clonedContent = $("#article-container").clone(true, true)
                .attr('id', "orderArticle-" + x)
                .show();
            $("#article-list").append($(clonedContent));
            $(clonedContent).find(".article-container-name").text(element.Article.Name)
            $(clonedContent).find(".article-container-amount").text(element.ScannedAmount + "/" + element.Amount)
            $(clonedContent).find(".article-image").attr('src', element.Article.ImgRef)
            $(clonedContent).find(".article-barcode").text(element.Article.Barcode)
            $(clonedContent).find(".article-id").text(element.Article.Id)
            x++;
        });
        showElement('order-modal');
        wait = false;
    });
}

//adds 1 to the amount of scanned articles from this barcode
function scanDeliveryArticleAdd(barcode) {
    $(".add-btn-container").each(function (){
        if ($(this).parent().find(".article-barcode").text() === barcode) {
            let values = $(this).parent().find(".article-container-amount").text().split("/");
                    if (+values[0] < +values[1]) {
                        $(this).parent().find(".article-container-amount").text(parseInt(values[0]) + 1 + "/" + values[1]);
                        submitShipment();
                    } else {
                        alert("Article max amount is already scanned");
                    }
        }
    })
}

//
function scanDeliveryArticleRemove(barcode) {
    $(".remove-btn-container").each(function () {
        if ($(this).parent().find(".article-barcode").text() === barcode) {
            let values = $(this).parent().find(".article-container-amount").text().split("/");
            if (+values[0] > 0) {
                $(this).parent().find(".article-container-amount").text(parseInt(values[0]) - 1 + "/" + values[1]);
                submitShipment();
            } else {
                alert("Article amount is already 0");
            }
        }
    });
}

//
function scanOrderArticleAdd(barcode) {
    $(".add-btn-container").each(function (){
        if ($(this).parent().find(".article-barcode").text() === barcode) {
            let values = $(this).parent().find(".article-container-amount").text().split("/");
            if (+values[0] < +values[1]) {
                $(this).parent().find(".article-container-amount").text(parseInt(values[0]) + 1 + "/" + values[1]);
                submitOrder();
            } else {
                alert("Article max amount is already scanned");
            }
        }
    })
}

//
function scanOrderArticleRemove(barcode) {
    $(".remove-btn-container").each(function () {
        if ($(this).parent().find(".article-barcode").text() === barcode) {
            let values = $(this).parent().find(".article-container-amount").text().split("/");
            if (+values[0] > 0) {
                $(this).parent().find(".article-container-amount").text(parseInt(values[0]) - 1 + "/" + values[1]);
                submitOrder();
            } else {
                alert("Article amount is already 0");
            }
        }
    });
}

//adds the given amount to the amount of scanned articles from this barcode
function setDeliveryArticleAmount(barcode, amount) {
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

//
function setOrderArticleAmount(barcode, amount) {
    if (amount > 0) {
        $("#order-container").children().each(function (element) {
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
    let shipmentArticlesArr = [];
    let processed = true;
    $("#article-list").children().each(function () {
        let values = $(this).find(".article-container-amount").text().split("/");
        shipmentArticlesArr.push({
                ShipmentId: shipmentId,
                ArticleId: $(this).find(".article-id").text(),
                ScannedAmount: values[0],
                Amount: values[1]
        });
        if(values[0] !== values[1]) {
            processed = false;
        }
    });
    let shipmentArticles = JSON.stringify({shipmentArticles:shipmentArticlesArr});
    var settings = {
        "url": "https://localhost:5001/Shipment/PostShipmentProcess/",
        "method": "GET",
        "timeout": 0,
        "headers": {
            "Content-Type": "application/json"
        },
        data: {shipmentArticles: shipmentArticles, processed: processed}
    };
    $.ajax(settings).done(function () {
    }).catch(function () {
        alert("Error submitting shipment");
    });
}

//
function submitOrder() {
    let orderId = $("#info-box-id").text();
    let orderArticlesArr = [];
    let processed = true;
    $("#article-list").children().each(function () {
        let values = $(this).find(".article-container-amount").text().split("/");
        orderArticlesArr.push({
                OrderId: orderId,
                ArticleId: $(this).find(".article-id").text(),
                ScannedAmount: values[0],
                Amount: values[1]
        });
        if(values[0] !== values[1]) {
            processed = false;
        }
    });
    let orderArticles = JSON.stringify({orderArticles:orderArticlesArr});
    var settings = {
        "url": "https://localhost:5001/Order/PostOrderProcess/",//todo test this
        "method": "GET",
        "timeout": 0,
        "headers": {
            "Content-Type": "application/json"
        },
        data: {orderArticles: orderArticles, processed: processed}
    };
    $.ajax(settings).done(function () {
        window.location.href = "https://localhost:5001/Order/ScannerOrder";
    }).catch(function () {
        alert("Error submitting order");
    });
}

//
function showArticleElement(elementId, name, category, price, description, imgurl) {
    $("#" + elementId).show()
    $("#articleImg").attr("src", imgurl)
    $("#articleName").text(name)
    $("#articleCategory").text(category)
    $("#articlePrice").text(price)
    $("#articleDescription").text(description)
}

//
function showArticleView(elementId, name, category, quantity, locations) {
    $("#" + elementId).show()
    $("#view-article-modal-name-label").text(name)
    $("#view-article-modal-category-label").text(category)
    $("#view-article-modal-quantity-label").text(quantity)
    $("#view-article-modal-textarea").text(locations)
}

//
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
