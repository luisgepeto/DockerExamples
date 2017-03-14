FROM microsoft/dotnet:1.1.0-sdk-projectjson
MAINTAINER Luis Becerril
COPY . /app
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT="Development"
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]

EXPOSE 5000/tcp

ENTRYPOINT ["dotnet", "run", "--server.urls", "http://*:5000"]