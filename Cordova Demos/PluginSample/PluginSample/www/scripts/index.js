// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkID=397704
// To debug code on page load in Ripple or on Android devices/emulators: launch your app, set breakpoints, 
// and then run "window.location.reload()" in the JavaScript Console.
(function () {
    "use strict";

    var watchId = null;

    document.addEventListener('deviceready', onDeviceReady.bind(this), false);

    function onDeviceReady() {
        // Handle the Cordova pause and resume events
        document.addEventListener('pause', onPause.bind(this), false);
        document.addEventListener('resume', onResume.bind(this), false);

        // Cordova has been loaded. Perform any initialization that requires Cordova here.
        startWatch();
        showBatteryStatus();
        initCreateContact();
        initScan();
        initEcho();
    };

    function onPause() {
        // TODO: This application has been suspended. Save application state here.
    };

    function onResume() {
        // TODO: This application has been reactivated. Restore application state here.
    };

    function startWatch() {
        var options = { frequency: 500 };

        watchId = navigator.accelerometer.watchAcceleration(onWatchSuccess, onWatchError, options);

    };

    function initEcho() {

        navigator.echo.echo('testing echo', function (str) {
            navigator.notification.alert('Echo' + str);
        });

    };

    function stopWatch() {
        if (watchId) {
            navigator.accelerometer.clearWatch(watchId);
            watchId = null;
        }
    };

    function onWatchSuccess(acceleration) {
        var element = document.getElementById('accelerometer');

        element.innerHTML = 'Acceleration X:' + acceleration.x + '<br/>' +
            'Acceleration Y:' + acceleration.y + '<br/>' +
            'Acceleration Z:' + acceleration.z + '<br/>' +
            'Timestamp:' + acceleration.timestamp + '<br/>';
    };

    function onWatchError(error) {

    };

    function showBatteryStatus() {
        window.addEventListener("batterycritical", battCrit, false);
        window.addEventListener("batterylow", battLow, false);
        window.addEventListener("batterystatus", battStat, false);
    };

    function battLow() {
        navigator.notification.alert('Your battery is low!');
    };

    function battCrit() {
        navigator.notification.alert('Your battery is SUPER low!');
    };

    function battStat(info) {
        var element = document.getElementById('battery');

        element.innerHTML = 'Level is ' + info.level + '<br/>' +
            'Plugged in is ' + info.isPlugged + '<br/>';
    };

    function initCreateContact() {
        document.getElementById('butCreateContact').addEventListener('click', createContact);
        document.getElementById('butPickContact').addEventListener('click', pickContact);
    };

    function initScan() {
        document.getElementById('butScan').addEventListener('click', scan);
    };

    function createContact() {

        // create a new contact object
        var contact = navigator.contacts.create();
        contact.displayName = "Demo Cordova";
        contact.nickname = "Demo Cordova";            // specify both to support all devices

        // populate some fields
        var name = new ContactName();
        name.givenName = "Jane";
        name.familyName = "Doe";
        contact.name = name;
        contact.note = 'This contact has a note';

        // save to device
        contact.save(onContactSuccess, onContactError);

        console.log('The contact' + contact.displayName + ', note: ' + contact.note);
    };

    function onContactSuccess() {
        navigator.notification.alert('Contact successfully added!');
    };

    function onContactError(error) {
        navigator.notification.alert('Error creating contact!');
    };

    function pickContact() {
        navigator.contacts.pickContact(function (contact) {

            var element = document.getElementById('contactDetail');
            var msg = 'The following contact has been selected:' + JSON.stringify(contact);
            element.innerHTML = msg;

            console.log('The following contact has been selected:' + JSON.stringify(contact));
        }, function (err) {
            console.log('Error: ' + err);
        });
    };

    function scan() {
        cordova.plugins.barcodeScanner.scan(
            function (result) {
                navigator.notification.alert("We got a barcode\n" +
                    "Result: " + result.text + "\n" +
                    "Format: " + result.format + "\n" +
                    "Cancelled: " + result.cancelled);
            },
      function (error) {
          alert("Scanning failed: " + error);
      }
   );
    };

})();