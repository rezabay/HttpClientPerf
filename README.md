# HttpClientPerf
Perf testing HttpClientFactory with MaxConnectionsPerServer

# How to run the tests
- Run Client: `dotnet run --project PerfTest.Client/`
- Run Server: `dotnet run --project PerfTest.Server/`
- Install `ddosify` from [Link](https://github.com/ddosify/ddosify)
- Start a load test: `ddosify -t https://localhost:7007/api/test -n 2000 -d 50`
- Install `dotnet-counters`: `dotnet tool install --global dotnet-counters`
- Get list of dotnet processes: `dotnet-counters ps`
- Monitor PerfTest.Client: `dotnet-counters monitor -p ${PID} --counters System.Net.Http,System.Net.Sockets`
