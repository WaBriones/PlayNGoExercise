(function () {
	'use strict';

	angular
		.module('coffeeApp')
		.controller('orderController',
		[
			'$scope', 'officeService', 'cofeeMenuService', 'orderService', function ($scope, officeService, cofeeMenuService, orderService) {

				$scope.orderComplete = false;

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

				$scope.submitOrder = function () {
					var formData = {
						OfficeId: $scope.selectedOffice.OfficeId,
						DrinkId: $scope.selectedCoffee.DrinkId,
						CustomerName: $scope.customerName
					};

					orderService
						.submitOrder(formData)
						.then(function () {
							$scope.orderPlaced = true;
						});
				}

				getOfficeList();
				getCoffeeMenuList();
			}
		]);
})();