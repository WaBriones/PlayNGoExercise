(function () {
	'use strict';

	angular.module('coffeeApp')
		.controller('orderHistoryController', [
			'$scope', '$timeout', 'orderService', 'officeService', function ($scope, $timeout, orderService, officeService) {
				getOfficeList();

				$scope.gridOptions = {
					enableSorting: true,
					columnDefs: [
						{ name: 'CustomerName' },
						{ name: 'DrinkName' },
						{ name: 'DateOrdered' }
					],
					data: []
				};

				$scope.onOfficeChange = function (item) {
					
					orderService.getOrdersByOffice(item.OfficeId)
						.then(function (response) {
							$scope.gridOptions.data = response.data;
						})
						.then(function () {
							$scope.loading = false;
						});
				}

				function getOfficeList() {
					officeService.getOffices()
						.then(function (response) {
							$scope.offices = response.data;
						});
				}
			}
		]);
})();