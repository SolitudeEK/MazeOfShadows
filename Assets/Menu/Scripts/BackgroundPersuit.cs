using TMPro;
using UnityEngine;

public class BackgroundPersuit : MonoBehaviour
{
    [SerializeField]
    private float _minTime = 2f;
    [SerializeField] 
    private float _maxTime = 10f;
    [SerializeField]
    private float _moveSpeed = 10f;
    [SerializeField]
    private Camera _camera;

    private bool _isMoving = false;
    private Vector3 _targetPosition;
    private Vector3 _screenBottomLeft;
    private Vector3 _screenTopRight;

    private void Start()
    {
        _screenBottomLeft = _camera.ScreenToWorldPoint(new Vector3(0, 0, _camera.nearClipPlane));
        _screenTopRight = _camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _camera.nearClipPlane));
        StartRandomPersuit();
    }

    private void StartRandomPersuit()
    {
        float randomDelay = Random.Range(_minTime, _maxTime);
        Invoke(nameof(MoveAcrossScreen), randomDelay);
    }

    private void Update()
    {
        if (_isMoving)
        {
            Vector3 direction = (_targetPosition - transform.position).normalized;

            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);

            if (direction != Vector3.zero)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }

            if (Vector2.Distance(this.transform.position, _targetPosition) < 0.1f)
            {
                _isMoving = false;
                StartRandomPersuit();
            }
        }
    }

    private void MoveAcrossScreen()
    {
        bool isHorizontal = Random.Range(0, 2) == 0;



        if (isHorizontal)
        {
            float startX = Random.Range(0, 2) == 0 ? _screenBottomLeft.x - 1f : _screenTopRight.x + 1f;
            float targetX = startX > 0 ? _screenBottomLeft.x - 1f : _screenTopRight.x + 1f;
            float randomY = Random.Range(_screenBottomLeft.y, _screenTopRight.y);

            transform.position = new Vector3(startX, randomY);
            _targetPosition = new Vector3(targetX, randomY);
        }
        else
        {
            float startY = Random.Range(0, 2) == 0 ? _screenBottomLeft.y - 1f : _screenTopRight.y + 1f;
            float targetY = startY > 0 ? _screenBottomLeft.y - 1f : _screenTopRight.y + 1f; 
            float randomX = Random.Range(_screenBottomLeft.x, _screenTopRight.x);

            transform.position = new Vector3(randomX, startY);
            _targetPosition = new Vector3(randomX, targetY);
        }

        _isMoving = true;
    }
}
