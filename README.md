# rpg
This demo game includes the following features.

Character Configurator:
● Player can choose a gender.
● Player can choose 3 skin types.
● Player can change characters hair type and  its color.
● Player can change characters outfit and its color.

Movement:
● WASD Movement
● Left-right look with mouse input.
Dialogue:
● Player can speak with the NPCs that has a sign on their head.
● If player does not have an active quest, NPCs offers a quest. Player can accept of decline the quest.
● If player has an active quest that is not completed and the NPCs is the owner of the quest, the NPC tell player to come back later.
● If player has an active quest that is not completed and the NPCs is not the owner of the quest or the quest is completed but NPC is not the owner the NPC tell player to finish the quest first.
● If player has an active quest that is completed and the NPCs is the owner of the quest, the NPC rewards the player and takes the items from the inventory.

Inventory:
● Player can collect some items in the world.
● The items stacks in the relevant slot.
● Only the collectables can be seen in the inventory. A player can only have one weapon so weapons will automatically equipped by the player.

Quest:
● Tutorial Quest is given to player automatically at the beginning of the game.
● Except the Tutorial Quests, all quest are given by an NPC.
● Player can only have one quest at a time.

AI:
● Basic AI Movement: NPC travels to the given points in a list and waits until the given time before move to the next.
● AI with a Field of View: NPC detects player if the player enters the field of view of the NPC. The distance and the view angle can be changed.
● Enemy AI: Detects and chase the player in a certain distance. May or may not patrol. Attacks the player if the player is close enough. 

Load/Save:
● Player can only have one save slot.
● After the character creation, the configured character is saved.
● Game automatically saves if the player quits the game.
● When player quit, the player transform, inventory, active quest and quest progressions are saved.
● New game deletes the old loaded data.
