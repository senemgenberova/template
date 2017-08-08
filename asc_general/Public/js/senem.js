jQuery(document).ready(function ($) {
    console.log(window.location.pathname);
    //menu searching starts
    var clickNumber = 0;
    var searchString = "";

    $("#icons").find("li").eq(0).click(function () {
        var search = $(".search");  
        search.css({ "background-color": "#646a82", "color": "white", "border-color": "#646a82" });
        $(this).siblings().hide();
        $(".search_tool").show();
        search.addClass("no_hover").children().hide();
        clickNumber++;

        searchString = $(".search_tool").find("input").val();     
        if (clickNumber === 2) {
            if (window.location.pathname === "/search/index") {
                search.attr("href", "?page=1&searchString=" + searchString);
            }
            else {
                search.attr("href", "search/index?page=1&searchString=" + searchString);
            }
            clickNumber = 0;
        }
    });

    $(".search_tool").find("input").keydown(function (event) {
        searchString = $(".search_tool").find("input").val();

        if (event.keyCode === 13) {
            if (window.location.pathname === "/search/index") {
                window.location.href = "?page=1&searchString=" + searchString;
            }
            else {
                window.location.href = "search/index?page=1&searchString=" + searchString;
            }
        }
    });

    //Window clicking

    $(window).click(function (e) {
        if ($(e.target).hasClass("fa-search") || $(e.target).parent().hasClass("search_tool")) {
            clickNumber = 1;
            return true;
        }
        else {
            $(".search").removeClass("no_hover").css({ "background-color": "", "color": "" }).children().show();
            $(".search").parent().siblings().show();
            $(".search_tool").hide().find("input").val("");
            clickNumber = 0;
        }
    });

    //menu searching ends

    // *NAME*

    // letter color change starts
    function babyNamesColorChange(x, eq, color) {
        $(".baby_names").eq(eq).find("a").on({
            mouseenter: function () {
                $(this).css("color", color);
            },

            mouseleave: function () {
                $(this).css("color", "#646a82");
            },

            click: function () {
                $(".baby_names").eq(x).find("a").css("color", "#646a82");
                $(this).unbind("mouseenter mouseleave").css("color", color).parent().siblings().find("a").css("color", "#646a82");
            }
        });
    }

    for (var i = 0; i < 2; i++) {
        if (i === 0) {
            babyNamesColorChange(i + 1, i, "#FFAAAA");
        }
        else {
            babyNamesColorChange(i - 1, i, "#AAD4FF");
        }
    }

    // letter color change ends

    $(".searching").find("button").click(function () {
        searchString = $("#searchString").val();
        $(this).children().attr("href", "?page=1&searchString=" + searchString);
    });

    $("#searchString").keydown(function (event) {
        searchString = $("#searchString").val();
        if (event.keyCode == 13) {
            window.location.href = "?page=1&searchString=" + searchString;
        }
    })

    $(function () {
        var availableTags = [
            "ActionScript",
            "AppleScript",
            "Asp",
            "BASIC",
            "C",
            "C++",
            "Clojure",
            "COBOL",
            "ColdFusion",
            "Erlang",
            "Fortran",
            "Groovy",
            "Haskell",
            "Java",
            "JavaScript",
            "Lisp",
            "Perl",
            "PHP",
            "Python",
            "Ruby",
            "Scala",
            "Scheme"
        ];
        $("#searchString").autocomplete({
            source: availableTags
        });
    });
});