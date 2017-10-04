(function () {
	'use strict';

	angular.module('coffeeApp')
		.service('pantryStockService', function ($http) {
			var basePantryStockUrl = 'http://localhost:51555/api/PantryStock/';

			this.getPantryStocksByOffice = function (officeId) {
				var request = {
					method: 'GET',
					url: basePantryStockUrl + 'getpantrystocks/' + officeId
				};
				return $http(request);
			}
		});
})();