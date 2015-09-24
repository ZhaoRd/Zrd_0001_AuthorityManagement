/**=========================================================
 * Module: demo-carousel.js
 * Provides a simple demo for bootstrap ui carousel
 =========================================================*/
(function() {
    'use strict';

    angular
        .module('app.bootstrapui')
        .controller('CarouselDemoCtrl', CarouselDemoCtrl);

    function CarouselDemoCtrl() {
        var vm = this;

        activate();

        ////////////////

        function activate() {
          vm.myInterval = 5000;
          
          var slides = vm.slides = [];
          vm.addSlide = function() {
            var newWidth = 800 + slides.length;
            slides.push({
              image: '//placekitten.com/' + newWidth + '/300',
              text: ['More','Extra','Lots of','Surplus'][slides.length % 2] + ' ' +
                ['Cats', 'Kittys', 'Felines', 'Cutes'][slides.length % 2]
            });
          };
          
          for (var i=0; i<2; i++) {
            vm.addSlide();
          }

        }
    }
})();
