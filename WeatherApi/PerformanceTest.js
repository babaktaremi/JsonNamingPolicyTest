import http from 'k6/http';
import { Rate } from 'k6/metrics';
import { sleep } from 'k6';

// Custom metric to track successful responses (status code 200 OK)
let successfulResponses = new Rate('successful_responses');


//FOR PERIODIC TEST
export let options = {
    stages: [
        { duration: '45s', target: 400 }
    ],
};

//export let options = {
//    vus: 10000, // 10,000 virtual users
//    duration: '10s', // The test will run for 10 seconds
//};

//FOR SINGLE TEST
export default function () {

    const headers = {
        'UsePascalCase': 'true'
    };

    let response = http.get('https://localhost:7119/WeatherForecast',headers); // Replace with your target URL
    successfulResponses.add(response.status === 200);

    // Add any additional requests or actions you want to perform during the test
    // For example:
    // http.post('https://example.com/api', JSON.stringify({ key: 'value' }));

    // Sleep for a short random duration between 1 to 3 seconds before making the next request
    // This random sleep time helps in creating a more realistic scenario
    //  sleep(Math.random() * 2 + 5);


    //FOR SINGLE TEST

    //let response = http.get('http://localhost:5252/EmpolyeesEFCompiled'); // Replace with your target URL
    //check(response, {
    //    'status is 200 OK': (r) => r.status === 200,
    //});
}