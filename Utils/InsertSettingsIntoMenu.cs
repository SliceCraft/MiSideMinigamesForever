using UnityEngine;

namespace MinigamesForever.Utils;

public class InsertSettingsIntoMenu
{
    public static void Insert()
    {
        Menu menu = Object.FindObjectOfType<Menu>(true);
        if (menu == null || menu.gameObject == null)
        {
            Plugin.Log.LogInfo("No menu found, unable to insert settings");
            return;
        }

        GameObject menuObject = GetMenuObject(menu.gameObject);
        if (menuObject == null)
        {
            Plugin.Log.LogInfo("No menu object found, unable to insert settings");
            return;            
        }
        
        GameObject loadObject = GetLoadObject(menuObject.gameObject);
        if (loadObject == null)
        {
            Plugin.Log.LogInfo("No load object found, unable to insert settings");
            return;            
        }
        
        GameObject backObject = GetBackObject(loadObject.gameObject);
        if (backObject == null)
        {
            Plugin.Log.LogInfo("No back object found, unable to insert settings");
            return;            
        }

        GameObject minigamesObject = Object.Instantiate(backObject, loadObject.transform, true);
        Vector3 position = minigamesObject.transform.position;
        position.y -= 0.151f;
        minigamesObject.transform.position = position;

        GameObject minigamesTextObject = GetTextObject(minigamesObject);
        minigamesTextObject.GetComponent<UnityEngine.UI.Text>().text = "MINIGAMES";
    }

    private static GameObject GetMenuObject(GameObject menu)
    {
        for (int i = 0; i < menu.transform.childCount; i++)
        {
            GameObject child = menu.transform.GetChild(i).gameObject;
            if (child.name.Equals("Canvas"))
            {
                return GetMenuObject(child);
            }
            
            if (child.name.Equals("FrameMenu"))
            {
                return child;
            }
        }
        return null;
    }
    
    private static GameObject GetLoadObject(GameObject menu)
    {
        for (int i = 0; i < menu.transform.childCount; i++)
        {
            GameObject child = menu.transform.GetChild(i).gameObject;
            if (child.name.Equals("Location Load"))
            {
                return child;
            }
        }
        return null;
    }
    
    private static GameObject GetBackObject(GameObject menu)
    {
        for (int i = 0; i < menu.transform.childCount; i++)
        {
            GameObject child = menu.transform.GetChild(i).gameObject;
            if (child.name.Equals("Button Back"))
            {
                return child;
            }
        }
        return null;
    }
    
    private static GameObject GetTextObject(GameObject menu)
    {
        for (int i = 0; i < menu.transform.childCount; i++)
        {
            GameObject child = menu.transform.GetChild(i).gameObject;
            if (child.name.Equals("Text"))
            {
                return child;
            }
        }
        return null;
    }
}