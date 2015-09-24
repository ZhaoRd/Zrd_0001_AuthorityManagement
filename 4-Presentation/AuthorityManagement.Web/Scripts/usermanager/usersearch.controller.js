/**=========================================================
 * Module: usersearch.js
 * Provides a simple demo for buttons actions
 =========================================================*/

(function () {
    'use strict';

    var app = angular.module('angle');
    app.register.controller('SearchController', SearchController);

    function SearchController() {
        var vm = this;

        activate();

        ////////////////

        function activate() {

            

        }
    }
})();

(function () {
    'use strict';

    var app = angular.module('angle');
    app.register.controller('UserListController', UserListController);

    UserListController.$inject = ['UserService'];
    function UserListController(UserService) {
        var vm = this;

        activate();

        ////////////////

        function activate() {
            console.log('usermanager activate()');
            UserService.getUserList();
        }
    }
})();