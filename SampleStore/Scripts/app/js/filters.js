'use strict';

/* Filters */

angular.module('myApp.filters', []).
  filter('interpolate', ['version', function(version) {
    return function(text) {
      return String(text).replace(/\%VERSION\%/mg, version);
    }
  }])
    .filter("skip", [function () {
        return function (input, skip) {
            skip = parseInt(skip);

            var pagedInputs = [];
            angular.forEach(input, function (item, index) {
                if (index + 1 > skip) {
                    pagedInputs.push(item);
                }
            });

            return pagedInputs;
        }
    }]);
