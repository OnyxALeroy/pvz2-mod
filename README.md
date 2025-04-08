# pvz2-mod

## What has been done

### Zombies

- A basic zombie wave builder, alongside a generic Zombie Builder ;
- When the wave is linked to the Level Manager (manually for now), the zombies are successfully spawned (at the right place).
- On spawn, the zombies start walking to the left, with the corresponding animation and speed (the speed is encoded by the Zombie's speed type).
- Waves will launched based on levels' internal data (how long to wait between waves, and how much damage needs to be dealt before launching the next one).
- As soon as a Zombie crossed the lawn, Game Over is triggered.

### Plants

- An advanced plant builder, allowing (for now) to build sun producers or attackers.
- A sun economy is built, displayed in the top-left corner of the screen.
- Seed slots are displayed at the left of the screen, and plants can be dragged and dropped on a free tile to be planted. The "click on the plant, then click on the tile" plantation method is also coded.
- If the player hasn't enough sun to plant the selected plant, the sun amount will flash in red. Moreover, un-plantable plants will have their seed slot darken.
- Internal cooldown of the plants is coded, and its duration can be seen as the seed slots gradually returns back to normal (a dark overlay gradually shrink, as in the original game).
- Sunflower and Peashooter have their "Idle" animation.

## Todo-List

### Zombies

a) _[Optional]_ Adding three new animations for the basic Zombie : Idle, Eating and Death ;
b) _[Optional]_ Adding damaged animations to the Zombies.

### Plants

a) _[Optional]_ Adding a new animation for the plants: a shooting one for Peashooter and a producing one for the sunflower.

### Interactions

a) **Zombie on plant:**

- When a Zombie collides with a plant, it switches animations (from Walking to Eating) ;
- The plant's HP should decrease progressively (the more Zombies eating, the faster the plant's HP decrease + every Zombie has a "hunger" attribute which categorize how much damage it deals) ;
- When the plant dies, the Zombie goes back to Walking, and the plant should be removed from the tile (freeing it).

b) **Plant on itself:** every sun producer should produce a certain amount of suns each time (the amount and the cooldown are pre-coded in the Plant's ScriptableObject).

c) **Plant on Zombie**

- Encoding a trigger type to the plant (either its behavior is triggered as soon as a Zombie is in the same line, or if it has a Zombie in the same tile (or in its range)) ;
- The specific deeply depends on the plant, and almost should be "hard-coded" plant by plant.

### On-before level

a) Adding a way to select which plants to bring to the level (choosing how to fill the seed slots) ;
b) Using the already-built Zombie Pool (a list of Zombies) to show the level's Zombie Pool ;
c) _[Optional]_ Adding the animations (sliding to the right, then choosing the plants, then sliding to the left) ;
d) _[Optional]_ Adding a "pop-up" window before launching the plant selection (will be used to show specific winning conditions, or level specifications).

### Final details on the level

a) Adding the progression bar (for the "big waves", a boolean can be added to the ZombieWave ScriptableObject to show it as a "big wave") ;
b) Building the PlantFood structure, and creating PlantFood-carrying Zombies ;
c) For each plant, adding a PlantFood effect ;
d) Adding lawn mowers ;
e) Adding sun drops from the sky (should be removable, using a boolean variable, in the level manager for instance) ;
f) Implementing the shovel, allowing the player to remove a planted plant.
g) **_[Placeholder]_** Adding some sort of pop-up on win.
