# MusicCatalog

A desktop application for exploring and managing a music catalog, developed using **C#**, **WPF**, and **.NET 6**.

MusicCatalog was developed as a team project for the Software Specification and Modeling course at the Faculty of Technical Sciences, University of Novi Sad.

The application is a functional prototype designed to demonstrate role-based interfaces, music content management, and user reviews and ratings.

## Features

### Music Catalog
- Browse available music works.
- Search music works by title or artist.
- View detailed information about music works, including genre, publication date, format, and lyrics.
- Display cover images and associated reviews.

### User Roles
The application supports different interfaces and functionality for:

- **Guest users** – browse and explore music works without signing in.
- **Registered users** – access music content and submit reviews and ratings.
- **Music editors** – add new music works to the catalog.
- **Administrators** – access a dedicated administrative interface.

### Reviews and Ratings
- Submit written reviews for music works.
- Rate music works on a five-star scale.
- View reviews associated with individual music works.

### User Authentication
- User registration and login.
- Role-based navigation after login.

## Technologies Used

| Technology | Purpose |
|---|---|
| C# | Application logic |
| .NET 6 | Application framework |
| WPF / XAML | Desktop user interface |
| CSV files | Local data persistence |
| Git & GitHub | Version control and collaboration |

## Project Architecture

The application organizes its code into the following layers:

- **Model** – domain entities and data structures.
- **View** – WPF windows and user interface components.
- **Controller** – communication between the user interface and application logic.
- **Service** – application operations and business logic.
- **Repository** – data access and CSV file persistence.

## Getting Started

### Prerequisites

- Windows operating system
- Visual Studio with .NET desktop development support
- .NET 6 SDK and the required Windows Desktop runtime

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/teodorabelic/MusicCatalog.git
   ```

2. Open `MusicCatalog.sln` in Visual Studio.
3. Restore the project dependencies.
4. Build and run the application.

**Note:** This is an academic prototype that uses local CSV files for persistence. Some features and data-loading operations depend on the application's original directory structure and working directory.
