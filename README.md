# Elevator System Simulation (Unity)

## Overview
This project is a real-time elevator system simulation built using Unity and C#.  
The focus of the project is on system design, state management, and time-based movement rather than visuals or gameplay.

## Features
- Enum-based state machine (Idle, MovingUp, MovingDown, DoorOpen)
- Smooth, time-based elevator movement between floors
- Floor selection UI
- Automatic door open/close on arrival
- Clear separation of controller, movement, door, and UI logic

## Technical Highlights
- State-driven architecture
- No physics-based movement (no Rigidbody)
- Deterministic floor positioning
- Modular and readable C# scripts

## Scenes
- **Scene1**: Stable non-FPS elevator simulation (portfolio version)

## Future Work
- First-person elevator experience (WIP in separate branch)
- Request queue handling
- Emergency stop logic

## Tools & Tech
- Unity
- C#
- TextMeshPro
- Git & GitHub
