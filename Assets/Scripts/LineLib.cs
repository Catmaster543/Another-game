using UnityEngine;

public class LineLib : MonoBehaviour
{
    public LineObj linesObjStage2;
    void Awake()
    {
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().RegisterLineLib(this);
    }
}
