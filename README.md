# Observability

## Observability in distributed systems:

- Logs
- Metrics
- Tracing

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

- GateApi : http://localhost:4001/swagger/index.html
- OrderApi : 

Search in grafana:
```
{Application="Gateway_Development"} | json | __error__  != "JSONParserErr"
```

Note: Cancel button on swagger doesn't cancel the request. It must test cancelation token using Postman!

## References:

https://grafana.com/blog/2021/01/25/a-beginners-guide-to-distributed-tracing-and-how-it-can-increase-an-applications-performance/