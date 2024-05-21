# SceneTransitionController

The `SceneTransitionController` script manages the automatic transitioning between multiple scenes and ensures that specific Spout Senders are updated and maintained across these transitions. This script is useful for applications that require continuous scene changes, such as multimedia installations or presentations.

## Features
- **Scene Transitions**: Automatically transitions between specified scenes after a set duration.
- **Spout Senders Management**: Ensures that specific Spout Sender objects are maintained across scene transitions.
- **Customizable**: Scene transitions and durations can be configured via the Unity Inspector.

## Setup

1. **Script Placement**:
   - Place `SceneTransitionController.cs` in your project's scripts folder.
   - Ensure the `SceneTransitionDrawer` class is in the same folder or a related scripts folder for custom property handling.

2. **Add to GameObject**:
   - Attach the `SceneTransitionController` script to a GameObject in your scene (e.g., `acrossScene`).

3. **Configure Spout Senders**:
   - In the Inspector, add your Spout Senders to the `Spout Senders` list. The expected Spout Senders are `SpoutBack`, `SpoutAngle`, `SpoutGroundAngle`, `SpoutGround`, `SpoutRight`, and `SpoutLeft`.

4. **Configure Scene Transitions**:
   - In the Inspector, add your scene transitions to the `Scene Transitions` list. Specify the scene and the duration (in seconds) for each transition.

## Example Usage

1. **Scene Transition Configuration**:
   - Select the GameObject with the `SceneTransitionController` component.
   - In the `Scene Transitions` list, add elements for each scene you want to transition to. Specify the `SceneAsset` and `Duration` for each element.
   - Example:
     - Element 0: Scene `Scene01`, Duration `5` seconds
     - Element 1: Scene `Scene02`, Duration `3` seconds
     - Element 2: Scene `Scene03`, Duration `15` seconds

2. **Run the Scene**:
   - Play the scene in the Unity Editor. The script will automatically transition between the configured scenes based on the specified durations.

## Notes

- Ensure that all scenes referenced in the `Scene Transitions` list are added to the build settings.
- The Spout Sender objects must exist in the scenes and have the correct names for the script to find and assign them properly.