(function () {
	'use strict';

	angular.module('coffeeApp')
		.controller('maintenanceController', [
			'$scope', 'officeService', 'pantryService', function ($scope, officeService, pantryService) {
				
				$scope.successOffice = false;
				$scope.successPantry = false;

				$scope.submitOffice = function () {
					var formData = {
						OfficeName: $scope.officeName
					};

					officeService.addOffice(formData)
						.then(function () {
							getOfficeList();
							$scope.successOffice = true;
						});
				}


				$scope.submitPantry = function () {
					var formData = {
						OfficeId: $scope.selectedOffice.OfficeId,
						PantryName: $scope.pantryName
					};

					pantryService.addPantryToOffice(formData)
						.then(function () {
							$scope.successPantry = true;
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