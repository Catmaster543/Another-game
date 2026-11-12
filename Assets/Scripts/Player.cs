using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Scene References")]
    [SerializeField] Transform holdingSpot;
    [SerializeField] StoryManager storyManager;
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] public UIManager uiManager;

    [Header("Settings")]
    [SerializeField] float rayRange;
    [SerializeField] string interactText;

    [Header("Shared References")]
    [SerializeField] GameObject heldObj;
    private GameObject lastObj;
    bool lookingAtObj;

    float timer;
    float rateTimer;
    bool isHoldingObj = false;

    public static Player Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        ReBindReferences();
        //gameStateManager = storyManager.refPlayer.gameStateManager;
        //interactTextObj = storyManager.refPlayer.interactTextObj;
        //misterDialogue = storyManager.refPlayer.misterDialogue;
        //lineObjStage2 = storyManager.refPlayer.lineObjStage2;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ReBindReferences();
    }

    public void ReBindReferences()
    {
        storyManager = GameObject.FindGameObjectWithTag("MainManager").GetComponent<StoryManager>();
        gameStateManager = GameObject.FindGameObjectWithTag("GameStateManager").GetComponent<GameStateManager>();
    }

    void Update()
    {
        if (timer >= 0.1f)
        {
            GameObject obj = ShootRay();
            if (obj != null)
            {
                uiManager.interactTextObj.SetActive(true);
                lookingAtObj = true;
                if (obj != lastObj)
                {
                    if (obj.TryGetComponent<IInteractable>(out var interactable))
                    {
                        uiManager.interactTextObj.SetActive(true);
                        uiManager.UpdateInteractText(interactable.prompt);
                    }
                    else
                    {
                        Debug.LogWarning($"{obj.name} does not have the IInteractible class as its base!");
                    }
                }

                StartCoroutine(HideInteraction());
                lastObj = obj;
            }
            else
            {
                lookingAtObj = false;
            }
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }

        if (rateTimer <= 0.2f)
        {
            rateTimer += Time.deltaTime;
        }
    }

    GameObject ShootRay()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        //Debug.Log("Shot a ray");

        if (Physics.Raycast(ray, out RaycastHit hit, rayRange))
        {
            if (hit.collider.gameObject.tag == "Interactable")
            {
                //Debug.Log($"Hit {hit.collider.gameObject.name}");
                return hit.collider.gameObject;
            }
        }
        //Debug.Log("Nothing hit, or the object is out of range. \n(Have you assigned the \"Interactable\" tag to the object?)");
        return null;
    }

    public void Interact()
    {
        if (rateTimer >= 0.2f)
        {
            rateTimer = 0;
            GameObject obj = ShootRay();
            if (obj != null)
            {
                if (obj.TryGetComponent<IInteractable>(out var interactable))
                {
                    interactable.Interact(this);
                }
                else
                {
                    Debug.LogWarning($"{obj.name} doesn't have the IInteractable class declared!");
                }
            }
        }
    }

    IEnumerator HideInteraction()
    {
        yield return new WaitForSeconds(0.2f);
        if (!lookingAtObj)
        {
            uiManager.interactTextObj.SetActive(false);
        }
    }

    public void PickUpInteraction(GameObject obj)
    {
        if (isHoldingObj == false)
        {
            obj.transform.SetParent(holdingSpot);
            obj.transform.position = holdingSpot.position;
            heldObj = obj;
            isHoldingObj = true;
        }
    }
    
    public void DropInteraction()
    {
        if (isHoldingObj == true)
        { 
            heldObj.transform.SetParent(null);
            heldObj = null;
            isHoldingObj = false;
        }
    }

    public void ConsoleEnterInteraction()
    {
        if (rateTimer >= 0.2f)
        {
            rateTimer = 0;
            gameStateManager.Switch();
        }
    }

    public IEnumerator WaitForLookingAround()
    {
        yield return new WaitForSeconds(15);
        uiManager.misterDialogue.StartDialogue(uiManager.lineObjStage2.lines);
    }
}
