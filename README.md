
# Easy UI Nav - Make Unity UI Navigation Easier

###### EasyUINav is a program made with allowing for easier UI navigation. Gone are the days of spending time working on and configuring complex navigation setups manually. With EasyUINav, streamline your Unity UI navigation process effortlessly. Simply create a new navigation element by clicking the plus sign, then drag and drop a button to the "User Chosen" button slot, and assign the appropriate game objects to the enable and disable lists. Need to start fresh? Just click "reinitialize" to reset the lists and start anew. Save time and effort with EasyUINav, your go-to solution for simplified UI navigation in Unity.


Contains; Unity Package with all code and a dirt simple sample scene
###### Note, this is all HUMAN generated, dapper language /= GPT

![UINav Demo](https://github.com/Walker-Industries-RnD/Easy_UI_Nav/blob/main/UINav3.gif)



[![Support me on Patreon](https://img.shields.io/endpoint.svg?url=https%3A%2F%2Fshieldsio-patreon.vercel.app%2Fapi%3Fusername%3Dwalkerdev%26type%3Dpledges&style=for-the-badge)](https://patreon.com/walkerdev)



## Features

- Effortless UI Navigation: EasyUINav simplifies Unity UI navigation, eliminating the need for manual configuration.

- Intuitive Setup: Create navigation elements effortlessly by clicking the plus sign and dragging buttons to the designated slots.

- Customization Made Easy: Easily set UI actions with a simple drag and drop system.

- Reset with Ease: Need to start over? Click "reinitialize" to reset lists and begin anew, saving time and streamlining your workflow.

- Easily view all functions within a script and call void ones by simply clicking a boolean (Coming in v1.2, a singular error stops me currently)

- To use the sample scene, please ensure TMP is installed! Upon clicking the scene with any new Unity version you should automatically see the TMP download window open!
<br />

![Easy UI Nav](https://github.com/Walker-Industries-RnD/Easy_UI_Nav/blob/main/EasyUINav.png)


## How to Use EasyUINav for Simplified UI Navigation in Unity

![Easy UI Nav Expanded](https://github.com/Walker-Industries-RnD/Easy_UI_Nav/blob/main/EasyUINav2.png)


### Installation:
1. Download EasyUINav from the Unity Asset Store (Soon) or import it into your project from a package.
2. Once imported, you'll find EasyUINav accessible from the Unity editor as a component!
### Creating a New Navigation Element:
3. Open EasyUINav in the Unity editor.
4. Click the plus sign (+) to create a new navigation element.
### Assigning Buttons:
5. Drag and drop a UI button from your scene hierarchy into the "User Chosen" button slot in the EasyUINav interface.
### Configuring Navigation Paths:
6. Identify the game objects that should be enabled or disabled when navigating between UI elements.
7. Drag these game objects into the corresponding "Enable" and "Disable" lists in the EasyUINav interface.

#### If you need to start over or make changes, simply click the "reinitialize" button to reset the lists and begin fresh.

### Testing and Iteration:
Playtest your UI navigation in the Unity editor to ensure everything works as expected.
Iterate on your navigation setup as needed, making adjustments for optimal user experience.


## More Technical Explanation

#### Easy UI Nav

This script, `Easy_UI_Nav`, is designed to simplify UI navigation in Unity. Let's break down its components:

1. **Public Variables**:
   - `NavName`: A string variable to hold the name of the navigation.
   - `navs`: A list of `UINavigator` objects. Each `UINavigator` represents a UI navigation setup.

2. **UINavigator Class**:
   - `UserChosenButton`: A reference to the button that triggers the navigation.
   - `ItemsToEnable`: A list of game objects to enable when the button is clicked.
   - `ItemsToDisable`: A list of game objects to disable when the button is clicked.
   - The constructor initializes these properties.

3. **Awake Method**:
   - Iterates through each `UINavigator` in the `navs` list.
   - Adds listeners to the `UserChosenButton` of each `UINavigator`.
   - When the button is clicked, it enables objects in `ItemsToEnable` and disables objects in `ItemsToDisable`.

4. **EnableAll and DisableAll Methods**:
   - Enable or disable all game objects in the provided lists.

5. **RunMethods Method**:
   - Not currently used in the provided script.

6. **ObservedList Class**:
   - A generic list implementation with additional events for tracking changes.
   - It provides functionality similar to `ObservableCollection` in C#. Becomes more important in 1.2.

7. **Custom Editor (`Easy_UI_NavEditor`)**:
   - Extends the Unity `Editor` class to customize the appearance of `Easy_UI_Nav` in the Unity Inspector.
   - Provides a button to clear the lists of `ItemsToEnable` and `ItemsToDisable` for each `UINavigator` when clicked.

8. **KeyValue Class**:
   - A generic class to hold key-value pairs, used for serialization purposes.

Overall, this script facilitates UI navigation by allowing you to define button-click behaviors that enable/disable specific UI elements associated with each button. The ObservedList class adds functionality to track changes to lists, and the custom editor provides a convenient way to manage UI navigation setups within the Unity Editor.         



## License

[Apache 2](https://www.apache.org/licenses/LICENSE-2.0)


