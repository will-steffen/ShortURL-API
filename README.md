create database: 
CREATE DATABASE short_url CHARACTER SET utf8 COLLATE utf8_general_ci;

create migration:
dotnet ef migrations add ShortUrlStart --context ApplicationContext

build for azure:
dotnet publish --configuration=Release --runtime debian.8-x64