using UnityEngine;

public class PlayerTestClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = InputManager.Player_Mouse_Position;
        screenPoint.z = 10;
        Debug.Log(Camera.main.ScreenToWorldPoint(screenPoint));
    }
}
