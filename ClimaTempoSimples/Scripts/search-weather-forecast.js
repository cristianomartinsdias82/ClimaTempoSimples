$(function (e) {

    if (!weatherForecastSearchUrl) {
        console.error('Unable to perform search: searchWeatherForecastUrl argument was not informed!');
        return;
    }

    var cardTemplate = $('.card-template.hidden').clone();
    var uiControls = [];
    uiControls.weatherForecastsContainer = $('#weatherForecastsContainer');
    uiControls.searchWeatherByCity = $('#searchWeatherByCity');
    uiControls.city = $('#city');
    uiControls.weatherSearchTitle = $('#weatherSearchTitle');
    uiControls.lblSelectedCity = $('#lblSelectedCity');

    uiControls.city.select2();

    uiControls.searchWeatherByCity
        .on('click', function (e) {

            var selectedCity = uiControls.city.val().trim();

            $.ajax({
                url: weatherForecastSearchUrl,
                method: 'get',
                data: { city: selectedCity }
            })
                .done(function (data) {

                    if (!data.WeatherForecasts) {
                        location.href = 'home/error';
                    }

                    if (uiControls.weatherSearchTitle.hasClass('hidden')) {
                        uiControls.weatherSearchTitle.removeClass('hidden');
                    }

                    uiControls.weatherForecastsContainer.empty();
                    uiControls.lblSelectedCity.text(selectedCity);

                    $.each(data.WeatherForecasts, function (index, item) {
                        
                        var card = cardTemplate.clone();

                        card.find('.weather-forecast-date').text(item.FormattedDate);
                        card.find('.weather-forecast-weekday').text(item.DayOfWeek);
                        card.find('.weather-forecast-text').text(item.WeatherForecast);
                        card.find('.min-temperature').text(item.MinTemperature);
                        card.find('.max-temperature').text(item.MaxTemperature);

                        card.removeClass('hidden');

                        card.appendTo(uiControls.weatherForecastsContainer);

                    });

                })
                .catch(function (error) {
                    location.href = 'home/error';
                });
        });
})