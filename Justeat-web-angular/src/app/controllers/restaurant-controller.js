;(function () {
  'use strict'
  angular
    .module('app')
    .controller('restaurantCtrl', ['$scope', '$http', '$rootScope', '$location', restaurantCtrl])

  /***********************************
  *       this Controller
  *    Manage the restuarants Page
  ************************************/
  function restaurantCtrl ($scope, $http, $rootScope, $location) {
    var url = ' https://public.je-apis.com/restaurants'

    $scope.query = "se19"
    $scope.restaurants = [];
    $scope.search = search;

    function search () {
      $http.get(url + '?q='+$scope.query, {
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json',
          'Authorization': 'Basic VGVjaFRlc3RBUEk6dXNlcjI=',
          // "Accept-Tenant": "uk",
          'Accept-Language': 'en-GB'
        }
      }).then(function (response) {
        $scope.restaurants = response.data.Restaurants;
      }, function (error) {})
    }
  }
})()
