/**=========================================================
 * Module: demo-toaster.js
 * Demos for toaster notifications
 =========================================================*/

(function() {
    'use strict';

    angular
        .module('app.elements')
        .controller('ToasterDemoCtrl', ToasterDemoCtrl);

    ToasterDemoCtrl.$inject = ['toaster'];
    function ToasterDemoCtrl(toaster) {
        var vm = this;

        activate();

        ////////////////

        function activate() {
          vm.toaster = {
              type:  'success',
              title: 'Title',
              text:  'Message'
          };

          vm.pop = function() {
            toaster.pop(vm.toaster.type, vm.toaster.title, vm.toaster.text);
          };
        }
    }
})();
