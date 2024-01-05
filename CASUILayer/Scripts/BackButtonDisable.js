    function preventBack() {
        window.history.forward();
    }

    // Call preventBack when the document is ready
    document.addEventListener("DOMContentLoaded", function () {
        preventBack();
    });

   
window.onunload = function () { null };