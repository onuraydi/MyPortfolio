FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY Backend/MyPortfolio.WebApi/bin/Release/net8.0/publish .
EXPOSE 7301
ENV ASPNETCORE_URLS=https://+:7301
ENV ASPNETCORE_ENVIRONMENT=Production
ENTRYPOINT ["dotnet", "MyPortfolio.WebApi.dll"] 