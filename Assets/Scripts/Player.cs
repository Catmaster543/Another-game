using System.Collections;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Scene References")]
    [SerializeField] GameObject interactTextObj;

    [Header("Settings")]
    [SerializeField] float rayRange;
    [SerializeField] string interactText;

    private GameObject lastObj;
    bool lookingAtObj;

    float timer;
    float rateTimer;
    void Start()
    {

    }

    void Update()
    {
        if (timer >= 0.1f)
        {
            GameObject obj = ShootRay();
            if (obj != null)
            {
                interactTextObj.SetActive(true);
                lookingAtObj = true;
                if (obj != lastObj)
                {
                    if (obj.TryGetComponent<IInteractable>(out var interactable))
                    {
                        interactTextObj.GetComponent<TextMeshProUGUI>().text = interactable.prompt;
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
            interactTextObj.SetActive(false);
        }
    }
}
