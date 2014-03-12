/// <reference path="http://localhost:41147/Scripts/app/js/services/services.js" />
'use strict';

/* Services */
var uri = '/api/products/:id'

// Demonstrate how to register services
// In this case it is a simple value service.
angular.module('myApp.services', ['ngResource'])
    .factory('Products', function ($resource, $q) {
        var resource = $resource(uri, { id: "@Id" },
            {
                "query": { method: 'GET', isArray: true },
                "save": { method: "POST" },
                "update": { method: 'PUT' }
            });
        return {
            getProducts: function () {
                var deferred = $q.defer();
                var result = resource.query(function () {
                    deferred.resolve(result);
                });

                return deferred.promise;
            },

            addProduct: function (item) {
                var deferred = $q.defer();
                resource.save(item, function (product) {
                    deferred.resolve(product);
                }, function (response) {
                    deferred.reject(response);
                });

                return deferred.promise;
            },

            update: function (item) {
                var deferred = $q.defer();
                resource.update(item, function (product) {
                    deferred.resolve(product);
                }, function (response) {
                    deferred.reject(response);
                });

                return deferred.promise;
            }
        }
    })
