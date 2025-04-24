FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY publish .
EXPOSE 7300
ENV ASPNETCORE_URLS=https://+:7300
ENV ASPNETCORE_ENVIRONMENT=Production
ENTRYPOINT ["dotnet", "Portfolio.OcelotGateway.dll"] 