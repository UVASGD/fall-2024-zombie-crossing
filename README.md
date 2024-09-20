# Zombie Crossing 
[![License: CC BY-NC-SA 4.0](https://img.shields.io/badge/License-CC_BY--NC--SA_4.0-darkgray.svg)](https://creativecommons.org/licenses/by-nc-sa/4.0/)
[![Copyright: Matthew Alexander Brown, 2024](https://img.shields.io/badge/©-Matthew_Brown,_2024-darkgray.svg)](https://www.mushakushi.com/)

## ⚙ Installation 

To install the current version, use:

```bash
git clone https://github.com/UVASGD/fall-2024-zombie-crossing.git
```

If you are specifying a version, append `#{VERSION}` to the end of the git URL.

```bash
git clone https://github.com/UVASGD/fall-2024-zombie-crossing.git#{VERSION}
```

### Creating the Private Submodule
Next, if you do not have access to it, create a private git repository named `fall-2024-zombie-crossing-private` with the following assets installed to the root directory:
- https://assetstore.unity.com/packages/vfx/shaders/fullscreen-camera-effects/pixel-perfect-fog-of-war-229484?srsltid=AfmBOoqcmoO0IvCnGwUgbm3e1Yvu4hGyqLHA_yhsBxQ28GUoQ1keQSbl

If you performed the previous step, run the following command, where `<url>` is the url of the `fall-2024-zombie-crossing-private` git repository:
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

