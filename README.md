Deckbuilding Blazor App
This is a web-based deckbuilding application built using Blazor. It allows users to create, manage, and customize their own card decks for Magic the Gathering's Standard format.

Features
Create and manage decks: Add, remove, and modify cards in your custom decks.
Save and load decks: Store decks locally or persist them across sessions.

Technologies
Blazor WebAssembly: A web framework that allows you to run C# directly in the browser.
.NET 6/7: The backend for the app, leveraging the power of .NET for performance and scalability.
Bootstrap: For responsive design and layout management.
Local Storage: Save user data like decks and card collections in the browser's local storage.
C# & Razor Components: For building reusable components that encapsulate functionality.

Getting Started
To run this app locally, follow these steps:

Prerequisites
Visual Studio with the ASP.NET and web development workload installed.
.NET SDK version 6 or later.
Installation
Clone the repository:

git clone https://github.com/ClayGrant/CodeLouCapstone.git

Navigate to the project folder:

cd CodeLouCapstone

Restore the required NuGet packages:

dotnet restore

Run both the CodeLouCapstone.Api and CodeLouCapstone.App projects to start the app

Open your browser and go to https://localhost:7234/decks to start using the app.

Usage
Create a Deck: From the homepage, click on the "Create New Deck" button. You can add cards to your deck by searching for them and adding them from the available card list.

Manage Deck: Once a deck is created, you can edit it by adding, removing, or reordering cards.

Save and Load Decks: Your deck will be saved to the local Database file.

Notes
Ignore CodeLouCapstone.App2
All cards must be taken from the All Cards page
For ease of testing, any of the following cards 60 times is a legal deck:
Forest, Island, Plains, Swamp, Mountain