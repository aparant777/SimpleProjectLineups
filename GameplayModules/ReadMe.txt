This is the Readme by Aparant Mane, for a small prototype. 
More details can be found here:  https://github.com/aparant777/SimpleProjectLineups

Main goal of the game is to take down the AI Base. 
You will be controlling the minions and their spawning and other behaviours in order to pass throught the AI's towers. 
The AI will slowly try to understand the player's motives and counter play by spawning towers inorder to save its base. 

Use the WASD keys for now, to control one of the towers (highlighted in RED). If AI Base Health falls to 0, game over!!


For the Model-View-Controller approach, I partitioned the files/scripts as taught in the class on Thursday.

Managers and controllers are now under Controller. Classes which offer functionality based model approach are now under Model. 
Classes which are responsible for showing any output or printing any data or responsible for handling the UI are in View. 

Controller(CheckEvasionTrigger, EventManager, Manager, TowerController)
View(UIManager, Path)
Model(CONSTANT, MinionSpawner, MinionDestroyer, Node, Projectile, Tower, Zombie)

is the segregation of all the classes.

Unit Tests: 
------------------------------------------------------------------------------------------------------------------------------------------------------
Unit Test #1
------------------------------
Zombie.cs
LOC: 161
A generic unit test case. Testing the variables within different ranges and conditions.
------------------------------------------------------------------------------------------------------------------------------------------------------
Unit Test #2
------------------------------
Zombie.cs
LOC: 147
Testing health pool of zombie under certain conditions.
------------------------------------------------------------------------------------------------------------------------------------------------------
Unit Test #3
------------------------------
A simple Unit test case, which checks if any null refernce has been passed or not.
MinionSpawner.cs
LOC 84
------------------------------------------------------------------------------------------------------------------------------------------------------


There is also a video which shows the WIP prototype. 

Thanks,
Aparant.
