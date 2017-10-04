(function () {
	'use strict';

	angular
		.module('coffeeApp')
		.controller('homeController',
		[
			'$scope', 'officeService', 'cofeeMenuService', function ($scope, officeService, cofeeMenuService) {
				
				function getOfficeList() {
					officeService.getOffices()
						.then(function (response) {
							$scope.offices = response.data;
						});
				} 

				function getCoffeeMenuList() {
					cofeeMenuService.getCoffeeMenu()
						.then(function (response) {
							$scope.coffeeMenu = response.data;
						});
				}

				getOfficeList();
				getCoffeeMenuList();
			}
		]);
})();