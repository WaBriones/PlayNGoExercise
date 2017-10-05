(function () {
	'use strict';

	angular
		.module('coffeeApp')
		.service('pantryService', function ($http) {
			var basePantryUrl = 'http://localhost:51555/api/pantry';

			this.getPantry = function () {
				var request = {
					method: 'GET',
					url: basePantryUrl
				};
				return $http(request);
			}

			this.addPantryToOffice = function (data) {
				var request = {
					method: 'POST',
					url: basePantryUrl,
					data: data
				};
				return $http(request);
			}
		});
})();