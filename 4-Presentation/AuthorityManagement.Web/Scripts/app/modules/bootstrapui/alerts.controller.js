/**=========================================================
 * Module: demo-alerts.js
 * Provides a simple demo for pagination
 =========================================================*/
(function() {
    'use strict';

    angular
        .module('app.bootstrapui')
        .controller('AlertDemoCtrl', AlertDemoCtrl);

    function AlertDemoCtrl() {
        var vm = this;

        activate();

        ////////////////

        function activate() {
          vm.alerts = [
            { type: 'danger', msg: 'Oh snap! Change a few things up and try submitting again.' },
            { type: 'warning', msg: 'Well done! You successfully read this important alert message.' }
          ];

          vm.addAlert = function() {
            vm.alerts.push({msg: 'Another alert!'});
          };

          vm.closeAlert = function(index) {
            vm.alerts.splice(index, 1);
          };
        }
    }
})();
