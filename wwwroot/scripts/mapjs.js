let map;
let markers;
let geoJsonLayer;
const defaultLatitude = 55.32073;
const defaultLongitude = 15.18603;
const myMarkers = [];



window.createMap = {
    
    GenerateMap: function (mapId) {

        
        map = new L.Map(mapId, {
            center: [defaultLatitude,defaultLongitude],
            zoom: 18,
            scrollWheelZoom: "center",
            zoomDelta: 0.5,
            fullscreenControl: true,
            fullscreenControlOptions: {
                position: 'topleft'
            }
        });
        
       
        
        markers = L.layerGroup().addTo(map);
        
        geoJsonLayer = L.geoJSON().addTo(map);
        

        L.circle([defaultLatitude, defaultLongitude], {
            color: 'red',
            fillColor: '#f03',
            fillOpacity: 0.5,
            radius: 0.5,
        }).addTo(map);

        L.marker([defaultLatitude, defaultLongitude]).addTo(map);

        L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token={accessToken}', {
            maxZoom: 200,
            id: 'mapbox/streets-v11',
            tileSize: 512,
            zoomOffset: -1,
            accessToken: 'pk.eyJ1IjoiY2hyaXN0aW5hYmFydGhvIiwiYSI6ImNrdjk3aG9oNDAyangydnBnNmt3aGUycDgifQ.qfjcnvazH8V0CtAGtEf9Iw'
        }).addTo(map);


        L.control.browserPrint({
            printLayer: L.tileLayer(geoJsonLayer,{
            minZoom: 1,
                maxZoom: 16,
                ext: 'png'
        }),
            printModes: [ "Portrait" ],
            manualMode: false
        }).addTo(map);
        
    }
}

window.addMarker = {
    AddMarker: function (lati, longi) {
        const myMarker = L.marker([lati, longi]).addTo(markers);
        myMarkers.push(myMarker);
    }
}

window.removeMarker = {
    RemoveMarker: function (lati, longi) {
        const myEle = myMarkers.findIndex(mark => mark["_latlng"]["lat"] === lati);
        const deleteMe = myMarkers[myEle];
        map.removeLayer(deleteMe);
        myMarkers.splice(myEle, 1);
    }
}

window.resetRoute = {
    ResetRoute: function () {
        markers.clearLayers();
        geoJsonLayer.clearLayers();
    }
}


window.createRoute = {

    GenerateRoute: function (listOfCoords) {
        return new Promise(((resolve, reject) => {
            const jsonObj = JSON.parse(listOfCoords);

            let request = new XMLHttpRequest();
            const url = "https://api.openrouteservice.org/v2/directions/foot-walking/geojson";

            request.open('POST', url, true);
            request.setRequestHeader('Accept', 'application/json, application/geo+json, application/gpx+xml, img/png; charset=utf-8');
            request.setRequestHeader('Content-Type', 'application/json');
            request.setRequestHeader('Authorization', '5b3ce3597851110001cf6248464012cf1931479089f3559cdeab19ae');

            const myObj = {
                coordinates: []
            };

            //Startposition sættes
            myObj.coordinates.push([defaultLongitude, defaultLatitude]);

            for(let i =0; i < jsonObj.length; i++){
                const coord = [jsonObj[i]["Longitude"], jsonObj[i]["Latitude"]];
                myObj.coordinates.push(coord);
            }

            //Slutposition sættes
            myObj.coordinates.push([defaultLongitude, defaultLatitude]);

            request.send(JSON.stringify({
                "coordinates":
                myObj.coordinates
            }));

            request.onreadystatechange = () => {

                if (request.readyState === 4 && request.status === 200) {
                    const json = JSON.parse(request.responseText);
                    L.geoJSON(json).addTo(geoJsonLayer);
                    const time = json["features"][0]["properties"]["summary"]["duration"];
                    resolve({time : time});
                }
            }
        }));
    },
    
    CallByC: async function(listOfCords) {
        const result = await createRoute.GenerateRoute(listOfCords);
        return result["time"];
    }
}


function fullscreen() {
    window.print();
}





/*function GenerateMap() {
     map = L.map('mapid').setView([defaultLatitude,defaultLongitude], 16);


        markers = L.layerGroup().addTo(map);
        geoJsonLayer = L.geoJSON().addTo(map);

        L.circle([defaultLatitude, defaultLongitude], {
            color: 'red',
            fillColor: '#f03',
            fillOpacity: 0.5,
            radius: 0.5
        }).addTo(map);

        L.marker([defaultLatitude, defaultLongitude]).addTo(map);

        L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token={accessToken}', {
            attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
            maxZoom: 100,
            id: 'mapbox/streets-v11',
            tileSize: 512,
            zoomOffset: -1,
            accessToken: 'pk.eyJ1IjoiY2hyaXN0aW5hYmFydGhvIiwiYSI6ImNrdjk3aG9oNDAyangydnBnNmt3aGUycDgifQ.qfjcnvazH8V0CtAGtEf9Iw'
        }).addTo(map);
    }
     
}*/


/*function RemoveMarker(lati, longi){
    
    const myEle = myMarkers.findIndex(mark => mark["_latlng"]["lat"] === lati);
    const deleteMe = myMarkers[myEle];
    map.removeLayer(deleteMe);
    myMarkers.splice(myEle, 1);
}*/

/*function ResetRoute(){
    markers.clearLayers();
    geoJsonLayer.clearLayers();
}*/

/*function GenerateRoute(listOfCoords){
    
    return new Promise(((resolve, reject) => {
        const jsonObj = JSON.parse(listOfCoords);

        let request = new XMLHttpRequest();
        const url = "https://api.openrouteservice.org/v2/directions/foot-walking/geojson";

        request.open('POST', url, true);
        request.setRequestHeader('Accept', 'application/json, application/geo+json, application/gpx+xml, img/png; charset=utf-8');
        request.setRequestHeader('Content-Type', 'application/json');
        request.setRequestHeader('Authorization', '5b3ce3597851110001cf6248464012cf1931479089f3559cdeab19ae');

        const myObj = {
            coordinates: []
        };

        //Startposition sættes
        myObj.coordinates.push([defaultLongitude, defaultLatitude]);

        for(let i =0; i < jsonObj.length; i++){
            const coord = [jsonObj[i]["Longitude"], jsonObj[i]["Latitude"]];
            myObj.coordinates.push(coord);
        }

        //Slutposition sættes
        myObj.coordinates.push([defaultLongitude, defaultLatitude]);
        
        request.send(JSON.stringify({
            "coordinates":
            myObj.coordinates
        }));

        request.onreadystatechange = () => {

            if (request.readyState === 4 && request.status === 200) {
                const json = JSON.parse(request.responseText);
                L.geoJSON(json).addTo(geoJsonLayer);
                const time = json["features"][0]["properties"]["summary"]["duration"];
                resolve({time : time});
            }
        }
    }));
}*/

/*
async function CallByC(listOfCords){
    const result = await GenerateRoute(listOfCords);
    return result["time"];
}*/
