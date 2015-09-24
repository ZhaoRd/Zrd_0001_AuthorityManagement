/**=========================================================
 * Module: demo-popover.js
 * Provides a simple demo for popovers
 =========================================================*/

(function() {
    'use strict';

    angular
        .module('app.bootstrapui')
        .controller('PopoverDemoCtrl', PopoverDemoCtrl);

    function PopoverDemoCtrl() {
        var vm = this;

        activate();

        ////////////////

        function activate() {
          vm.dynamicPopover = 'Hello, World!';
          vm.dynamicPopoverTitle = 'Title';
        }
    }
})();
