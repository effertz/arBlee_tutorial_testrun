using UnityEngine;

public class LightController : MonoBehaviour
{
    public void SetShadowDirection(float yRotation)
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
    }
}
