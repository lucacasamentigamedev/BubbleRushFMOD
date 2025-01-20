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
        Vector2 screenPoint = InputManager.Player_Mouse_Position;
        Debug.Log(InputManager.Player_Mouse_Position);
    }
}
