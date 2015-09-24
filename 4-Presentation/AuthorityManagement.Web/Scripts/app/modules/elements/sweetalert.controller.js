/**=========================================================
 * Module: sweetalert.js
 =========================================================*/

(function() {
    'use strict';

    angular
        .module('app.elements')
        .controller('SweetAlertController', SweetAlertController);

    SweetAlertController.$inject = ['SweetAlert'];
    function SweetAlertController(SweetAlert) {
        var vm = this;

        activate();

        ////////////////

        function activate() {
          vm.demo1 = function() {
            SweetAlert.swal('Here\'s a message');
          };

          vm.demo2 = function() {
            SweetAlert.swal('Here\'s a message!', 'It\'s pretty, isn\'t it?');
          };

          vm.demo3 = function() {
            SweetAlert.swal('Good job!', 'You clicked the button!', 'success');
          };

          vm.demo4 = function() {
            SweetAlert.swal({   
              title: 'Are you sure?',   
              text: 'Your will not be able to recover this imaginary file!',   
              type: 'warning',   
              showCancelButton: true,   
              confirmButtonColor: '#DD6B55',   
              confirmButtonText: 'Yes, delete it!',
              closeOnConfirm: false
            },  function(){  
              SweetAlert.swal('Booyah!');
            });
          };

          vm.demo5 = function() {
            SweetAlert.swal({   
              title: 'Are you sure?',   
              text: 'Your will not be able to recover this imaginary file!',   
              type: 'warning',   
              showCancelButton: true,   
              confirmButtonColor: '#DD6B55',   
              confirmButtonText: 'Yes, delete it!',   
              cancelButtonText: 'No, cancel plx!',   
              closeOnConfirm: false,   
              closeOnCancel: false 
            }, function(isConfirm){  
              if (isConfirm) {     
                SweetAlert.swal('Deleted!', 'Your imaginary file has been deleted.', 'success');   
              } else {     
                SweetAlert.swal('Cancelled', 'Your imaginary file is safe :)', 'error');   
              } 
            });
          };

          vm.demo6 = function() {
            SweetAlert.swal({   
              title: 'Sweet!',   
              text: 'Here\'s a custom image.',   
              imageUrl: 'http://oitozero.com/img/avatar.jpg' 
            });
          };
        }
    }
})();
