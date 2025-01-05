# MiSide Minigames Forever
Play the minigames implemented in MiSide from the main menu!

## Early access
This mod is still in development, not all features and minigames are implemented yet.  
Feedback and contributions are appreciated!

# Features
Currently you can play a few minigames by pressing the keybinds mentioned below.  
When exiting these minigames you are returned back to the main menu.  
In the future I'd like there to be a menu in the main menu instead of having to use keybinds to load the games.

## Toggles
<table>
  <tr>
    <th>Keybind</th>
    <th>Minigame</th>
    <th>Note</th>
  </tr>
  <tr>
    <td>Alt + M</td>
    <td>Hetoor</td>
    <td>None</td>
  </tr>
  <tr>
    <td>Alt + N</td>
    <td>Spacecar</td>
    <td>To play this game one of the chapters has to be loaded. I tried to prevent any side effects from occuring by using this approach but I might have missed some things. Please make an issue if you find any.</td>
  </tr>
</table> 

# Installing
Before you can install this mod you need to have BepInEx with Il2Cpp support installed, this can be downloaded on their [Bleeding Edge download page](https://builds.bepinex.dev/projects/bepinex_be).  
You then need to extract the zip file to your game directory.  
Then you can download the most recent version on github through the releases section and put this dll file in the plugin folder.  
You can find this folder at `MiSide/BepInEx/plugins`.

# Contributing
To compile this project locally you need to drop all `interop` dlls in the Dependencies folder.  
Feel free to make changes and make a PR to merge these changes into the project.  
I can't guarantee every change will make it in though, complete refactors or additions not meant for this mod will be rejected for example.