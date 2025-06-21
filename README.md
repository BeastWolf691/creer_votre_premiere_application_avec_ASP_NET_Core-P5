# ExpressVoitures

## 📝 Description du projet

**ExpressVoitures** est une application ASP.NET Core MVC développée dans le cadre du **Projet 5 : Créez votre première application avec ASP.NET Core** du parcours *Développeur Back-End .NET* d’OpenClassrooms.

Cette application permet de gérer un inventaire de véhicules pour un usage administratif interne.  
Elle intègre des fonctionnalités de gestion de fiches de véhicules, de transactions (achats, ventes, réparations), ainsi que de médias associés (images ou vidéos).  
Elle respecte les principes de l'architecture **MVC** et repose sur une séparation claire entre les responsabilités via les modèles, services, et repositories.  

## 🎯 Fonctionnalités principales

- ✅ **CRUD véhicules** : Création, consultation, édition et suppression de fiches véhicules.
- 📷 **Médias associés** : Ajout d’images à chaque véhicule.
- 💰 **Transactions** : Suivi des achats, ventes et réparations.
- 🔍 **Menus déroulants** : Par marque, modèle, finition.
- 🔐 **Authentification** : Intégrée via ASP.NET Identity (compte admin par défaut).
- ♿ **Accessibilité** : Vues conformes aux bonnes pratiques des WCAG.

---

## 🧱 Architecture

L’architecture suit le pattern **Repository-Service** et se compose de :

- **Models** : Entités métiers (`Vehicle`, `VehicleBrand`, `VehicleModel`, `Purchase`, etc.).
- **ViewModels** : Données prêtes à l’affichage.
- **Repositories** : Accès aux données via Entity Framework Core.
- **Services** : Logique métier (ex. : `VehicleService`, `PurchaseService`...).
- **Controllers** : Gestion des routes HTTP et interaction entre les couches.

---

## ⚙️ Prérequis techniques

Avant de lancer le projet, veillez à disposer de :

- Visual Studio 2022  
- .NET SDK  
- Une connexion internet pour récupérer les dépendances  


---

## 🚀 Lancement du projet

1. Clonez le dépôt :
    - git clone [https://github.com/BeastWolf691/creer_votre_premiere_application_avec_ASP_NET_Core-P5.git]
   
3. Ouvrez le projet dans Visual Studio 2022 et se positionner sur la branche  :
    - git checkout Steven

4. Accéder au dossier contenant le projet principal :  
cd creer_votre_premiere_application_avec_ASP_NET_Core-P5/DotNetP5-master/P5CreateFirstAppDotNet
     
4. Restaurer les dépendances :  
   - dotnet restore

5. Lancer l'application :
   - dotnet run  

⚠️ Lors de l'exécution, le terminal indiquera l’URL locale (généralement http://localhost:5163) pour accéder à l’application.  

---

## 🔐 Authentification administrateur
Un compte administrateur est préenregistré à des fins de démonstration :
Login : admin@example.com
Mot de passe : P@ssword123

⚠️ Important : Ces identifiants sont destinés à une utilisation en local uniquement et doivent être modifiés avant toute mise en production.

## Technologies utilisées
<p align="left"><img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET" /> <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" alt="C#" /> <img src="https://img.shields.io/badge/Visual%20Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white" alt="Visual Studio"/></p>
