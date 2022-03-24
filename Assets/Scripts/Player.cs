using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpHight;

    private bool _isJumping = false;
    private float yVelocity;
    private CharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {

        float _horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");

        Vector3 Direction = new Vector3(_horizontalInput, 0, 0);

        Vector3 Velocity = Direction * _speed;

        Velocity.y = yVelocity;

        _characterController.Move(Velocity * Time.deltaTime);
        yVelocity -= _gravity;
    }

    public void JumpButton()
    {
       
        if (_characterController.isGrounded == true)
        {
                _isJumping = true;
                yVelocity = _jumpHight;
        }
        else
        {
            if (_isJumping == true)
            {
                yVelocity = _jumpHight;
                _isJumping = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "End Point")
        {
            int ActiveScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(ActiveScene);
        }
    }
}
