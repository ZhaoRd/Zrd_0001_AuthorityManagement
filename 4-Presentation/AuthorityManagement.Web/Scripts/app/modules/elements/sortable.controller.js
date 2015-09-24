/**=========================================================
 * Module: sortable.js
 * Sortable controller
 =========================================================*/
(function() {
    'use strict';

    angular
        .module('app.elements')
        .controller('SortableController', SortableController);

    SortableController.$inject = ['$scope'];
    function SortableController($scope) {
        // doesn't support controllerAs syntax https://github.com/voidberg/html5sortable/issues/86

        activate();

        ////////////////

        function activate() {
          // Single List
          $scope.data1 = [
            { id: 1, name: 'Donald Hoffman' },
            { id: 2, name: 'Wallace Barrett' },
            { id: 3, name: 'Marsha Hicks' },
            { id: 4, name: 'Roland Brown' }
          ];

          $scope.add = function () {
            $scope.data1.push({id: $scope.data1.length + 1, name: 'Earl Knight'});
          };

          $scope.sortableCallback = function (sourceModel, destModel, start, end) {
            console.log(start + ' -> ' + end);
          };
          
          $scope.sortableOptions = {
              placeholder: '<div class="box-placeholder p0 m0"><div></div></div>',
              forcePlaceholderSize: true
          };
        }
    }

})();
