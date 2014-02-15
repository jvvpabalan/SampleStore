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
                return resource.query();
            }
        }
    })
