(function () {
    var rowCount = 0;
    var columnCount = 0;
    var privateKey = '';
    var publicKey = '';
    var golden = false;
    var alreadyRedirected = false;

    function parseAmmout() {
        console.log('Launched');
        alreadyRedirected = false;
        jQuery('table.table tbody tr').each(function () {
            rowCount++;
            columnCount = 0;

            jQuery(this).children('td').each(function () {
                var elm = jQuery(this);
                columnCount++;

                switch (columnCount) {
                    case 1:
                        privateKey = elm.text();
                        break;
                    case 2:
                        publicKey = elm.children('a').prop('href');
                        break;
                    case 3:
                        if (elm.text() == "") {
                            // At least one element is not loaded.
                            // Wait for elements to load.
                            
                            if (alreadyRedirected == false) {
                                setTimeout(parseAmmout, 2000);
                            }
                            alreadyRedirected = true;
                            return;
                        }
                        else if (elm.text() != '0') {
                            golden = true;
                            foundKey(privateKey, publicKey, elm.text());
                            return;
                        }
                        break;
                }
            });
        });
        if (alreadyRedirected == false) {
            goToNextPage();
        }
    }

    function goToNextPage() {
        dotnetcallback.callNextPage();
    }

    function foundKey(privateKey, publicKey, amount) {
        dotnetcallback.foundKey(document.URL, privateKey, publicKey, amount);
    }

    setTimeout(parseAmmout, 2000);
})();