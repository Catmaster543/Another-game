using System.Collections;
using TMPro;
using UnityEngine;

public class Bin : MonoBehaviour, IInteractable
{
    public UIManager uiManager;

    public GameObject consoleDevice;
    
    Animator binAnim;

    int marblesIn = 0;
    void Start()
    {
        binAnim = gameObject.GetComponent<Animator>();
    }
    #region Interacteable stuff
    public string prompt => "Interact with the bin";
    public void Interact(Player player)
    {
        if (player.heldObj != null)
        {
            if (player.heldObj.TryGetComponent<MarbleInteractable>(out MarbleInteractable marble) == true)
            {
                marble.transform.parent = gameObject.transform;
                marble.transform.position = gameObject.transform.position;
                marble.transform.position = new Vector3(marble.transform.position.x + Random.Range(0, 0.1f), marble.transform.position.y, marble.transform.position.z + Random.Range(0, 0.1f));
                marble.rb.isKinematic = false;
                marble.tag = "Untagged";
                marblesIn++;
                player.heldObj = null;
                player.isHoldingObj = false;
            }
        }
        else
        {
            StartCoroutine(BinInterract());
        }
    }
    public int stageNeeded => 0;
    #endregion
    IEnumerator BinInterract()
    {
        binAnim.SetTrigger("Out");
        yield return null;
    }

    void Update()
    {
        if (marblesIn >= 13)
        {
            Instantiate(consoleDevice,transform.position, Quaternion.identity);
            GameObject.FindGameObjectWithTag("MainManager").GetComponent<StoryManager>().Progress();
            Destroy(gameObject);
        }
    }
}

//I really don't know what you expected (godaym it works)