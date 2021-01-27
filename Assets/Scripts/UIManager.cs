using UnityEngine;

public class UIManager : MonoBehaviour {
    [SerializeField]
    GameObject slider;

    public void SetSliderActive(bool value) {
        slider.SetActive(value);
    }
}
