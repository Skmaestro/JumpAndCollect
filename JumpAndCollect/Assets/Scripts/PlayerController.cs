using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public SimpleInput PlayerInput { get; private set; }

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 1.5f;

    [SerializeField] private float sensitivity = 2f;

    [SerializeField] private Transform cameraPivot;
    [SerializeField] private CanvasGroup pauseMenu;


    private CharacterController _playerController;

    private bool isPaused = false;
    private Vector3 _velocity;
    private float _camPivot_x;

    private void Awake()
    {
        TryGetComponent(out _playerController);
        if (GetComponent<SimpleInput>())
        { 
            PlayerInput = GetComponent<SimpleInput>();
        }
        else 
        { 
            Debug.LogError("No PlayerInput");
        }
    }
    void Start()
    {
        PlayerInput.StripInput();
        PlayerInput.SetCursorMode(false);
    }
    void Update()
    {
        Input();

        Move();
    }
    private void LateUpdate()
    {
        if(!isPaused)
        Look();
    }
    private void Look()
    {
        Vector2 look = PlayerInput.look;

        float mouseX = look.x * sensitivity;
        float mouseY = look.y * sensitivity;

        _camPivot_x -= mouseY;
        _camPivot_x = Mathf.Clamp(_camPivot_x, -80f, 80f);

        cameraPivot.localRotation = Quaternion.Euler(_camPivot_x, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void Move()
    {
        Vector2 input = PlayerInput.move;

        bool grounded = _playerController.isGrounded;
        bool jumpPressed = PlayerInput.jump;

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 horizontalMove = forward * input.y + right * input.x;

        if (isPaused)
        {
            horizontalMove = Vector3.zero;
        }

        horizontalMove *= moveSpeed;

        if (grounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        if (grounded && jumpPressed && !isPaused)
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            PlayerInput.jump = false;
        }

        _velocity.y += gravity * Time.deltaTime;

        Vector3 velocity = horizontalMove;
        velocity.y = _velocity.y;

        _playerController.Move(velocity * Time.deltaTime);
    }



    public void UI_Resume_OnClick()
    {
        SetPause(false);
    }
    public void UI_MainMenu_OnClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    private void SetPause(bool pause)
    {
        isPaused = pause;
        Time.timeScale = isPaused?0:1;
        pauseMenu.gameObject.SetActive(isPaused?true:false);
        pauseMenu.alpha = isPaused?1:0;
        PlayerInput.SetCursorMode(isPaused);
    }



    private void Input()
    {
        if (!PlayerInput) return;
        if(PlayerInput.pause)
        {
            SetPause(!isPaused);
            PlayerInput.pause = false;
        }
        if (isPaused) return;

    }
}
