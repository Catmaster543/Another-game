using UnityEngine;
using UnityEngine.UI;

public class ConsoleDeviceController : MonoBehaviour
{
    public GameObject consoleCanvas;
    public Image displayImage;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void TurnOffScreen()
    {
        consoleCanvas.SetActive(false);
    }

    public void UpdateDisplay(Sprite newImage)
    {

    }
}
