angular.module('gameGrid', []);

(function () {
	"use strict";

	var sequencedGridController = function ($http) {

		var gridViewModel = this;

		var getCellById = function(id){
			for (var index = 0; index < gridViewModel.grid.Cells.length; index++) {
				if (gridViewModel.grid.Cells[index].Id === id) {
					return gridViewModel.grid.Cells[index];
				}
			}
			return null;
		}

		gridViewModel.onCellClicked = function (cell) {
			if (cell == gridViewModel.expectedCell) {
				gridViewModel.expectedCell = getCellById(cell.Id + 1);
			}
			
		}

		var onGotGrid = function (response) {
			gridViewModel.grid = response.data;
			gridViewModel.grid.rows = Cognim.Helpers.chunkArray(gridViewModel.grid.Cells, gridViewModel.grid.NumberOfColumns);
			gridViewModel.expectedCell = getCellById(1);
		}

		$http.get("http://localhost:53246/api/GridSequenceGame?rows=4&columns=4").then(onGotGrid);
	};

	angular.module('gameGrid').controller('sequencedGridController', sequencedGridController);
}());