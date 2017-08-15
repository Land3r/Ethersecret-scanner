(function () {
    function addStyleString(str) {
        var node = document.createElement('style');
        node.innerHTML = str;
        document.body.appendChild(node);
    }

    // Content of /Styles/Styles.css
    addStyleString("nav { display:none; }");
    addStyleString("div.row.text-center { display:none; }");
    addStyleString("div.text-center.col-md-12 > div.col-md-4 { display:none; }");
})();