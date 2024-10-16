using UnityEngine;

public class MapUiPosition : MonoBehaviour
{
    private const float _offset = 130;

    private void Start()
    {
        var height = Screen.height;
        var width = Screen.width;

        this.transform.localPosition = new Vector3 (
                    (width / 2) - _offset,
                    (-height / 2) + _offset,
                    0);
    }
}
