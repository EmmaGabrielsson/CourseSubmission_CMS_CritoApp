
    document.addEventListener("DOMContentLoaded", function() {
        // Check if there is a 'page' query parameter
        var queryParams = new URLSearchParams(window.location.search);
        var pageParam = queryParams.get("page");

        if (pageParam) {
            // Scroll to the 'small-article-section' div when the page loads
            var targetSection = document.getElementById("small-article-section");

            if (targetSection) {
                var offsetTop = targetSection.getBoundingClientRect().top + window.scrollY;
                window.scrollTo({
                    top: offsetTop,
                    behavior: "smooth"
                });
            }
        }
    });

