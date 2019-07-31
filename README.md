# AdvGameDevAssignment1

## ToDo

## Objective

* Using Unity, create a level that includes the five types described in the next section (either one level with all 5 types or 5 levels with one type each).
* All NPCs have health and the ability to shoot.
* All NPCs are represented by an animated 3D character through Mecanim.
* Animations may apply to each states; for example: walking, running, shooting, dying, or punching and these can be using the FBX animations present on Moodle.
* Use an environment that consists of either an outdoor scene or a combination of basic shapes.

## Type 1

* Walks on a predefined path using waypoints.(done)
* Follows the player after detecting him/her through sight, hearing or smell or after being hit.(done)
* Shoots at the player while following the player (e.g., every 3 seconds).(done)
* Dies when health is low (<= 0).(done)
* Does not recharge ammunitions when low.(done)
* Goes back to patrolling after losing sight of the player.(done)

## Type 2

* All features found in type 1 except that it walks following random waypoints and follows the player after being attacked by the player.(done) 
* Looks for ammunitions when its ammunitions run low (e.g., less than 20%).
* Looks for health packs when its health runs low (e.g., less than 20%).
* Can locate (and go to) health packs (or health zones) and ammunitions based on theirs positions (i.e., the closest).
* If health is low and no health packs are available, this NPC will try to avoid the player.

## Type 3

* Deliberately walks towards the player using Navmesh.
* Uses or avoids specific predefined areas based on costs.
* Shoots at the player while following the player (e.g., every 3 seconds).
* Looks for ammunitions when its ammunitions run low (e.g., less than 20%).
* Looks for health packs when its health runs low (e.g., less than 20%).
* Can locate (and go to) health packs (or health zones) and ammunitions based on theirs positions.
* If health is low and no health packs are available but ammos are high, this NPC will keep chasing the player until new ammos become available.

## Type 4

* Always tries to run/walk away from the player.
* Will ambush the player when the latter enters a specific zone with a trigger (e.g., it will go to the ambush site and throw a grenade towards the player).This behaviour should use a sub-state machine and a Behaviour script.
* Looks for health packs when its health runs low (e.g., less than 20%).
* Can locate (and go to) health packs (or health zones) and ammunitions based on theirs positions.

## Type 5

* The player leads a team of 4-5 team mates.
* The team members follow the leader, and stop when within 2 meter.
* The player can order its team members to attack specific NPCs (one-to-one to several-to-one).
* The attacks from the team members consist of punches (i.e., close range).
* The player can order its team members to withdraw from an attack.
* After withdrawing from an attack, the team members will follow the leader.

## Type 6

* Includes a leader (NPC) and its team mates (4 or more) 
* The leader will patrol the scene using waypoints.
* The team members follow the leader, and stop when within 2 meter.
* The leader will order its team members to attack the player when the latter is detected by the leader through sight or hearing.
* The attacks from the team members consist of punches (i.e., close range).
* The leader will order its team members to withdraw from the attack when one of the team member has been eliminated.
* After withdrawing from an attack, the leader will resume the patrol.
* The team members and the leader can be hit by the player.
* The leader can be hit.
* If the leader dies, its team members will scatter and walk aimlessly.

## Level

* Health packs are spawn frequently depending on whether health packs are already available. (done)
* The player will need to collect 10 items before the time is up (3 minutes). (done)
* The player avails of a gun and health.* The player will be able to replenish its health levels and ammunitions by collecting ammunition and health packs. (done)
* When an NPC collides with the player, the current level is restarted.
* The environment needs to include platforms (for the use of off-mesh links), different areas (each with an associated cost), and obstacles.
* All NPCs need to use an FSM.* For each NPC, use a colored sphere placed above the NPC that can be seen from the y-axis.
* The player wins when s/he has collected all the items within the time limit without being caught by the NPCs.

## Marking (Each are around five percent each)

* <40% (fail) No NPCs were implemented.
* 40%: Types 1 is fully implemented.
* 40-45%: Types 2 is fully implemented.
* 46-50%: Types 3 is fully implemented.
* 51-65%: Types 4 is fully implemented.
* 66-70%: Types 5 is fully implemented.
* 71-75%: All the above + new NPCs of random types are instantiated at an increasing frequency.
* 76-80%: A third-person view is used with a 3D character animated through a 1D blend tree.
* 81-86%: A third-person view is used with a 3D character animated through a 2D blend tree.
* 87-90: Some of the NPCs are using an Animator Controller Override.
* 91-95%: All the above + code is indented and commented in parts + clear interface.
* 96-100%: All the above + screen cast and list of features implemented were provided.

## Delivery

* List of the features that you have implemented and where (file name and method, if/where applicable).
* Full project zipped.
* A screen-cast (link to be provided).
* A webGl version.