// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function geoFindMe() {

    const status = document.querySelector('#status');
    const mapLink = document.querySelector('#map-link');
    const formLatitude = document.querySelector('#Latitude');
    const formLongitude = document.querySelector('#Longitude');


    mapLink.href = '';
    mapLink.textContent = '';

    function success(position) {
        const latitude = position.coords.latitude;
        const longitude = position.coords.longitude;

        formLatitude.value = latitude;
        formLongitude.value = longitude;

        status.textContent = '';
        mapLink.href = `https://www.openstreetmap.org/#map=18/${latitude}/${longitude}`;

        //element.value = "your data here";

    }

    function error() {
        status.textContent = 'Unable to retrieve your location';
    }

    if (!navigator.geolocation) {
        status.textContent = 'Geolocation is not supported by your browser';
    } else {
        status.textContent = 'Locating…';
        navigator.geolocation.getCurrentPosition(success, error);
    }

}

document.querySelector('#find-me').addEventListener('click', geoFindMe);