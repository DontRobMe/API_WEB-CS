API Web pour Gestion de Projets
Introduction
Cette API web a été développée pour faciliter la gestion de projets en offrant des fonctionnalités pour la création de projets, de teams, d'utilisateurs, de tâches et de tags. Son objectif est de fournir une interface intuitive pour gérer ces entités tout en maintenant la cohérence des données.

Utilisation sans soucis
Pour une utilisation sans soucis, veuillez suivre l'ordre des opérations ci-dessous :

Créer un Projet

Commencez par créer un projet sans spécifier le responsable. Les IDs des responsables seront ajoutés plus tard après la création de tous les éléments.

POST /projets
Content-Type: application/json

{
"nom": "Nom du Projet"
}

Créer une Team

Ensuite, créez une équipe sans désigner de team leader. Les IDs des team leaders seront ajoutés après avoir créé tous les éléments.

POST /teams
Content-Type: application/json

{
"nom": "Nom de l'Équipe"
}

Créer un Utilisateur

Ajoutez un utilisateur en l'associant à une équipe.

POST /utilisateurs
Content-Type: application/json

{
"nom": "Nom de l'Utilisateur",
"team": "ID de la Team"
}

Créer une Tâche

Une fois les utilisateurs ajoutés, créez une tâche en la liant au projet existant.

POST /taches
Content-Type: application/json

{
"titre": "Titre de la Tâche",
"description": "Description de la Tâche",
"projet": "ID du Projet"
}

Créer un Tag

Après avoir créé des tâches, ajoutez des tags pour les organiser.

POST /tags
Content-Type: application/json

{
"nom": "Nom du Tag"
}

Ajout des Responsables et Team Leaders

Une fois tous les éléments créés, modifiez les projets pour ajouter les responsables et les équipes pour désigner les team leaders en ajoutant les IDs correspondants.

