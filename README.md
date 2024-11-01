# Zombie Crossing 
[![License: CC BY-NC-SA 4.0](https://img.shields.io/badge/License-CC_BY--NC--SA_4.0-darkgray.svg)](https://creativecommons.org/licenses/by-nc-sa/4.0/)
[![Copyright: Matthew Alexander Brown, 2024](https://img.shields.io/badge/©-Matthew_Brown,_2024-darkgray.svg)](https://www.mushakushi.com/)

## ⚙ Installation 
Install Unity [6000.0.23f1](https://unity.com/releases/editor/whats-new/6000.0.23). 

Then, to install the current version, use:
```bash
git clone https://github.com/UVASGD/fall-2024-zombie-crossing.git
```

Of, if you are specifying a version, append `#{VERSION}` to the end of the git URL.
```bash
git clone https://github.com/UVASGD/fall-2024-zombie-crossing.git#{VERSION}
```

### Creating the Private Submodule
Next, if you do not have access to it, create a private git repository named `fall-2024-zombie-crossing-private` with the following assets installed to the root directory:
- https://assetstore.unity.com/packages/vfx/shaders/fullscreen-camera-effects/pixel-perfect-fog-of-war-229484
- https://assetstore.unity.com/packages/3d/environments/fantasy/idyllic-fantasy-nature-260042
- https://assetstore.unity.com/packages/3d/environments/fantasy-landscape-103573

>[!Warning]
> Some of the above packages may not be immediately compatible with URP, so you must select `Edit/Rendering/Materials/Convert Selected Built-in Materials to URP`
> with the full contents of the following directories selected: 
> * FantasyEnvironments/Environments/Materials
> * FantasyEnvironments/Environments/Town/Materials

If you needed to perform these steps, run the following command, where `<url>` is the url of the `fall-2024-zombie-crossing-private` git repository:
```bash
git submodule set-url -- Assets/fall-2024-zombie-crossing-private <url>
```
>[!NOTE]
>This is the only submodule used by the project

### Updating the submodule
To install the contents of the submodule for the first time, use:
```bash
git submodule update --init --recursive --remote
```

