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
    [SerializeField]
    private AudioClip _stepSound;

    private CharacterInputAction _controls;
    private Vector2 _movementInput;
    private AudioSource _walkAudio;

    public void Lose()
    {
        _controls.Disable();
        _endMenu.SetResults(false);
    }

    public void Win()
    {
        _controls.Disable();
        _endMenu.SetResults(true);
    }

    private void Awake()
    {
        _controls = new CharacterInputAction();

        // Subscribe to movement inputs
        _controls.Movement.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
        _controls.Movement.Move.canceled += _ => Stop();
    }

    private void Start()
    {
        _walkAudio = SoundFXManager.Instance.PlaySoundLoop(_stepSound, this.transform, 0.4f);
        _walkAudio.Stop();
    }

    private void OnEnable()
        => _controls.Enable();

    private void OnDisable()
        => _controls.Disable();

    private void FixedUpdate()
        => _character.velocity = _movementInput;

    private void Move(Vector2 input)
    {
        _movementInput = input * _moveSpeed;

        if (_movementInput.x > 0)
            _characterSprite.eulerAngles = new Vector3(0, 0, -90);
        else if (_movementInput.x < 0)
            _characterSprite.eulerAngles = new Vector3(0, 0, 90);
        else if (_movementInput.y > 0)
            _characterSprite.eulerAngles = Vector3.zero;
        else if (_movementInput.y < 0)
            _characterSprite.eulerAngles = new Vector3(0, 0, 180);

        if (_movementInput != Vector2.zero)
        {
            StartWalkingSound();
            _animator.SetBool("IsMoving", true);
        }
    }

    private void Stop()
    {
        _movementInput = Vector2.zero;

        _animator.SetBool("IsMoving", false);
        StopWalkingSound();
    }

    private void StartWalkingSound()
    {
        if (!_walkAudio.isPlaying)
            _walkAudio.Play();
    }

    private void StopWalkingSound()
    {
        if (_walkAudio.isPlaying)
            _walkAudio.Stop();
    }
}
