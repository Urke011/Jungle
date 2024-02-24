// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    let countryName = $(".countryName")

    //search fields
    $('#searchBox').change(function () {
        // Get the selected value
        var selectedValue = $(this).val();
        if (selectedValue == "1") {
            var tripRowContryName = $(".countryName");
            let parents = tripRowContryName.parent().parent().parent();
            $.each(tripRowContryName, function (index) {
                let names = $(this).html();
                let uniqueId = names.split(' ').map(word => word.charAt(0).toUpperCase() + word.slice(1)).join(''); // Creating a unique ID using the index
                parents.eq(index).attr('id', uniqueId); // Setting ID for the corresponding parent element
                //remove all div elements
                $(".trip-list").css("display", "none");
            })
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
            var $tripLists = $('.trip-list').detach();
            // Append divs in sorted order
            idsArray.forEach(function (id) {
                // Find div element by id
                var $currentDiv = $tripLists.filter('#' + id);

                // Append the div to its sorted position
                $currentDiv.appendTo('.trip-list-wrapper');
            });
            // Apply display: flex to all divs with class 'trip-list'
            $('.trip-list').css('display', 'flex');
               
        }
    });
});

