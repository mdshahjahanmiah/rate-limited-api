Rate-limited API
==============

Rate-limited API is an **Agoda's** rate limiting solution and that can use any parties, For example hotel management system, and designed to control the rate of requests that clients can make to a Web API.

[![License: MIT](https://img.shields.io/github/license/HasanShahjahan/rate-limited-api.svg)](https://opensource.org/licenses/MIT)

## Documentation
## Project Structure
There are following three projects:
* **API : Rate-limited API**- Rate-limited API (Hotel Management System) is implemented by rate limiter to make decision whether request will be processed or not (Based on enpoind wise configuration).
* **Middleware : Rate Limiter** - Rate limiter is the main library containing custom action filter to apply rate limits on API endpoints.
* **Tests : Unit & Integration** - This is the test project for all components.

## Things you need
* **.Net Core 3.1, C#, SQL Server**
* Install Docker
* Clone **rate-limited-api** repository : git clone **https://github.com/HasanShahjahan/rate-limited-api.git**
* After cloning, the appsettings.json, docker file and docker compose yml file will be in root directory of the cloned project.

## Setting the configuration
## Logging
To see the log level wise log, please specify the **log level** and  **path format** `appsettings.json`
```
"Serilog": {
    "MinimumLevel": "Debug",
    "WriteTo": [
      {
        "Name": "RollingFile",
        "Args": {
          "pathFormat": "C:\\Agoda\\HotelManagement-{Date}.txt",
          "outputTemplate": "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}"
        }
      }
    ]
  }
```
## Connection String
To connect with Sql Server database, please specify your connection string. If nothing is changed then it will be created by below credentials. 

```
"ConnectionStrings": {
      "SqlServer": {
        "Queries": "Server=db;Database=master;User=sa;Password=Your_password123;"
      }
    }
    
```
## Rate Limiting
Configurable rate limiting policy per endpoint.Fallback to a default 50 requests every 10 seconds if no configuration is provided (Configurable).
```
"RateLimiting": {
      "Default": {
        "Period": 10,
        "Limit": 50
      },
      "Rules": [
        {
          "Endpoint": "/api/v1/Hotel/city",
          "Period": 5,
          "Limit": 10
        },
        {
          "Endpoint": "/api/v1/Hotel/room",
          "Period": 10,
          "Limit": 100
        }
      ]
    }
```

## Considerations
API (Hotel Management System)
* "/api/v1/Hotel/city/{name}",that returns all the hotels belonging to a specific city.
* "/api/v1/Hotel/room/{type}", that returns all the hotels that have the requested.
* Both the endpoints can have an optional request to sort the hotels by price (ASC or DESC).

Middleware (Rate Limiter)
* Configurable rate limiting policy per endpoint per client.
* Support multiple endpoints in future.
* Fallback to a default 50 requests every 10 seconds if no configuration is provided (Configurable).
* If the rate gets higher than the threshold on an endpoint, the API should stop responding waiting threshold/seconds on that endpoint ONLY, before allowing other requests.
* Applies individual locks to prevent concurrent access by multiple threads. 
* Sliding window algorithm/technique is used for limiting requests.

Tests (Unit & Integration)
* Unit test for managers, services, repositories, validator, rate limiters using Moq framework.
* Integration test that calls all API's using HTTP (Test Server).

## Limitations
* Limits requests based on time window only; other limiting factors (e.g. location) hasn't been taken into account.
* Limiting requests per time interval with fixed precision of 1 second. This will create large memory foot prints for larger window.
