(function () {
	'use strict';

	angular.module('coffeeApp')
		.controller('inventoryController', [
			'$scope', 'officeService', 'pantryStockService', '_', function ($scope, officeService, pantryStockService, _) {
				$scope.hideChart = true;

				function getOfficeList() {
					officeService.getOffices()
						.then(function (response) {
							$scope.offices = response.data;
						});
				} 

				$scope.onOfficeChange = function (item) {
					pantryStockService.getPantryStocksByOffice(item.OfficeId)
						.then(function (response) {
							$scope.labels = _.pluck(response.data, 'IngredientName');
							$scope.series = ['Inventory'];
							$scope.data = _.pluck(response.data, 'Amount');

							$scope.hideChart = false;
						});
				}

				getOfficeList();
			}
		]);
})();