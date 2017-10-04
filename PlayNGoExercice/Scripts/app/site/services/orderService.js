(function () {
	'use strict';

	angular.module('coffeeApp')
		.service('orderService', function ($http) {
			var baseOrderUrl = 'http://localhost:51555/api/order/';

			this.getAggregatedOrders = function () {
				var request = {
					method: 'GET',
					url: baseOrderUrl
				};
				return $http(request);
			}

			this.submitOrder = function (formData) {
				var request = {
					method: 'POST',
					url: baseOrderUrl,
					data: formData
				};

				return $http(request);
			}

			this.getOrdersByOffice = function (officeId) {
				var request = {
					method: 'GET',
					url: baseOrderUrl + officeId
				};
				return $http(request);
			}
		});
})();