angular.module('gameGrid', []);

(function () {
	"use strict";

	var sequencedGridController = function ($http) {
		var gridViewModel = this;
		gridViewModel.Name = "Hello";

		var chunkArray = function (array, size) {
			var chunkedArray = [];

			for (var i = 0, len = array.length; i < len; i += size) {
				chunkedArray.push(array.slice(i, i + size));
			}
			return chunkedArray;
		}

		var onGotGrid = function (response) {
			gridViewModel.grid = response.data;
			gridViewModel.grid.rows = chunkArray(gridViewModel.grid.Cells, gridViewModel.grid.NumberOfColumns);
		}

		$http.get("http://localhost:53246/api/GridSequenceGame?rows=2&columns=2").then(onGotGrid);
	};

	angular.module('gameGrid').controller('sequencedGridController', sequencedGridController);
}());