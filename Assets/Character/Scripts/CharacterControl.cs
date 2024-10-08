using UnityEngine;
using Character;

public class CharacterControl : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5;
    [SerializeField]
    private Rigidbody2D _character;
    [SerializeField]
    private Transform _characterSprite;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private EndMenuControl _endMenu;

    private CharacterInputAction _controls;
    private Vector2 _movementInput;

    public void Lose()
    {
        _controls.Disable();
        //Add animation trigger
        _endMenu.SetResults(false);
    }

    public void Win()
    {
        _controls.Disable();
        //Add animation trigger
        _endMenu.SetResults(true);
    }

    private void Awake()
    {
        _controls = new CharacterInputAction();

        _controls.Movement.Up.performed += _ => MoveUp();
        _controls.Movement.Down.performed += _ => MoveDown();
        _controls.Movement.Right.performed += _ => MoveRight();
        _controls.Movement.Left.performed += _ => MoveLeft();

        _controls.Movement.Up.canceled += _ => Stop(true);
        _controls.Movement.Down.canceled += _ => Stop(true);
        _controls.Movement.Right.canceled += _ => Stop(false);
        _controls.Movement.Left.canceled += _ => Stop(false);
    }

    private void OnEnable()
        => _controls.Enable();

    private void OnDisable()
        => _controls.Disable();

    private void FixedUpdate()
        => _character.velocity = _movementInput;

    private void MoveUp()
    {
        _movementInput.y = _moveSpeed;
        _characterSprite.eulerAngles = Vector3.zero;
        _animator.SetBool("IsMoving", true);
    }

    private void MoveDown() {
        _movementInput.y = -_moveSpeed;
        _characterSprite.eulerAngles = new Vector3(0, 0, 180);
        _animator.SetBool("IsMoving", true);
    }

    private void MoveLeft()
    { 
        _movementInput.x = -_moveSpeed;
        _characterSprite.eulerAngles = new Vector3(0, 0, 90);
        _animator.SetBool("IsMoving", true);
    }

    private void MoveRight()
    { 
        _movementInput.x = _moveSpeed;
        _characterSprite.eulerAngles = new Vector3(0, 0, -90);
        _animator.SetBool("IsMoving", true);
    }

    private void Stop(bool IsVertical)
    {
        if (IsVertical)
            _movementInput.y = 0;
        else 
            _movementInput.x = 0;

        _animator.SetBool("IsMoving", false);
    }
}
