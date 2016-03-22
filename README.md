# The Gallerist Online Multiplayer Board Game

Our project is a web-based implementation of a physical board game called The Gallerist. This project aims to bring a fun board game online for more users to experience and enjoy while adding useful features for an online community including tournaments, chat rooms, ranking, metrics and more. We want to bring the excitement of a new board game with a small community online so that more people can enjoy and learn this delightful game!

## Installation


#### Required Software

You will need the following software installed to this application:

- Visual Studio
- LocalDB (SQL Server Express)
    - Other databases work but LocalDB works without any modifications
- Papercut SMTP Client

#### Setup

- Clone the repository in Visual Studio (or w/ any git client)
- Open solution in Visual Studio
- Open Tools -> NuGet Package Manager -> Package Manager Console 
- Make sure that the Default Project selection is "TeamJAMiN.Web" and issue the following commands:
    1. Enable-Migrations -contexttypename GalleristComponentsDbContext -migrationsdirectory DataContexts\GalleristComponentMigrations
    2. Update-Database -configurationtypename TeamJAMiN.DataContexts.GalleristComponentMigrations.Configuration
    3. Update-Database -configurationtypename TeamJAMiN.DataContexts.IdentityMigrations.Configuration
- Run and be merry

## Using the Application

#### Current Functionality

*For the most up-to-date functionality please refer to [completed GitHub issues](https://github.com/SIU-CS-435/jamin-production/issues?q=is%3Aissue+is%3Aclosed) and for upcoming features refer to [open issues](https://github.com/SIU-CS-435/jamin-production/issues?utf8=%E2%9C%93&q=is%3Aissue+is%3Aopen)*

- User Registration/Login
- Create and persist a basic game instance
- View a list of all in-progress games and re-open games in which you are a member
- Require authorization to create/join games

-----

**Created by Team JAMiN Members:**

 - Mike Brajkovich | zeroone@siu.edu | siu850104216
 - Nathaniel Grudzinski | n.grudzinski@siu.edu | siu851296425
 - Jonah Borders | bordersjb@siu.edu | siu852046497
 - Axel Wales | axelwales@siu.edu | siu853666547
