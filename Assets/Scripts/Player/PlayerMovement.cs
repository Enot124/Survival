using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private CharacterController _controller;
   [SerializeField] private Transform _groundCheck;
   [SerializeField] private LayerMask _groundMask;
   private float _moveX;
   private float _moveZ;
   private Vector3 _movePosition;
   private float _gravity = -50f;
   private float _groundDistance = 0.4f;
   private float _jumpHeight = 2f;
   private float _speed = 10f;
   private Vector3 _velocity;
   private bool _isGrounded;
   private bool isMove = true;

   private void Start()
   {
      GlobalEventManager.PlayerDie += StopMove;
   }

   private void OnDisable()
   {
      GlobalEventManager.PlayerDie -= StopMove;
   }

   private void Update()
   {
      if (isMove)
      {
         _moveX = Input.GetAxis("Horizontal");
         _moveZ = Input.GetAxis("Vertical");
         if ((_moveX != 0) || (_moveZ != 0))
            Move();

         CheckGround();
         if (Input.GetButtonDown("Jump") && _isGrounded)
         {
            Jump();
         }
      }
   }

   private void Move()
   {
      _movePosition = transform.right * _moveX + transform.forward * _moveZ;
      _controller.Move(_movePosition * _speed * Time.deltaTime);
   }

   private void CheckGround()
   {
      _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);
      if (_isGrounded && _velocity.y < 0)
         _velocity.y = 0;
      else
      {
         _velocity.y += _gravity * Time.deltaTime;
         _controller.Move(_velocity * Time.deltaTime);
      }
   }

   private void Jump()
   {
      _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
   }

   private void StopMove()
   {
      isMove = false;
   }
}

