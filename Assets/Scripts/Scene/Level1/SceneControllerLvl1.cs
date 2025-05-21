using UnityEngine;

public class SceneControllerLvl1 : MonoBehaviour
{
    [SerializeField] private GameObject fireGO;

    void Start()
    {
        if (PlayerPrefs.GetInt("isLit", 0) == 1)
        {
            fireGO.SetActive(true);
            Animator animator = fireGO.GetComponent<Animator>();
            animator.Play("FireIdle",0,0f);
        }
    }
}