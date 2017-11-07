var app = angular.module("app", ["ngRoute"]);

app.config(function ($routeProvider) {
    $routeProvider.
        when("/restaurant", {
            templateUrl: "src/app/views/restaurant/index.html",
            controller: "restaurantCtrl"
        }).
      otherwise({
          redirectTo: "/restaurant"
      });
});

app.filter('range', function() {
  return function(input, total) {
    total = parseInt(total);

    for (var i=0; i<total; i++) {
      input.push(i);
    }

    return input;
  };
});