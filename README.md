## InfinityWorks TechTest

#### Pete BURCH

### User Story

The web app implements the following user story:
```
As as user
I want to see how food hygiene ratings are distributed by percentage across a selected local authority
So that I can understand the profile of establishments in that authority
```
### Installation Instructions
Unzip the archive, and open `InfinityWorks_TechTest.sln` using Visual Studio 2015. Tests are run using VS's integrated feature, likewise the app can be tested using IIS Express.


### External packages used:
In the app:
- Newtonsoft.Json
- Unity IoC

For testing:
- NUnit
- Moq
- mockHttp


### Notes
The app is built in Visual Studio using the MVC scaffolding. Unused components have been excluded from the project.
Code is uncommented as it should be sufficiently self-explanatory.
Not being a graphic designer, minimal time has been spent on layout.
All Testing has been conducted at the unit level.
Operation of the app has been verified in Google Chrome.


### Assumptions
The MVC framework provides error handling for API requests that throw errors and
