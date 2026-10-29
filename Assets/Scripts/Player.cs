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
                    interactTextObj.GetComponent<TextMeshProUGUI>().text = $"{interactText} {obj.name}";
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

    IEnumerator HideInteraction()
    {
        yield return new WaitForSeconds(0.2f);
        if (!lookingAtObj)
        {
            interactTextObj.SetActive(false);
        }
    }
}
