# TeamApiProject

## Introduction

This project was created to fulfill the requirements of ElevenFifty Academy's Blue Badge Final Project.
In this project, the focus is video game creation with a focus on character creation. The user is able to create a character, adding skills, classes, weapons, and more! All group members enjoy the idea of video gaming creation and this was a fun topic for all of us. We gathered inspiration from the well-know game, Dungeons and Dragons.

### Technologies Applied
Desktop Docker, Visual Studio, Postman

### To Get Started
Clone Project <br>
Install Desktop Docker<br>
Install Azure Data Studio
Set up a SQL Server
Create Container in Docker run SQL
Set up connections between SQL, Azure Data Studio and Docker.
Install Repository from GitHub
    cd into the directory where you want to save the project.
    git clone https://github.com/brianlane01/DnDTeamGameApi.git
    Access project through Visual Studio Code.

### Running the application
Open Desktop Docker and run it.<br>
Open coding terminal. <br>
Navigate to your WebApi terminal. <br>
Dotnet run the application.<br>
Open PostMan.<br>
or Open a new instance of VS code from the DnDTeamGame.UI and enter dotnet run into the terminal.
Navigate to the item you'd like to see ---<br>
Example:<br>
Select new request<br>
Select GET <br>
Type http:localhost/api/Character/1 <br>
Select JSON <br>
And a character will be created!

##### Features
    Feature 1: Create Characters

    Feature 2: Custumize Abilities for Character

    Feature 3: Create Vehicles, Delete Vehicles, get a list of vehicles, update avehicle

### Helpful Links
[Planner](https://docs.google.com/document/d/1XrGQA_Nq26nVJWQuMqp32-VNMY8gs3UR4GeNlrbaNMk/edit?usp=sharing)<br>
[Asana Link](https://app.asana.com/0/1205743229163102/1205743229163102)

### Database Diagram
    <iframe width="560" height="315" src='https://dbdiagram.io/embed/652eeb35ffbf5169f0e3ef79'> </iframe>
https://dbdiagram.io/d/BlueBadgeFinalProjectDatabase-652eeb35ffbf5169f0e3ef79


#### Ways to Contribute to Project
1. Fork the repository
2. Create a new branch: `git checkout -b feature-name`
3. Make your changes and commit them: `git commit -m 'Add feature'`
4. Push to your forked repository: `git push origin feature-name`
5. Create a pull request
