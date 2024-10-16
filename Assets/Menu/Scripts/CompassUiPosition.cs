using UnityEngine;

public class CompassUiPosition : MonoBehaviour
{
    private const float _sizeMultiplayer = 1.2f;
    private const float _yPostion = -3.5f;

    private void Start()
    {
        float aspectRatio = (float)Screen.width / Screen.height;

        transform.localPosition = new Vector3(aspectRatio*_sizeMultiplayer* _yPostion, _yPostion, 1);
    }
}
