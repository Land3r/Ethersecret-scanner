(function () {
    /**
     * Gets or sets the current row index of the table.
     */
    var rowCount = 0;

    /**
     * Gets or sets the current column index of the table.
     */
    var columnCount = 0;

    /**
     * Gets or sets the current row private key retrieved.
     */
    var privateKey = '';

    /**
     * Gets or sets the current row public key.
     */
    var publicKey = '';

    /**
     * Gets whether or not any account with a non empty amount of ETH has been found.
     */
    var golden = false;

    /**
     * Gets or sets whether or not the redirection to the next page has happened.
     */
    var alreadyRedirected = false;

    /**
     * Gets or sets a counter for the number of parseAmmount count.
     */
    var timeoutCount = 0;

    function parseAmmout() {
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
                            else {
                                setTimeout(parseAmmout, 10000);
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
        timeoutCount = 0;
        dotnetcallback.callNextPage();
    }

    function foundKey(privateKey, publicKey, amount) {
        dotnetcallback.foundKey(document.URL, privateKey, publicKey, amount);
    }

    setTimeout(parseAmmout, 2000);
})();