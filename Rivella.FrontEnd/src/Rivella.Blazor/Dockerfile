FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Rivella.Blazor.csproj", "./"]
RUN dotnet restore "Rivella.Blazor.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "Rivella.Blazor.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish Rivella.Blazor.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM nginx:alpine AS final
COPY --from=publish /app/publish/wwwroot /usr/share/nginx/html
RUN echo $' \n\
server { \n\
    listen 80; \n\
    server_name _; \n\
    root /usr/share/nginx/html; \n\
    index index.html; \n\
    location / { \n\
        try_files $uri $uri/ /index.html; \n\
    } \n\
}' > /etc/nginx/conf.d/default.conf
EXPOSE 80