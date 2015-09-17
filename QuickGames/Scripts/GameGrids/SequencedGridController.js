angular.module('gameGrid', []);

(function () {
	"use strict";

	var sequencedGridController = function ($http, $timeout) {

		var gridViewModel = this;
		gridViewModel.gameInProgress = false;

		var getCellById = function (id) {
			for (var index = 0; index < gridViewModel.grid.Cells.length; index++) {
				if (gridViewModel.grid.Cells[index].Id === id) {
					return gridViewModel.grid.Cells[index];
				}
			}
			return null;
		}

		gridViewModel.onCellClicked = function (cell) {
			if (cell == gridViewModel.expectedCell) {
				cell.completed = true;
				gridViewModel.expectedCell = getCellById(cell.Id + 1);
			}
			if (cell.Id == 1) {
				gridViewModel.startTime = new Date().getTime();
				gridViewModel.gameInProgress = true;
				$timeout(updateElapsedTime, 500);
			}
			if (!gridViewModel.expectedCell) {
				gridViewModel.gameInProgress = false;
			}
		}

		var onGotGrid = function (response) {
			gridViewModel.grid = response.data;
			gridViewModel.grid.rows = Cognim.Helpers.chunkArray(gridViewModel.grid.Cells, gridViewModel.grid.NumberOfColumns);
			gridViewModel.expectedCell = getCellById(1);
		}

		$http.get("http://localhost:53246/api/GridSequenceGame?rows=3&columns=3").then(onGotGrid);
	};

	angular.module('gameGrid')
		.controller('sequencedGridController', sequencedGridController)
		.directive('ngTimer', function () {
			return {
				restrict: 'E',
				require: '^millisecondsSinceStart',
				scope: {
					millisecondsSinceStart: '=',
					startTimer: '='
				},
				template: "<h3>Timer: {{millisecondsSinceStart | date:'mm:ss:sss'}}</h3>",

				controller: function ($scope, $timeout) {
					$scope.updateElapsedTime = function () {
						if ($scope.startTimer) {
							$scope.millisecondsSinceStart = new Date().getTime() - $scope.startTime;
							$timeout($scope.updateElapsedTime, 10);
						}
					}

					$scope.$watch('startTimer', function (startTimer) {
						if (startTimer) {
							$scope.startTime = new Date().getTime();
							$timeout($scope.updateElapsedTime, 10);
						}
					});
				}
			}
		});;
}());