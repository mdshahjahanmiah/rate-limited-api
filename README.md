Rate-limited API
==============

Rate-limited API is an **Agoda's** rate limiting solution and that can use any parties, For example hotel management system, and designed to control the rate of requests that clients can make to a Web API.

[![License: MIT](https://img.shields.io/github/license/HasanShahjahan/rate-limited-api.svg)](https://opensource.org/licenses/MIT)

**Documentation**
## Project Structure
There are following three projects:
* **API : Rate-limited API**- Rate-limited API (Hotel Management System) is implemented by rate limiter to make decision whether request will be processed or not (Based on enpoind wise configuration).
* **Middleware : Rate Limiter** - Rate limiter is the main library containing custom action filter to apply rate limits on API endpoints.
* **Tests : Unit & Integration** - This is the test project for all components.

## Considerations
**API (Hotel Management System) **
* "/api/v1/Hotel/city/{name}",that returns all the hotels belonging to a specific city.
* "/api/v1/Hotel/room/{type}", that returns all the hotels that have the requested.
* Both the endpoints can have an optional request to sort the hotels by price (ASC or DESC).

**Middleware (Rate Limiter) **
* Configurable rate limiting policy per endpoint per client
* Allows having multiple rules per endpoint
* Applies individual locks to prevent concurrent access by multiple threads 
* Sliding window technique is used for limiting requests

**Tests (Unit & Integration) **
* Configurable rate limiting policy per endpoint per client
* Allows having multiple rules per endpoint
* Applies individual locks to prevent concurrent access by multiple threads 
* Sliding window technique is used for limiting requests


## Limitations
* Limits incoming requests per endpoint based on clinet IP address only.
* Can't apply default limit for endpoints at the moment.
* Uses in-memory cache for storing data - won't work for distributed environment. 
* Limits requests based on time window only; other limiting factors (e.g. location) hasn't been taken into account.
* Limiting requests per time interval with fixed precision of 1 second. This will create large memory foot prints for larger window.


