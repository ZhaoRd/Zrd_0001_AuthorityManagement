/**=========================================================
 * Module: demo-rating.js
 * Provides a demo for ratings UI
 =========================================================*/
(function() {
    'use strict';

    angular
        .module('app.bootstrapui')
        .controller('RatingDemoCtrl', RatingDemoCtrl);

    function RatingDemoCtrl() {
        var vm = this;

        activate();

        ////////////////

        function activate() {
          vm.rate = 7;
          vm.max = 10;
          vm.isReadonly = false;

          vm.hoveringOver = function(value) {
            vm.overStar = value;
            vm.percent = 100 * (value / vm.max);
          };

          vm.ratingStates = [
            {stateOn: 'fa fa-check', stateOff: 'fa fa-check-circle'},
            {stateOn: 'fa fa-star', stateOff: 'fa fa-star-o'},
            {stateOn: 'fa fa-heart', stateOff: 'fa fa-ban'},
            {stateOn: 'fa fa-heart'},
            {stateOff: 'fa fa-power-off'}
          ];
        }
    }
})();
