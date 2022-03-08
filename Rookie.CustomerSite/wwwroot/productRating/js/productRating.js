$(".star-review .star")
    .on("mouseover", function () {
        var onStar = parseInt($(this).data("value"), 10); //
        $(this).parent().children("i.star").each(function (e) {
            if (e < onStar) {
                $(this).addClass("hover");
            }
            else {
                $(this).removeClass("hover");
            }
        });
    })

    .on("mouseout", function () {
        $(this).parent().children("i.star").each(function (e) {
            $(this).removeClass("hover");
        });
    });

$(".star-review .star").on("click", function () {
    var onStar = parseInt($(this).data("value"), 10);
    var stars = $(this).parent().children("i.star");

    for (i = 0; i < stars.length; i++) {
        $(stars[i]).removeClass("selected");
    }

    for (i = 0; i < onStar; i++) {
        $(stars[i]).addClass("selected");
    }
});

$(".done").on("click", function () {
    $(".rating-component").hide();
    $(".feedback-tags").hide();
    $(".button-box").hide();
    $(".submited-box").show();
    $(".submited-box .loader").show();

    setTimeout(function () {
        $(".submited-box .loader").hide();
        $(".submited-box .success-message").show();
    }, 1500);
});
