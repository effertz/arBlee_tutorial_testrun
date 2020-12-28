using UnityEngine;

public class VisibilityController : MonoBehaviour {
    [SerializeField]
    UIManager uiManager;

    private void OnEnable() {
        uiManager.SetSliderActive(true);
        uiManager.SetToggleActive(true);
    }

    private void OnDisable() {
        uiManager.SetSliderActive(false);
        uiManager.SetToggleActive(false);
    }
}
