'use strict';

/* Services */
var uri = '/api/products/:id'

// Demonstrate how to register services
// In this case it is a simple value service.
angular.module('myApp.services', ['ngResource'])
    .factory('Products', function ($resource, $q) {
        var resource = $resource(uri);
        return {
            getProducts: function () {
                var deferred = $q.defer();
                var result = resource.query(function () {
                    deferred.resolve(result);
                });

                return deferred.promise;
            }
        }
    })
