FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY ApiGateway/Portfolio.OcelotGateway/bin/Release/net8.0/publish .
EXPOSE 7300
ENTRYPOINT ["dotnet", "Portfolio.OcelotGateway.dll"] 