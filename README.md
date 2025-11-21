# ServiceBusSample

Ce projet est un exemple complet d’intégration Azure Service Bus avec .NET 9, incluant :
- Une API Web pour envoyer des événements dans une file d’attente Service Bus
- Une Azure Function pour consommer et traiter les messages de la file d’attente
- Une interface Blazor pour tester l’envoi d’événements

## Prérequis

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- Un Service Bus Azure avec une file d’attente (ex : `orders-queue`)
- Visual Studio 2022 ou VS Code
- Un compte Azure

## Structure du projet

- `ServiceBusSample.Api` : API Web (.NET 9) pour publier des événements dans Service Bus
- `ServiceBusSample.Domain` : Modèles de données partagés
- `ServiceBusSample.QueueProcessor` : Azure Function pour consommer la file d’attente
- `ServiceBusSample.UI` : Interface Blazor pour tester l’envoi d’événements

## Configuration

### 1. Service Bus Azure

Créez un Service Bus et une file d’attente sur le portail Azure.  
Récupérez la chaîne de connexion dans **Clés d’accès** > `RootManageSharedAccessKey`.

### 2. API Web

Dans `ServiceBusSample.Api/appsettings.json` :
"AzureServiceBus": { "ConnectionString": "#####" }


### 3. Azure Function

Dans `ServiceBusSample.QueueProcessor/local.settings.json` :
"Values": { "ServiceBusConnection": "####" }

## Technologies

- .NET 9
- Azure Service Bus
- Azure Functions (dotnet-isolated)
- Blazor
- Swagger (OpenAPI)

## Liens utiles

- [Documentation Azure Service Bus](https://learn.microsoft.com/fr-fr/azure/service-bus-messaging/)
- [Documentation Azure Functions](https://learn.microsoft.com/fr-fr/azure/azure-functions/)
- [Blazor](https://learn.microsoft.com/fr-fr/aspnet/core/blazor/)

---




