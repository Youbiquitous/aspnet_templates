////////////////////////////////////////////////////////////////////
// Sticky and scrollable content
//



Ybq.scrollContent = function(headerId) {
    var header = document.getElementById(headerId);
    var sticky = header.offsetTop;

    if (window.pageYOffset > sticky) {
        header.classList.add("ybq-sticky-element");
    } else {
        header.classList.remove("ybq-sticky-element");
    }
};

