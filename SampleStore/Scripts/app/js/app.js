'use strict';


// Declare app level module which depends on filters, and services
angular.module('myApp', [
  'ngRoute',
  'myApp.filters',
  'myApp.services',
  'myApp.directives',
  'myApp.controllers'
]).
config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/index', {templateUrl: '/Scripts/app/partials/products.html', controller: 'ProductsCtrl'});
  $routeProvider.otherwise({redirectTo: '/index'});
}]);
