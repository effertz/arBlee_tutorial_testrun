using UnityEngine;

public class UIManager : MonoBehaviour {
    [SerializeField]
    GameObject slider;
    [SerializeField]
    GameObject toggle;

    public void SetSliderActive(bool value) {
        slider.SetActive(value);
    }

    public void SetToggleActive(bool value) {
        toggle.SetActive(value);
    }
}
