(function () {
	'use strict';
	
	angular
		.module('coffeeApp')
		.service('officeService', function ($http) {
			var baseOfficeUrl = 'http://localhost:51555/api/Office';

			this.getOffices = function () {
				var request = {
					method: 'GET',
					url: baseOfficeUrl
				};
				return $http(request);
			}
		});
})();