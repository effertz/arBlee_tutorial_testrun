using UnityEngine;

public class VisibilityController : MonoBehaviour {
    [SerializeField]
    UIManager uiManager;

    private void OnEnable() {
        uiManager.SetSliderActive(true);
    }

    private void OnDisable() {
        uiManager.SetSliderActive(false);
    }
}
