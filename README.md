# Invasive

*A short stealth-horror game in Unity. You search an overrun research station for your spouse, and the only
things that will keep you breathing are the monsters trying to kill you.*

[![Trailer](https://img.shields.io/badge/▶_Watch-trailer-C9003C)](https://www.youtube.com/watch?v=jTt13RJBWTk)
[![Walkthrough](https://img.shields.io/badge/▶_Watch-full_walkthrough-C9003C)](https://www.youtube.com/watch?v=YZrPg6T44cU)
[![Case study](https://img.shields.io/badge/Read-case_study-2D50C8)](https://rohan-samuel.github.io/projects/invasive.html)
![Unity](https://img.shields.io/badge/Engine-Unity-black)
![Language](https://img.shields.io/badge/C%23-gameplay-239120)

Jesse lands on a moonbase to answer a distress call and find their wife, Alice. The ship is crushed on arrival,
the station is full of carnivorous plants, and the air is running out.

## The idea

Oxygen drains everywhere in the station. There are only two ways to get it back: the tanks at checkpoints, and
the plant creatures themselves. Staying alive means deliberately walking toward the things that can kill you.

There is no combat. You sneak, you distract, and you solve the station's item-and-switch puzzles, and every
second of that is spent on a timer you can only refill by taking a risk.

## Play it

Download the build from [Releases](../../releases), extract, and run the executable. The
[walkthrough](https://www.youtube.com/watch?v=YZrPg6T44cU) covers the full game with developer commentary if
you would rather watch than play.

To open the project, note that the Unity project root is `Invasive_1/` rather than the repository root. Open
that folder through Unity Hub.

## How the systems work

### Oxygen

`PlayerStat` holds the whole game loop in one number. Oxygen sits at a maximum of 100 and drains at 1 per
second in normal air, rising to 3 per second inside a fungal choke zone. Standing near a supply flips
`isGainingO2` and it refills at a fixed rate instead. Hitting zero is death, and a respawn returns you to the
last checkpoint with the oxygen and bottle count you had when you saved.

### Enemy senses

Each enemy carries a `viewRadius` and a `viewAngle`, so detection is a real vision cone rather than a distance
check, with a separate trigger volume for hearing. Contact is not uniformly fatal: some enemies kill outright,
others accelerate the oxygen drain. The station has four kinds of threat, each with its own behaviour scripts:
the Shambler, the Vines, a Venus flytrap, and a seed-shooting boss.

### State machines

Enemy behaviour runs on [UnityHFSM](https://github.com/Inspiaaa/UnityHFSM), a hierarchical finite state machine
library, with Unity's NavMesh components for pathing. Patrol, chase and attack are states rather than tangled
booleans.

### Throwing

`ThrowingHandle` spawns a beaker at a throw point and applies an impulse built from the camera's forward vector
plus an upward component, with a charge bar driving the force. Thrown glass makes noise, noise pulls enemies,
and several puzzles are only solvable by moving an enemy somewhere else.

## Repository layout

| Path | Contents |
|------|----------|
| `Invasive_1/` | The Unity project |
| `Invasive_1/Assets/Scripts/Player/` | Movement, input, oxygen, stealth, throwing |
| `Invasive_1/Assets/Scripts/Shambler/` | Shambler AI, vision cones, patrol |
| `Invasive_1/Assets/Scripts/Vines/` | Vine enemies, hearing, power boxes |
| `Invasive_1/Assets/Scripts/SeedShooterBoss/` | Boss AI and projectiles |
| `Invasive_1/Assets/Scripts/Buttons/` | Button and switch puzzle components |
| `Models/`, `Animation/`, `Environmental Assets/` | Source art kept outside the Unity project |

## Credits

Built by a team of four over one semester (Fall 2022) for a course at Simon Fraser University.

Rohan Samuel was lead programmer and texture artist: the C# gameplay code, character movement and animation
state, the stealth system, the oxygen mechanic, the throwable-beaker system and its UI, all model textures in
Substance Painter, and integrating the team's audio and animation assets into a working build.

The other three team members contributed models, animation, audio and level design. The walkthrough commentary
is by teammate Bret.

[Design document](https://drive.google.com/file/d/1PoHwUTUVteTtI4QINM7VK6Y72tpcCK0V/view?usp=sharing) ·
[Case study](https://rohan-samuel.github.io/projects/invasive.html) ·
[Portfolio](https://rohan-samuel.github.io)
