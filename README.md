# Observability

## Observability in distributed systems:

- Logs
- Metrics
- Tracing

## Pending steps

- Explain topics: Logs, Metrics and Tracing
- Add logic to mantian traceKeyHeaderValue even if it is a complete new request
- Create another api to be called by order

## Grafana Settup 

```
Link: http://localhost:3000/
Default user name and password will be "admin"

click on "Add new Data Source"
Name: OrderApplications
Url: http://Loki:3100

click on "Save & test"
```

## Apis

Search in grafana:
```
{Application=~"Gateway_Development|OrderApi_Development"} | json | __error__  != "JSONParserErr"
```

Request via Gate: 
```
curl --location --request GET 'http://localhost:4001/Order' \
--header 'X-Gate-Api: Order'
```

Note: Cancel button on swagger doesn't cancel the request. It must test cancelation token using Postman!

## References:

https://grafana.com/blog/2021/01/25/a-beginners-guide-to-distributed-tracing-and-how-it-can-increase-an-applications-performance/

https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests

https://github.com/aspnet/Proxy/blob/master/src/Microsoft.AspNetCore.Proxy/ProxyAdvancedExtensions.cs