(function ($, CIAPI, undefined) {
    AuthenticationWidget = {
        launchPlatform: function (launchPlatformUri) {
            var url = CIAPI.replaceConnectionTokens(launchPlatformUri);
            window.open(url, '', 'width=975,height=575,location=no,resizable=yes');
        },
        storeConnectionInASPNETSession: function (connectionInfo, success) {
            $.ajax({
                type: "POST",
                url: "CIAPI.AspNet.Controls.Authentication/StoreConnectionInSession.ashx",
                data: { CIAPI_connection: JSON.stringify(connectionInfo) },
                contentType: "application/x-www-form-urlencoded; charset=utf-8",
                success: success
            });
        }
    };

    //Tell server about changes to connection status
    CIAPI.subscribe("CIAPI.connection.status", function (newConnection) {
        AuthenticationWidget.storeConnectionInASPNETSession(newConnection, function () {
            console.log('Updated CIAPI.connection on server');
        });
    });
})(jQuery, CIAPI);

