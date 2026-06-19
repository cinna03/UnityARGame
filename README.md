 AR Shooter Game (Unity + AR Foundation)
 Project Overview
This project is a mobile Augmented Reality (AR) Shooter Game developed using Unity and AR Foundation. The application allows users to place a virtual game environment onto a real-world surface and interact with enemies through a shooting system.
The game demonstrates core concepts of AR development, real-time gameplay systems, object pooling, and UI management, combined into a fully interactive experience.

 Features
 Core Gameplay

First-person shooting mechanic using camera-based aiming
Crosshair-based targeting system
Two enemy types:

Melee Enemy – moves toward the player and deals close-range damage
Shooter Enemy – attacks from range with timed damage


Dynamic enemy spawning system
Score tracking and kill counting
Game timer with automatic game over


 Player Systems

Health system with real-time updates
Damage feedback (screen flash)
Shooting cooldown system
Restart and main menu navigation


 UI System

Start menu, gameplay UI, and end screen
Real-time updates for:

Health
Score
Timer


End game summary:

Final score
Total enemies defeated
Survival time




 Leaderboard System

Local leaderboard using PlayerPrefs
Stores and displays top scores
Sorted by highest score
Displays up to top 5 entries


 AR Functionality

Plane detection using AR Foundation
Tap-to-place game environment in real world
Game world anchored using a GameWorldRoot
Gameplay begins after placement


 Performance Optimization

Bullet system implemented using Object Pooling
Avoids frequent instantiation and improves performance


 Project Structure
AR Session
XR Origin (AR)
   └── Main Camera
        └── FirePoint

Managers
   ├── GameManager
   ├── UIManager
   ├── ObjectPool
   ├── LeaderboardManager

GameWorldRoot
   └── EnemySpawner

Canvas_Main

ARPlacementManager


 Key Systems Implemented

✅ Game state management (Start → Playing → Game Over)
✅ Enemy AI behaviors (movement + attack)
✅ Object pooling system for bullets
✅ Raycast-based shooting system
✅ AR placement system
✅ UI and feedback system
✅ Persistent leaderboard storage


🎥 Demo Instructions
To demonstrate the game:

Launch the application
Move the device to detect a surface
Tap to place the game in the environment
Aim using device movement (AR camera)
Shoot enemies and observe score updates
Allow the game to end or lose health
View the end screen summary
Restart the game or check the leaderboard


 Technologies Used

Unity (Game Engine)
C#
AR Foundation (ARCore/ARKit)
TextMeshPro (UI system)
PlayerPrefs (local data storage)


 How to Run

Open the project in Unity
Ensure Android Build Support is installed
Connect a compatible Android device
Build and Run the APK
Ensure camera permissions are enabled


 Future Improvements (Optional)

Add sound effects and background music
Introduce player weapon upgrades
Improve enemy animations
Expand leaderboard to online storage
Add UI polish and visual effects

Conclusion
This project demonstrates a complete AR-enabled interactive game with multiple integrated systems, including gameplay mechanics, UI design, performance optimization, and AR environment interaction.

