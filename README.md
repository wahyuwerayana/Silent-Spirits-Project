# **Forbidden Dreams**
<div align="center">
  <img src="https://github.com/wahyuwerayana/Forbidden-Dream-Project/assets/115724777/27d1cf97-fc30-4845-9e96-6217327e648b" width="60%">
</div>

# 📖Documentation
- Made using Unity Editor 2022.3.19f1
- Assets are made by the Game Artist + from Itch.io

## 🎲Game Mechanics
Player will follow the story of Anisa to escape from the dream world. In the mansion, player's need to complete the objective to get into the boss room. When fighting the boss, player's need to answer some SIBI questions to defeat the boss.

## 📂File Description
```
├── Forbidden-Dream-Project          # This folder contains all the project files.
     ├── Assets                      # This folder contains all of the game assets such as code, sprites, scenes, animation, etc.
        ├── Animation                # This folder contains the animation and animator controller used for the gameobjects.
        ├── Font                     # This folder contains all the fonts that is being used.
        ├── Image                    # This folder contains the environment images used in the game.
        ├── Prefab                   # This folder contains the gameobject prefab to use in the game scenes.
        ├── Scripts                  # This folder contains all of the game script files.
            ├── Beach                  
            ├── Bedroom                  
            ├── Forest                  
            ├── Mansion                  
            ├── ...                  
        ├── Scenes                   # This folder contains scene for the game. You can open these scenes to play the game via Unity.
        ├── Sounds                   # This folder contains sounds that is being used for the game.
        ├── Sprites                  # This folder contains all the entity sprites in the game.
        ├── Tilemap                  # This folder contains the tilemap used in the game levels.
        ├── ....
     ├── ...
```

## 📑Scripts
### **Player**
| **Script Name**    | **Function**                            |
| ------------------ | --------------------------------------- |
| `PlayerMovement.cs` | Manage the player movement logic in the game |
| `PlayerTeleport.cs` | Manage the teleport when the player is inside a teleportable area and pressed a certain button |
| `PlayerInteract.cs` | Make the player can interact with the NPC |
| `PlayerInventory.cs` | The inventory system of the player |
### **Item**
| **Script Name**    | **Function**                            |
| ------------------ | --------------------------------------- |
| `Pickup.cs` | Handle the pickupable item in the game |
### **Boss Fight**
| **Script Name**    | **Function**                            |
| ------------------ | --------------------------------------- |
| `AnswerScript.cs` | Handle the question answer, when the answer is correct the boss will take damage, otherwise the player will take damage |
| `HealthBarScript.cs` | Manage the health system for the player and the boss |
| `etc` |  |
### **Dialogue System**
| **Script Name**    | **Function**                            |
| ------------------ | --------------------------------------- |
| `Dialogue.cs` | Store the dialogue text |
| `DialogueManager.cs` | Manage the dialogue system in the game |
| `DialogueTrigger.cs` | Start the dialogue when the player trigger a specific gameobjects |
### **Other**
| **Script Name**    | **Function**                            |
| ------------------ | --------------------------------------- |
| `CameraStart.cs` | Start the camera transition animation when on a certain scene |
| `CanvasSwitching.cs` | Handle the opening and closing of the SIBI Guidebook |
| `ChangeScene.cs` | Start the transition to another scene when a player enters a trigger |
| `groundFall.cs` | Make a specific ground fall when player enters a trigger  |
| `Teleporter.cs` | Manage the area of the teleporter, so the player can only teleport on a certain place |
| `etc` |  |

## 👥The Team
- [Aaron Medhavi Kusnandar](https://github.com/Aaronmedhavi) & [Allan Alexander Matthew](https://github.com/JeroekPanggang) as the Game Designer
- [I Gde Wahyu Werayana Kusuma](https://github.com/wahyuwerayana) & [Vincent Tanujaya](https://github.com/VuinZ) as the Game Programmer and Game Artist
- Nicholas Diporedjo as the Sound Artist

<br />

## 📄About
Forbidden Dreams is a serious game created with the theme of special needs using SIBI sign language with a combination of role playing, puzzles and a little horror element. The game follows the story of a girl named Anisa who is trapped in a dream world. There she met a ghost named 'A' who would guide her to get out of the dream world. Anisa's journey will certainly not be easy, she has to solve several cases, where to solve them, Anisa has to use SIBI sign language. That way, she can be free from the dream world.

## 🎯Gameplay
Follow the story of Anisa in the dream world and find out how she escape. Using SIBI sign language as her guide, player need to configure the way to escape by completing various quest and defeating enemies.

## 🕹️Controls
| Key Binding | Function |
| ----------- | -------- |
| A, D / Left, Right Arrow Keys | Move the player |
| Space | Jump |
| H | Open SIBI sign language guide book |
| F | Interact and go upstairs |
| E | Go downstairs |
| G | Grab item |
| Left Mouse Button | Attack |

*Player can check the control manual when reaching the mansion chapter by clicking the book icon in the top right corner.

## ⚙️Setup
- Go <a href="https://xtremehyper.itch.io/forbidden-dreams">here</a> to download the game file or go to the release tab
- Download the file
- Extract the .zip file
- Open the .exe file
