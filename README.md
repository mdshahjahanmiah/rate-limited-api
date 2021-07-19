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
