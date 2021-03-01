# Slothscape Game Documentation

## 1. Concept

The game is based off of a Year 1 project from Professional Practice where our team was required
to create a text-based game with C#, present to the class the ideas we've implemented and our
workflow. We're simply going to bring it to life and apply some new unique ideas to try to
differentiate it from other rogue-likes.

## 2. Story

The game is about an endangered sloth who is being chased by poachers in the forest. During the escape the sloth
is forced into the sewers and for some reason the entrance is blocked off by debris. The sloth must try to find 
another way out of the sewers without being skinned. Somehow the poachers enter the sewers through other entrances
although they're one-way. The sloth's hide must be really valuable for them to chase it this adamantly.

## 3. Player

The game will be single-player and only playable on PCs.

## 4. Gameplay

### 4.1 Interaction
The player will control a sloth that somehow has the average human walking speed and they
will be able to explore a small map comprised of smaller rooms. They can collect items by walking 
over them and enter new rooms by walking into a door that leads to a different room should they have
the key for that new room.

### 4.2 Enemies
When entering an unexplored room a set amount of enemies will spawn with a randomized amount of enemy
types chosen. For now there will be only one type of melee and ranged enemies that can shoot projectiles
at the player. Should the player walk into them regardless of the type they'll receive one heart of damage
every three seconds if the player decides to just stay in the same tile as an enemy.

Room for improvement for enemies includes varying movement speed, attack speed, and being able to apply
different status effects on the player depending on the enemy type. For now there will only be one type of
enemy per archetype.

#### 4.2.1 Melee Poacher
The melee poacher will charge at the player with some kind of melee weapon (axe, scythe, ice pick, lightsaber etc.) 
and will have a range of one tile wherever they're facing. They'll try to run at the player using the shortest 
path available while avoiding obstacles. Once the player is within range they'll attempt to swipe at the player 
while standing in place.

#### 4.2.2 Ranged Poacher
The ranged poacher will move in random directions and shoot a projectile at the player every three seconds.
Also possibly once they select a direction to move they'll move a certain amount of tiles in that direction
before deciding on a new one, regarding obstacles of course.

## 5. Objective

The objective is for the player to find the way out of the sewers by utilizing various 
items that can be found in chests or dropped from enemies to unlock new areas that 
can lead to escape and increase the player's stats to be able to fend said enemies off more easily.

## 6. Graphics

### 6.1 Perspective
The game will have a pixelated style similar to Pokémon (1st - 2nd Gen) or Stardew Valley. It will also be
viewed at a similar perspective between a top-down view and birds-eye view also similar to these games.

### 6.2 Setting
The majority of the game will be based in an abandoned sewer that hasn't been maintained for a long time, and
possibly the entrance and exit sequences be of the forest before the player enters the sewer and when they escape.
