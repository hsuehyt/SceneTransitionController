# SceneTransitionController

## Overview

The `SceneTransitionController` script automates the transition between multiple scenes in Unity, ensuring seamless visual output updates through SpoutSenders. It also provides functionality to pause and resume the scene transitions.

## Features

- Automated transitions between nine scenes.
- Configurable scene durations.
- Integration with SpoutSenders to update visual outputs.
- Pause and resume functionality using the spacebar.

## Requirements

- Unity 2021.1 or later
- Klak.Spout package for SpoutSender functionality

## Installation

1. Clone or download the repository.
2. Open the project in Unity.
3. Ensure the Klak.Spout package is installed in your project.

## Usage

1. Attach the `SceneTransitionController` script to an empty GameObject in your initial scene (Scene01).
2. Ensure that all scenes (`Scene01` to `Scene09`) are added to the build settings.
3. Run the project.

## Script Details

- **Start Method:** Initializes the scene transition loop and updates SpoutSenders for the initial scene.
- **Update Method:** Listens for the spacebar press to toggle pause and resume.
- **SceneLoop Coroutine:** Manages the timed transitions between scenes and updates SpoutSenders.
- **Pause Method:** Pauses the scene transitions and stops the coroutine.
- **Resume Method:** Resumes the scene transitions and restarts the coroutine.

## Scene Durations

- **Scene01:** 5 seconds
- **Scene02:** 3 seconds
- **Scene03:** 15 seconds
- **Scene04:** 3 seconds
- **Scene05:** 15 seconds
- **Scene06:** 3 seconds
- **Scene07:** 15 seconds
- **Scene08:** 3 seconds
- **Scene09:** 15 seconds

## Controls

- **Spacebar:** Pause and resume scene transitions.
