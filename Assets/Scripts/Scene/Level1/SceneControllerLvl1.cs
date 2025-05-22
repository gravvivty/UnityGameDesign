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
        [SerializeField] private RuntimeAnimatorController StaffAnim;

        void Start()
        {
            wait();
            if (PlayerPrefs.GetInt("isLit", 0) == 1)
            {
                fireGO.SetActive(true);
                Animator fireAnimator = fireGO.GetComponent<Animator>();
                fireAnimator.Play("FireIdle",0,0f);
                if (omi.activeSelf)
                {
                    Animator omiAnimator = omi.GetComponent<Animator>();
                    omiAnimator.SetBool("Panic", true);
                    omiAnimator.Play("PanicOmi",0,0f);
                }

                if (omi_noCurtain.activeSelf)
                {
                    Animator omiNoCurtainAnimator = omi_noCurtain.GetComponent<Animator>();
                    omiNoCurtainAnimator.SetBool("Panic", true);
                    omiNoCurtainAnimator.Play("PanicOmi",0,0f);
                }
                guard.GetComponent<NPCMovement>().enabled = false;
                Animator guardAnimator = guard.GetComponent<Animator>();
                guardAnimator.Play("FireGuard",0,0f);
                guard.transform.localPosition = new Vector3(-0.6f, 1.6f, 0f);
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
        }
    }   
}