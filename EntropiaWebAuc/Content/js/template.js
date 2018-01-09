jQuery(document).ready(function($) {

	$(".headroom").headroom({
		"tolerance": 20,
		"offset": 50,
		"classes": {
			"initial": "animated",
			"pinned": "slideDown",
			"unpinned": "slideUp"
		}
	});
    // footer stick to bottom
	if ($(document).height() <= $(window).height())
	    $("#footer").addClass("navbar-fixed-bottom");

});