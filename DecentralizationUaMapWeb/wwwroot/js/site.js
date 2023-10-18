let map;
 
async function initMap() {
    const { Map } = await google.maps.importLibrary("maps");
    map = new Map(document.getElementById("map"), {
        center: { lat: 49.020545381312374, lng: 31.39371588096726 },
        disableDefaultUI: true, 
        zoom: 7,
    });
}