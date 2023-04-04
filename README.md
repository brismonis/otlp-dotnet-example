# OpenTelemetry .NET example using OTLP

Run:

```shell
docker-compose up --build
```

Using a browser or curl to go to: http://localhost:5001.

You'll see output like the following:

```text
otlp-dotnet-example-collector-1  | 2023-04-04T00:38:24.543Z     info    service/telemetry.go:90 Setting up own telemetry...
otlp-dotnet-example-collector-1  | 2023-04-04T00:38:24.543Z     info    service/telemetry.go:116        Serving Prometheus metrics      {"address": ":8888", "level": "Basic"}
otlp-dotnet-example-collector-1  | 2023-04-04T00:38:24.543Z     info    exporter@v0.74.0/exporter.go:286        Development component. May change in the future.  {"kind": "exporter", "data_type": "metrics", "name": "logging"}
otlp-dotnet-example-collector-1  | 2023-04-04T00:38:24.544Z     warn    loggingexporter@v0.74.0/factory.go:109  'loglevel' option is deprecated in favor of 'verbosity'. Set 'verbosity' to equivalent value to preserve behavior.        {"kind": "exporter", "data_type": "metrics", "name": "logging", "loglevel": "debug", "equivalent verbosity level": "Detailed"}
otlp-dotnet-example-collector-1  | 2023-04-04T00:38:24.546Z     info    service/service.go:128  Starting otelcol-contrib...     {"Version": "0.74.0", "NumCPU": 5}
otlp-dotnet-example-collector-1  | 2023-04-04T00:38:24.546Z     info    extensions/extensions.go:41     Starting extensions...
otlp-dotnet-example-collector-1  | 2023-04-04T00:38:24.546Z     warn    internal/warning.go:51  Using the 0.0.0.0 address exposes this server to every network interface, which may facilitate Denial of Service attacks  {"kind": "receiver", "name": "otlp", "data_type": "metrics", "documentation": "https://github.com/open-telemetry/opentelemetry-collector/blob/main/docs/security-best-practices.md#safeguards-against-denial-of-service-attacks"}
otlp-dotnet-example-collector-1  | 2023-04-04T00:38:24.546Z     info    otlpreceiver@v0.74.0/otlp.go:94 Starting GRPC server    {"kind": "receiver", "name": "otlp", "data_type": "metrics", "endpoint": "0.0.0.0:4317"}
otlp-dotnet-example-collector-1  | 2023-04-04T00:38:24.546Z     info    service/service.go:145  Everything is ready. Begin running and processing data.
otlp-dotnet-example-app-1        | info: Microsoft.Hosting.Lifetime[14]
otlp-dotnet-example-app-1        |       Now listening on: http://[::]:80
otlp-dotnet-example-app-1        | info: Microsoft.Hosting.Lifetime[0]
otlp-dotnet-example-app-1        |       Application started. Press Ctrl+C to shut down.
otlp-dotnet-example-app-1        | info: Microsoft.Hosting.Lifetime[0]
otlp-dotnet-example-app-1        |       Hosting environment: Production
otlp-dotnet-example-app-1        | info: Microsoft.Hosting.Lifetime[0]
otlp-dotnet-example-app-1        |       Content root path: /App
otlp-dotnet-example-app-1        | info: Microsoft.AspNetCore.Hosting.Diagnostics[1]
otlp-dotnet-example-app-1        |       Request starting HTTP/1.1 GET http://localhost:5001/ - -
otlp-dotnet-example-app-1        | info: Microsoft.AspNetCore.Routing.EndpointMiddleware[0]
otlp-dotnet-example-app-1        |       Executing endpoint 'HTTP: GET /'
otlp-dotnet-example-app-1        | info: Microsoft.AspNetCore.Routing.EndpointMiddleware[1]
otlp-dotnet-example-app-1        |       Executed endpoint 'HTTP: GET /'
otlp-dotnet-example-app-1        | info: Microsoft.AspNetCore.Hosting.Diagnostics[2]
otlp-dotnet-example-app-1        |       Request finished HTTP/1.1 GET http://localhost:5001/ - - - 200 - text/plain;+charset=utf-8 25.0470ms
otlp-dotnet-example-collector-1  | 2023-04-04T00:38:46.818Z     info    MetricsExporter {"kind": "exporter", "data_type": "metrics", "name": "logging", "#metrics": 1}
otlp-dotnet-example-collector-1  | 2023-04-04T00:38:46.818Z     info    ResourceMetrics #0
otlp-dotnet-example-collector-1  | Resource SchemaURL: 
otlp-dotnet-example-collector-1  | Resource attributes:
otlp-dotnet-example-collector-1  |      -> service.name: Str(unknown_service:dotnet)
otlp-dotnet-example-collector-1  | ScopeMetrics #0
otlp-dotnet-example-collector-1  | ScopeMetrics SchemaURL: 
otlp-dotnet-example-collector-1  | InstrumentationScope MyMeter 
otlp-dotnet-example-collector-1  | Metric #0
otlp-dotnet-example-collector-1  | Descriptor:
otlp-dotnet-example-collector-1  |      -> Name: MyCounter
otlp-dotnet-example-collector-1  |      -> Description: 
otlp-dotnet-example-collector-1  |      -> Unit: 
otlp-dotnet-example-collector-1  |      -> DataType: Sum
otlp-dotnet-example-collector-1  |      -> IsMonotonic: true
otlp-dotnet-example-collector-1  |      -> AggregationTemporality: Cumulative
otlp-dotnet-example-collector-1  | NumberDataPoints #0
otlp-dotnet-example-collector-1  | StartTimestamp: 2023-04-04 00:38:24.8038878 +0000 UTC
otlp-dotnet-example-collector-1  | Timestamp: 2023-04-04 00:38:46.7948287 +0000 UTC
otlp-dotnet-example-collector-1  | Value: 1
otlp-dotnet-example-collector-1  |      {"kind": "exporter", "data_type": "metrics", "name": "logging"}
```