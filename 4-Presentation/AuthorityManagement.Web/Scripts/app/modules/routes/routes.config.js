/**=========================================================
 * Module: config.js
 * App routes and resources configuration
 =========================================================*/


(function() {
    'use strict';

    angular
        .module('app.routes')
        .config(routesConfig)
        .run(['requestErrorHandler', '$state', '$location', function (requestErrorHandler, $state, $location) {
            console.log('requestErrorHandler');
            requestErrorHandler.handle(401, function() {
                console.log('401 error', $state);

                $state.go('login', { returnUrl: $state.current.name }, {
                    reload: true,
                    inherit: false,
                    notify: true
                });
            });
        }]);
 
    routesConfig.$inject = ['$stateProvider', '$locationProvider', '$urlRouterProvider', 'RouteHelpersProvider', '$httpProvider'];
    function routesConfig($stateProvider, $locationProvider, $urlRouterProvider, helper, $httpProvider) {
        
        // Set the following to true to enable the HTML5 Mode
        // You may have to set <base> tag in index and a routing configuration in your server
        // 去掉url里的#
        $locationProvider.html5Mode(false);

        // defaults to dashboard
        $urlRouterProvider.otherwise('/SingleView');

        // 
        // Application Routes
        // -----------------------------------   
        $stateProvider
            .state('app', {
                //url: '/',
                abstract: true,
                
                resolve: helper.resolveFor('modernizr', 'icons')
            })
            .state('app.singleview', {
                url: '/SingleView',
                title: '单页',
                templateUrl: helper.basepath('SingleView/Index')
            })
            .state('app.menuview', {
                url: '/MenuView',
                title: '菜单页',
                templateUrl: helper.basepath('SingleView/MenuView')
            })
            .state('app.buttons', {
                url: '/Buttons',
                title: '按钮页',
                templateUrl: helper.basepath('SingleView/Buttons')
            })
            .state('app.panels', {
                url: '/Panel',
                title: '面板页',
                templateUrl: helper.basepath('SingleView/Panels')
            })
            .state('app.usermanager', {
                url: '/UserManager',
                title: '用户管理',
                templateUrl: helper.basepath('UserManager'),
                resolve: helper.resolveFor('datatables', 'toaster', 'oitozero.ngSweetAlert') // 定义路由的时候讲依赖的模块加载进来
            })
            .state('app.rolemanager', {
                url: '/RoleManager',
                title: '角色管理',
                templateUrl: helper.basepath('RoleManager'),
                resolve: helper.resolveFor('datatables', 'toaster', 'oitozero.ngSweetAlert') // 定义路由的时候讲依赖的模块加载进来
            })
            .state('app.permissionmanager', {
                url: '/PermissionManager',
                title: '权限管理',
                templateUrl: helper.basepath('PermissionManager'),
                resolve: helper.resolveFor('datatables', 'toaster', 'oitozero.ngSweetAlert', 'uiSwitch') // 定义路由的时候讲依赖的模块加载进来
            })
            .state('login', {
                url: '/Login?returnUrl',
                title: '登录',
                templateUrl: helper.basepath('Account/Login')
                
            });
        /*?returnUrl*/
           
          // 
          // CUSTOM RESOLVES
          //   Add your own resolves properties
          //   following this object extend
          //   method
          // ----------------------------------- 
          // .state('app.someroute', {
          //   url: '/some_url',
          //   templateUrl: 'path_to_template.html',
          //   controller: 'someController',
          //   resolve: angular.extend(
          //     helper.resolveFor(), {
          //     // YOUR RESOLVES GO HERE
          //     }
          //   )
          // })
          ;

    } // routesConfig

})();

