# https://hub.docker.com/_/microsoft-dotnet-core
# final stage/image
FROM mcr.microsoft.com/dotnet/core/runtime:3.1
WORKDIR /app
COPY /out .
ENTRYPOINT ["dotnet", "Kidregs.dll"]