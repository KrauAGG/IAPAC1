# NPC BEHAVIOUR
## Wandering
Achieving a realistic behaviour with smooth movement requires careful handling of several decisions. The first is to define random routes that feel like real wandering, complemented by steering movement and random pauses between waypoints to make the NPC feel alive. The behaviour is implemented with NavMeshAgent and Visual Scripting. A low velocity and smooth acceleration produce a more organic movement than purely kinematic motion, although it can still feel somewhat robotic.

To make the behaviour feel more natural, a random pause between two configurable values makes the NPC appear to wander and observe the environment, though the result is still not as satisfactory as intended. A trick that smooths directional changes and sharp pathing is to attach this behaviour to an empty GameObject and have the real NPC follow that object. The movement then feels much more natural than before.

<img src="ReadmeImages/TimerHandling.png" alt="Timer handling graph">
<img src="ReadmeImages/MovementHandling.png" alt="Movement handling graph">

Choosing the path is also very important, so the Reynolds wander circle is used to make the movement more continuous. When choosing a new path, the NavMesh is queried to check whether the path is inside the walkable area (with an error margin called Max Distance). If the chosen path is out of bounds, the opposite direction is assigned. This decision prevents the NPC from getting stuck in corners or walls.

<img src="ReadmeImages/SettingCheckingPath.png" alt="Walkable path check">

<iframe width="560" height="315" src="https://www.youtube.com/embed/E8dyxA_w4HA" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" referrerpolicy="strict-origin-when-cross-origin" allowfullscreen></iframe>

## Patrolling

## Fleeing

## Finite State Machine (FSM)

