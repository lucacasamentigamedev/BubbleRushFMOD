using UnityEngine;
using UnityEngine.UI;

public class UIBehavior : MonoBehaviour
{
    [SerializeField] private Button playButton;

    private void Awake() {
        playButton.onClick.AddListener(onPlayButtonClick);
    }

    public void onPlayButtonClick() {
        Debug.Log("UIBehavior - onPlayButtonClick");
    }
}