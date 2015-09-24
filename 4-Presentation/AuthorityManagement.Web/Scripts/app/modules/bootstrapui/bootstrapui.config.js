(function() {
    'use strict';

    angular
        .module('app.bootstrapui')
        .config(bootstrapuiConfig);

    bootstrapuiConfig.$inject = ['$tooltipProvider'];
    function bootstrapuiConfig($tooltipProvider){
      $tooltipProvider.options({appendToBody: true});
    }
})();