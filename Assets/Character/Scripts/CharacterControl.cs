using UnityEngine;
using Character;

public class CharacterControl : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5;
    [SerializeField]
    private Rigidbody2D _character;
    private CharacterInputAction _controls;
    private Vector2 _movementInput;
    private void Awake()
    {
        _controls = new CharacterInputAction();

        _controls.Movement.Up.performed += _ => _movementInput.y = _moveSpeed;
        _controls.Movement.Down.performed += _ => _movementInput.y = -_moveSpeed;
        _controls.Movement.Right.performed += _ => _movementInput.x = _moveSpeed;
        _controls.Movement.Left.performed += _ => _movementInput.x = -_moveSpeed;

        _controls.Movement.Up.canceled += _ => _movementInput.y = 0;
        _controls.Movement.Down.canceled += _ => _movementInput.y = 0;
        _controls.Movement.Right.canceled += _ => _movementInput.x = 0;
        _controls.Movement.Left.canceled += _ => _movementInput.x = 0;
    }

    private void OnEnable()
        => _controls.Enable();

    private void OnDisable()
        => _controls.Disable();

    private void Update()
    {
        // Apply movement
        //Vector3 move = new Vector3(_movementInput.x, _movementInput.y, 0) * _moveSpeed * Time.deltaTime;
        //transform.Translate(move);
        _character.velocity = _movementInput;
    }
}
