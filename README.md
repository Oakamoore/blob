
<p align="center">
  <img src="https://github.com/Oakamoore/blob/assets/57583938/9ec4262e-a00c-449d-8860-c8b308739e3d" />
</p>

<p align="center">
  <a href="https://github.com/Oakamoore/blob/blob/main/LICENSE">
	 <img src="https://img.shields.io/badge/License-MIT-green"/>
  </a>
  <a href="https://unity.com/releases/editor/whats-new/2022.1.15#installs">
	<img src="https://img.shields.io/badge/Unity-2022.1.15f1-57b9d3.svg?style=flat&logo=unity&color=orange"/>
  </a>
</p>

## Overview
**Blob** is a top-down online multiplayer arena shooter, in which players are blobs of slime that shoot slime balls at each other. 

Its online multiplayer was built using [Photon Unity Networking (PUN)](https://www.photonengine.com/pun), which employs a room based system - allowing players to browse a list of user-created rooms (each supporting up to 4 players).

Each room has its own online chat - built with [Photon Chat](https://www.photonengine.com/chat) - allowing players to converse while waiting for a game to start.

<div align="center">

|![](https://github.com/Oakamoore/blob/assets/57583938/d3c49269-e118-4fd5-a376-b66e8a498001)<font size="-1"><br>Room Selection Menu</font>|![](https://github.com/Oakamoore/blob/assets/57583938/2a918b21-90e9-4229-99db-d678f0bcb137)<font size="-1"><br>Room Chat</font>|
|:-:|:-:|

</div>

When a game is started players compete against each other in an enclosed arena, and whoever has the most kills at the end of a game gets their score placed on an online global leaderboard (created using [PlayFab](https://playfab.com/multiplayer/#stats)).

There's also a single player game mode, that serves as an introduction to the game's mechanics.

<div align="center">

|![](https://github.com/Oakamoore/blob/assets/57583938/c8392a51-d1b8-4aa6-8459-db7a03fce533)<font size="-1"><br>Multiplayer Game Mode</font>|![](https://github.com/Oakamoore/blob/assets/57583938/99fde646-5717-42e9-af0d-2949c21c604e)<font size="-1"><br>Singleplayer Game Mode</font>|
|:-:|:-:|

</div>

Click [here](https://www.youtube.com/playlist?list=PLdwIq7AG9mogAUu6oBWHTSHIc0lsWWEL6) to watch a two-part in depth video demonstration.

## Installation

This project was built using [Unity 2022.1.15f1](https://unity.com/releases/editor/whats-new/2022.1.15#installs), and should work as expected on that version. Downgrading or upgrading this project to a different version of Unity may cause issues. 

***
> Below are the two different ways to download this project, the **first** being the recommended approach.

### 1. Unity Hub

- Clone this repository with `git clone https://github.com/Oakamoore/blob.git`
- Open [Unity Hub](https://unity.com/unity-hub)
	- Click *Add*, browsing to the location of the previously cloned repository
	- Select the cloned repository's base directory
	- Open the newly added project via Unity Hub

### 2. Unity Package 

- Navigate to the `blob/Packages/blob.unitypackage` file in this repository, and download it
- Create and open a **new** Unity project
- In the Unity editor, under the *Assets* tab, find *Import Package*, then select *Custom Package*
	- Browse to the location of the downloaded `blob.unitypackage` file, and select it 
	- Click *Import* on the *Import Unity Package* window that should appear in Unity

***
Once the project is downloaded and open in Unity, navigate to `Assets/Scenes/MainMenu`, open the scene and play (`CTRL + P`).

This project is also available over on [itch.io](https://itch.io/), as a downloadable executable:

<div align="center">
	<a href="https://oakamoore.itch.io/blob">
		 <img src="https://github.com/user-attachments/assets/fc89694c-2e88-4bb3-aa5b-7d336cb3990a" width="400px"/>
	</a>
</div>

## References

> The following is a list of links to the assets used in this project.

**Models** - [Slime](https://sketchfab.com/3d-models/slime-creature-f176c00e63c24155b2c308b06cdb32d8) (Modified within [Blender](https://www.blender.org/)), [Main Menu Lettering](https://sketchfab.com/3d-models/bubble-letters-ef49e3ea68f04223b173d86991c77d1c), [Stylised Stones](https://sketchfab.com/3d-models/stylized-stones-minipack-719d8ee393db4b218ace19ce9124918d)

**Sound Effects** - [Shooting](https://freesound.org/people/deoking/sounds/411671/), [Impact](https://freesound.org/people/yottasounds/sounds/232135/)
