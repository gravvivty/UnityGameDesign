using System.Collections;
using Project.Inventory;
using UnityEngine;

namespace Project.Scene.SceneControllerLvl1
{
    public class SceneControllerLvl1 : MonoBehaviour
    {
        [SerializeField] private GameObject fireGO;
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject omi;
        [SerializeField] private GameObject omi_noCurtain;
        [SerializeField] private GameObject guard;
        [SerializeField] private GameObject villageDoor;
        [SerializeField] private RuntimeAnimatorController StaffAnim;

        void Start()
        {
            StartCoroutine(wait());
            if (PlayerPrefs.GetInt("isLit", 0) == 1)
            {
                if (villageDoor != null)
                {
                    villageDoor.SetActive(true);
                }
                fireGO.SetActive(true);
                Animator fireAnimator = fireGO.GetComponent<Animator>();
                fireAnimator.Play("FireIdle",0,0f);
                if (omi.activeSelf)
                {
                    Animator omiAnimator = omi.GetComponent<Animator>();
                    Debug.Log("PanicOmi? " + omiAnimator.HasState(0, Animator.StringToHash("PanicOmi")));
                    omiAnimator.Play("PanicOmi", 0, 0f);
                    Debug.Log("Current animation state: " + omiAnimator.GetCurrentAnimatorStateInfo(0).IsName("PanicOmi"));
                }

                if (omi_noCurtain.activeSelf)
                {
                    Animator omiNoCurtainAnimator = omi_noCurtain.GetComponent<Animator>();
                    omiNoCurtainAnimator.Play("PanicOmi",0,0f);
                }
                guard.GetComponent<NPCMovement>().enabled = false;
                Animator guardAnimator = guard.GetComponent<Animator>();
                guardAnimator.Play("FireGuard",0,0f);
                guard.transform.localPosition = new Vector3(-0.6f, 1.6f, 0f);
                guard.GetComponent<SpriteRenderer>().sortingLayerName = "NPC";
            }
        }

        void Update()
        {
            if (InventoryManager.Instance.HasItemWithID(56))
            {
                player.GetComponent<Animator>().runtimeAnimatorController = StaffAnim;
            }
        }

        IEnumerator wait()
        {
            yield return null;
            yield return null;
        }
    }   
}