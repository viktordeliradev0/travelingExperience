$(document).ready(function () {
    console.log('Index1.js loaded!');
    var travels = Raw(Json.Serialize(Model));

    function applyFilter() {
        var startDestination = $('#startDestination').val();
        var endDestination = $('#endDestination').val();

        // Filter travels based on user input
        var filteredTravels = travels.filter(t =>
            (!startDestination || t.StartDestination.includes(startDestination))
            && (!endDestination || t.EndDestination.includes(endDestination))
        );

        // Update the displayed travels
        updateTravels(filteredTravels);
    }
    function updateTravels(travels) {
        var travelContainer = $('.row');
        travelContainer.empty();

        // Display the filtered travels
        travels.forEach(function (travel) {
            var travelCard = '<div class="col-md-4 col-xs-6 border-primary mb-3">';
            travelCard += '<div class="card mb-3" style="max-width: 540px;">';
            travelCard += '<div class="row g-0">';
            travelCard += '<div class="col-md-12">';
            travelCard += '<div class="card-header text-white bg-info">';
            travelCard += '<p class="card-text">';
            travelCard += '<h5 class="card-title">' + travel.Title + '</h5>'; // Add the travel title or other details
            travelCard += '</p>';
            travelCard += '</div>';
            travelCard += '</div>';
            travelCard += '<div class="col-md-6">';
            // Add other details or images if needed
            travelCard += '</div>';
            travelCard += '<div class="col-md-6">';
            travelCard += '<div class="card-body">';
            travelCard += '<p class="card-text">' + travel.StartDestination + '</p>';
            travelCard += '<p class="card-text"><b>End Destination: </b>' + travel.EndDestination + '</p>';
            // Add other details
            travelCard += '</div>';
            travelCard += '</div>';
            travelCard += '<div class="col-md-12">';
            travelCard += '<div class="card-footer ">';
            travelCard += '<p class="card-text">';
            // Add buttons or links
            travelCard += '</p>';
            travelCard += '</div>';
            travelCard += '</div>';
            travelCard += '</div>';
            travelCard += '</div>';
            travelCard += '</div>';

            travelContainer.append(travelCard);
        });
    }

});