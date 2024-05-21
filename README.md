### README for SpoutSender.cs and SceneTransitionController.cs

## Overview

This README provides information on the `SpoutSender.cs` and `SceneTransitionController.cs` scripts. The `SpoutSender` script is part of the Klak Spout package and is used for capturing and transmitting rendered frames from Unity applications to other applications via the Spout protocol. The `SceneTransitionController` script manages automatic scene transitions in Unity, ensuring specified Spout Senders are maintained across these transitions.

<details>
  <summary>SpoutSender.cs</summary>

### SpoutSender.cs

The `SpoutSender` script captures and transmits rendered frames using the Spout protocol. It supports multiple capture methods, including GameView, Texture, and Camera capture.

**Key Features:**
- Multiple capture methods (GameView, Texture, Camera)
- Render texture management
- Spout protocol integration
- External update trigger with `PublicUpdate()` method

**Difference Between Original and Public Update Versions:**
- **Original Version:** Did not include a public method for external updates.
- **Public Update Version:** Includes a `PublicUpdate()` method allowing external scripts to manually trigger the private `Update()` method.

**Installation:**
To use the updated `SpoutSender` with the `PublicUpdate()` method:
1. **Download the Updated Script:** Obtain the updated `SpoutSender.cs`.
2. **Locate the Original Script:** Navigate to `KlakSpout-main\Packages\jp.keijiro.klak.spout\Runtime`.
3. **Replace the Original Script:** Copy the updated `SpoutSender.cs` and replace the existing one in the directory.

</details>

<details>
  <summary>SceneTransitionController.cs</summary>

### SceneTransitionController.cs

The `SceneTransitionController` script manages automatic scene transitions in Unity at a constant frame rate of 24 fps. It ensures specified Spout Senders are maintained across these transitions.

**Key Features:**
- Automatic scene transitions with specified durations
- Maintenance of Spout Senders across scenes
- Configurable via the Unity Inspector

**Installation:**
To use the `SceneTransitionController` script:
1. **Download the Script:** Obtain the `SceneTransitionController.cs`.
2. **Add to GameObject:** Attach the script to a GameObject in your scene (e.g., `acrossScene`).
3. **Configure Spout Senders:** Add your Spout Senders to the `Spout Senders` list in the Inspector.
4. **Configure Scene Transitions:** Add your scene transitions to the `Scene Transitions` list in the Inspector, specifying the scene and duration for each.

**Example Usage:**
1. Configure scene transitions in the Unity Inspector:
   - Scene01: 1 second
   - Scene02: 5 seconds
   - Scene03: 10 seconds
   - Scene04: 15 seconds
2. Play the scene in Unity. The script will automatically transition between the configured scenes based on the specified durations at a constant frame rate of 24 fps.

</details>

### Notes:
- Ensure all scenes referenced in the `Scene Transitions` list are added to the build settings.
- The Spout Sender objects must exist in the scenes and have the correct names for the script to find and assign them properly.

By following these instructions, you can integrate and utilize the `SpoutSender` and `SceneTransitionController` scripts effectively in your Unity projects.