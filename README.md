# LightsOut Project Report
Unity Game Project #1
## Intro

This is the working prototype for the game I want to put together. In the future, Id like to come back to this project and turn it into a full idea. But for now this set of features and demo is the minimum viable product (very minimum), and allows for playtesting of the games features in a meaningful way.

### Objective
Collect all 7 collectibles without dying.

## The features

The game has a standard WASD movement scheme, a gun shot with left control, and a sonar used with right alt.
This game has the following core features:

### Sonar

The sonar is the core of the gameplay. It reveals all the major game objects so the player. The enemies, the walls, and the collectibles are revealed by this object. You press left control and it send out a pulse. This pulse hits objects and reveals them on the minimap for a short time. Any enemies hit by the pulse are now active and if within range will come running at you. 

### Enemies

The enemies have a few features. When they leave your sonar range they get a temporary boost to keep up with you and they only start moving when hit by the sonar for the first time. There was a bug with the game where the enemies would bug out trying to move forward so I added a slight delay when they leave the sonar range. This allows the scripts to catch up to the next state. This is just quality of life to keep the protoype moving.

### Collectibles

Collectibles are invisible till hit by the sonar. They add to your score when collided with and are destroyed after. In this case, when you collect 7 the game is over.

### Gun

The gun shoots little balls that only destroy the enemies in a certain range. This allows the enemies to chase after the player for a long time, forcing the player to turn around and kill the enemies. In the future, this will have an ammo limit, making the choice much more meaningful. But for testing purposes, unlimited ammo was best.

