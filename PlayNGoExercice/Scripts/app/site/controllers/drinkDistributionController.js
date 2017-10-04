(function () {
	'use strict';

	angular.module('coffeeApp')
		.controller('drinkDistributionController', [
			'$scope', 'orderService', '_', function ($scope, orderService, _) {
				$scope.hideChart = false;
				$scope.options = { legend: { display: true } };

				function getAggregatedOrders() {
					orderService.getAggregatedOrders()
						.then(function (response) {
							$scope.labels = _.uniq(_.pluck(response.data, 'OfficeName'));
							var drinks = _.uniq(_.pluck(response.data, 'DrinkName'));
							$scope.series = drinks;

							$scope.data = [];

							for (let i = 0; i < drinks.length; i++) {
								var drink = _.where(response.data, { DrinkName: drinks[i] });

								if (drink !== undefined) {
									$scope.data.push(_.pluck(drink, 'DrinkCount'));
								}
							}

							$scope.data = data;
						});

				}

				getAggregatedOrders();
			}
		]);
})();