using UnityEngine;

public class Compass : MonoBehaviour
{
    [SerializeField]
    private Transform _arrowTransform;
    [SerializeField]
    private MazeGenerator _generator;

    private Vector3 _finish;

    private void Start()
    {
        var finish = _generator.GetFinish;
        _finish = new Vector3(finish.X * 2, finish.Y * 2, 0);
    }

    private void Update()
    {
         Vector2 directionToFinish = _finish - this.transform.position;
        _arrowTransform.eulerAngles = new Vector3(0, 0, -Vector2.SignedAngle(directionToFinish, Vector2.up));
    }
}
