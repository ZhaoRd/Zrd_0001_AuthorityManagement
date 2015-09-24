(function () {
    'use strict';

    var app = angular.module('angle');
    app.register
        .service('UserService', UserService);

    UserService.$inject = ['$http'];

    function UserService($http) {
        var self = this;
        
        active();

        function active() {

            console.log('userservice  active()');

        };

        self.getUserList = function() {

            $http.post('UserManager/List')
                .success(function(data, status, headers, config) {

                })
                .error(function(data, status, headers, config) {

                });
        };

        return self;
    }

})();