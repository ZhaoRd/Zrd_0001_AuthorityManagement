
 (function() {
    'use strict';

      angular.module('angle', [
         'app.core',
         'app.routes',
         'app.sidebar',
         'app.navsearch',
         'app.preloader',
         'app.loadingbar',
         'app.translate',
         'app.settings',
         'app.bootstrapui',

         //'app.lazyload',

         'app.utils'
     ]);

     var app = angular.module('angle');

     // 为了子视图能够正确加载到controller等相关内容，必须使用register的方法才行
     app.config(function ($controllerProvider, $compileProvider, $filterProvider, $provide) {
         app.register = {
            controller: $controllerProvider.register,
            directive: $compileProvider.directive,
            filter: $filterProvider.register,
            factory: $provide.factory,
            service:$provide.service
         };

     });

 })();




