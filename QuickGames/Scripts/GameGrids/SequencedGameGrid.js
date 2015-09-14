angular.module('gameGrid', []);

(function () {
	"use strict";

	function sequencedGridController() {
		var gridViewModel = this;
		gridViewModel.Name = "Hello";
	}
	angular.module('gameGrid').controller('sequencedGridController', sequencedGridController);
}());