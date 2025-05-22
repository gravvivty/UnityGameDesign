using Project.Inventory;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public string sceneToLoad;

    void Start()
    {
        var persistentObjects = Object.FindObjectsByType<InventoryManager>(FindObjectsSortMode.None);
        
        foreach (var obj in persistentObjects)
        {
            if (obj.gameObject.name == "InventoryManager")
            {
                Destroy(obj.gameObject);
            }
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
