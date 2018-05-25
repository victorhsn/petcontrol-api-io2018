FROM microsoft/aspnetcore-build AS build
WORKDIR /petcontrol

COPY *.sln ./
COPY src/PetControl.Api/PetControl.Api.csproj src/PetControl.Api/
COPY src/PetControl.Infra/PetControl.Infra.csproj src/PetControl.Infra/
COPY src/PetControl.Domain/PetControl.Domain.csproj src/PetControl.Domain/
COPY src/PetControl.Shared/PetControl.Shared.csproj src/PetControl.Shared/

RUN dotnet restore
COPY . .
WORKDIR /petcontrol/src/PetControl.Api/
RUN dotnet build --configuration Release --output /app

FROM build AS publish
RUN dotnet publish --configuration Release --output /app

FROM microsoft/aspnetcore
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "./PetControl.Api.dll"]%