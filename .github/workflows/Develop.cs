name: .NET Core Build & Publish

on:
  push:
    branches:
      - Develop  
jobs:
  build:
    runs-on: ubuntu-latest
    
    steps:
    - name: Checkout Repository
      uses: actions/checkout@v2

    - name: Setup .NET Core
      uses: actions/setup-dotnet@v2
      with:
        dotnet-version: '6.0'  # Adjust to your project's .NET Core version

    - name: Build and Publish
      run: |
        dotnet restore
        dotnet build --configuration Release
        dotnet publish -c Release -o ./publish
      working-directory: src/test/BoilerPlate 
