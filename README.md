# pvz2-mod

## What's have been done

### Zombies

- A basic zombie wave builder, alongside a generic Zombie Builder ;
- When the wave is linked to the Level Manager (manually for now), the zombies are successfully spawned (at the right place).
- On spawn, the zombies start walking to the left, with the corresponding animation and speed (the speed is encoded by the Zombie's speed type).
- Waves will launched based on levels' internal data (how long to wait between waves, and how much damage needs to be dealt before launching the next one).
- As soon as a Zombie crossed the lawn, Game Over is triggered.

## Todo-List

### Zombies

a) _[Optional]_ Adding three new animations for the basic Zombie : Idle, Eating and Death ;
b) _[Optional]_ Adding damaged animations to the Zombies.

### Plants

a) Adding a Plant Builder (using the ScriptableObject class) ;
b) Adding the left seed slots (showing the selected plants with their cost) ;
c) Coding the "Drag & Drop" and the "Click & Click" methods to plant, decreasing the sun amount by the plant's cost (the current available sun amount is for now a pre-determined value) ;
d) Adding a cooldown timer between each plantation ;
e) Adding a tile verification before planting (is the tile available?) ;
f) _[Optional]_ Adding animations to plants.

### Interactions

a) **Zombie on plant:**

- When a Zombie collides with a plant, it switches animations (from Walking to Eating) ;
- The plant's HP should decrease progressively (the more Zombies eating, the faster the plant's HP decrease) ;
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
