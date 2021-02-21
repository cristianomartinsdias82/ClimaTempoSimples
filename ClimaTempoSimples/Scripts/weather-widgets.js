var site = site || {};
site.baseUrl = site.baseUrl || "";

$(function (e) {
	
	$(".weatherWidget").each(function (index, item) {
		var url = site.baseUrl + $(item).data("url");
		if (url && url.length > 0) {
			$(item).load(url);
		}
	});

});