using UnityEngine;

public class AppSessionReset : MonoBehaviour
{
    void Awake()
    {
        // Clear this only at the beginning of a full game session
        // Add any Prefs that arent supposed to stay between sessions
        PlayerPrefs.DeleteKey("isLit");
    }
}