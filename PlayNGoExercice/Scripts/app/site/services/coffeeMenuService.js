(function () {
	'use strict';

	angular
		.module('coffeeApp')
		.service('cofeeMenuService', function ($http) {
			var baseCoffeeUrl = 'http://localhost:51555/api/CoffeeMenu';

			this.getCoffeeMenu = function () {
				var request = {
					method: 'GET',
					url: baseCoffeeUrl
				};
				return $http(request);
			}
		});
})();