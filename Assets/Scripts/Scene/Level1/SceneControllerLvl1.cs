using Project.Inventory;
using UnityEditor.Animations;
using UnityEngine;

public class SceneControllerLvl1 : MonoBehaviour
{
    [SerializeField] private GameObject fireGO;
    [SerializeField] private GameObject player;
    [SerializeField] private AnimatorController StaffAnim;

    void Start()
    {
        if (PlayerPrefs.GetInt("isLit", 0) == 1)
        {
            fireGO.SetActive(true);
            Animator animator = fireGO.GetComponent<Animator>();
            animator.Play("FireIdle",0,0f);
        }
    }

    void Update()
    {
        if (InventoryManager.Instance.HasItemWithID(56))
        {
            player.GetComponent<Animator>().runtimeAnimatorController = StaffAnim;
        }
    }
}