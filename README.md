# Conquer The Network
Demo application for my Conquer The Network presentation.

The demo app uses a sample WebApi service. The source for the service is included in this repo for self hosting, but you can also use:

http://conquerthenetworksampleservice.azurewebsites.net/api

The API has some quirks built in, such as intermittent server errors in the endpoint and support for `ETags` (and the `If-None-Match` header) in the `/schedule` endpoint.
