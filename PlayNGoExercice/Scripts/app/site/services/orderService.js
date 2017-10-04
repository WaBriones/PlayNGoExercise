(function () {
	'use strict';

	angular.module('coffeeApp')
		.service('orderService', function ($http) {
			var baseOrderUrl = 'http://localhost:51555/api/order';

			this.getAggregatedOrders = function () {
				var request = {
					method: 'GET',
					url: baseOrderUrl
				};
				return $http(request);
			}
		});
})();