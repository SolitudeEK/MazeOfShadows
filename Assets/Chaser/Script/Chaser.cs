using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    [SerializeField]
    private float _lifetime = 10f;
    [SerializeField]
    private Transform _character;
    [SerializeField]
    private float _moveSpeed = 3.9f;

    private List<Vector2Int> _path;
    private Vector2Int _currentTarget;
    private int _currentPathIndex = 0;

    private void OnEnable()
    {
        StartLifetime();
        UpdatePath();
    }

    private void Update()
    {
        if (_path != null && _currentPathIndex < _path.Count)
            MoveTowardsTarget();
    }

    private void MoveTowardsTarget()
    {
        Vector3 targetPosition = new Vector3(_currentTarget.x * 2, _currentTarget.y * 2, 0);
        Vector3 direction = (targetPosition - transform.position).normalized;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            _currentPathIndex++;
            if (_currentPathIndex < _path.Count)
                _currentTarget = _path[_currentPathIndex];
            else
                UpdatePath();
        }
    }

    private void UpdatePath()
    {
        Vector2Int startPos = new Vector2Int(Mathf.RoundToInt(transform.position.x / 2), Mathf.RoundToInt(transform.position.y / 2));
        Vector2Int endPos = new Vector2Int(Mathf.RoundToInt(_character.position.x / 2), Mathf.RoundToInt(_character.position.y / 2));

        _path = PathFinder.FindPath(startPos, endPos);

        if (_path != null && _path.Count > 0)
        {
            _currentPathIndex = 0;
            _currentTarget = _path[_currentPathIndex];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CharacterControl>().Lose();
        }
    }


    private void StartLifetime()
    {
        StartCoroutine(DelayedDestroy(_lifetime));

        IEnumerator DelayedDestroy(float delay)
        {
            yield return new WaitForSeconds(delay);
            Destroy(this.gameObject);
        }
    }
}
