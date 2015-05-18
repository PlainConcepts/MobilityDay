angular.module('starter.services', ['ngResource'])

.factory('Session', function ($resource) {
    return $resource('http://169.254.80.80:5000/sessions/:sessionId');
});
