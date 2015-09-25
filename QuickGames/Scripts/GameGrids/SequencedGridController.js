angular.module('gameGrid', []);

(function () {
	"use strict";

	var sequencedGridController = function ($http, $timeout) {

		var gameModel = this;
		gameModel.gameInProgress = false;
		gameModel.onCellClicked = function (cell) {
			if (cell.completed) return;
			if (cell.Id == 1) {
				gameModel.gameInProgress = true;
			}
			if (cell.Id == gameModel.grid.NumberOfCells) {
				gameModel.gameInProgress = false;
			}
			if (cell == gameModel.expectedCell) {
				cell.completed = true;
				gameModel.expectedCell = getCellById(cell.Id + 1);
			}
		}

		var getCellById = function (id) {
			for (var index = 0; index < gameModel.grid.Cells.length; index++) {
				if (gameModel.grid.Cells[index].Id === id) {
					return gameModel.grid.Cells[index];
				}
			}
			return null;
		}

		var onGotGrid = function (response) {
			gameModel.grid = response.data;
			gameModel.grid.rows = Cognim.Helpers.chunkArray(gameModel.grid.Cells, gameModel.grid.NumberOfColumns);
			gameModel.expectedCell = getCellById(1);
		}

		$http.get("http://localhost:53246/api/GridSequenceGame?rows=4&columns=5").then(onGotGrid);
	};

	angular.module('gameGrid')
		.controller('sequencedGridController', sequencedGridController)
		.directive('cgTimer', function ($timeout) {
			return {
				restrict: 'E',
				scope: {
					millisecondsSinceStart: '=',
					runTimer: '='
				},
				template: "<h3>Timer: {{millisecondsSinceStart | date:'mm:ss:sss'}}</h3>",

				link: function (scope) {

					scope.updateElapsedTime = function () {
						if (scope.runTimer) {
							scope.millisecondsSinceStart = new Date().getTime() - scope.startTime;
							$timeout(scope.updateElapsedTime, 10);
						}
					}

					scope.$watch('runTimer', function (runTimer) {
						if (runTimer) {
							scope.startTime = new Date().getTime();
							$timeout(scope.updateElapsedTime, 10);
						}
					});
				},


			}
		});;
}());