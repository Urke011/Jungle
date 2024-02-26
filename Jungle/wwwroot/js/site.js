// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {


    // Restore select box value on page load
    restoreSelectBox();

    // Reset select box when navigating to another link
    $('a').click(function () {
        resetSelectBox();
    });
    function restoreSelectBox() {
        
        $('#searchBox').prop('selectedIndex', 0);
    }
    function resetSelectBox() {
        /
        $('#searchBox').prop('selectedIndex', 0); 
    }
    let countryName = $(".countryName");
    //search fields
    var tripRowContryName = $(".countryName");
    let parents = tripRowContryName.parent().parent().parent();
    //add uniq id
    $.each(tripRowContryName, function (index) {
        let names = $(this).html();
        let uniqueId = names.split(' ').map(word => word.charAt(0).toUpperCase() + word.slice(1)).join(''); // Creating a unique ID using the index
        parents.eq(index).attr('id', uniqueId); // Setting ID for the corresponding parent element
    })
    $('#searchBox').change(function () {
        // Get the selected value
        var selectedValue = $(this).val();
        if (selectedValue == "1") {
            var idsArray = [];
            // Sort the array alphabetically
            // Iterate over each element with class 'trip-list'
            $('.trip-list').each(function () {
                // Get the id of the current element and push it to the array
                idsArray.push($(this).attr('id'));
            });

            // Now, idsArray contains the ids of all the divs with class 'trip-list'
            console.log(idsArray);
            idsArray.sort();
            // Detach all divs with class 'trip-list'
            var tripLists = $('.trip-list').detach();
            // Append divs in sorted order
            idsArray.forEach(function (id) {
                // Find div element by id
                var currentDiv = tripLists.filter('#' + id);
                // Append the div to its sorted position
                currentDiv.appendTo('.trip-list-wrapper');
            });
            // Apply display: flex to all divs with class 'trip-list'
            $('.trip-list').css('display', 'flex');
               
        }
        var priceArray = [];
        if (selectedValue == "2") {
            $('.tripPrice').each(function () {
                var price = $(this).text();
                // Remove special characters and convert to number
                var numericPrice = parseFloat(price.replace(/[^0-9.-]+/g, ""));
                var tripListElement = $(this).closest('.trip-list');
                var tripListId = tripListElement.length > 0 ? tripListElement.attr('id') : undefined;
                // Push an object containing both numericPrice and tripListId to the array
                priceArray.push({ price: numericPrice, tripListId: tripListId });
            });
            // Sort the array based on numericPrice
            priceArray.sort((a, b) => a.price - b.price);
            console.log(priceArray);
            tripLists = $('.trip-list').detach();
            // Append divs in sorted order
            priceArray.forEach(function (item) {
                // Find div element by id
                var currentDiv = tripLists.filter("#"+item.tripListId)
                    // Append the div to its sorted position
                    $('.trip-list-wrapper').append(currentDiv);
               
            });
            // Apply display: flex to all divs with class 'trip-list'
            $('.trip-list').css('display', 'flex');
        }

        var periodArray = [];
        if (selectedValue == "3") {
            $('.travelPeriod').each(function () {
                var duration = $(this).text();
                // Remove special characters and convert to number
                var periodDuration = parseFloat(duration.replace(/[^0-9.-]+/g, ""));
                var numericValue = parseFloat(periodDuration.toString().replace(/\D/g, ''));
                var tripListElement = $(this).closest('.trip-list');
                var tripListId = tripListElement.length > 0 ? tripListElement.attr('id') : undefined;
                // Push an object containing both numericPrice and tripListId to the array
                // Extract only the numeric value and remove trailing spaces
              
                periodArray.push({ duration: numericValue, tripListId: tripListId });
            });
            // Sort the array based on numericPrice
            periodArray.sort(function (a, b) {
                return a.duration - b.duration;
            });
            console.log(periodArray);
            tripLists = $('.trip-list').detach();
            // Append divs in sorted order
            periodArray.forEach(function (item) {
                // Find div element by id
                var currentDiv = tripLists.filter("#" + item.tripListId)
                // Append the div to its sorted position
                $('.trip-list-wrapper').append(currentDiv);

            });
            // Apply display: flex to all divs with class 'trip-list'
            $('.trip-list').css('display', 'flex');
        }
    });
});

