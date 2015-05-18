var exec = require('cordova/exec');
var platform = require('cordova/platform');

module.exports = {

    echo: function(message, completeCallback, title, buttonLabel) {
        exec(completeCallback, null, "Echo", "echo", [message]);
    }
};
