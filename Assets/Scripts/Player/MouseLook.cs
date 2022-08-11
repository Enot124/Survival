using UnityEngine;

public class MouseLook : MonoBehaviour
{
   private float _mouseSensitivity = 100f;
   [SerializeField] private Transform _playerBody;
   private float _mouseX;
   private float _mouseY;
   private float _rotationX = 0f;

   private void Start()
   {
      Cursor.lockState = CursorLockMode.Locked;
   }

   private void Update()
   {
      _mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
      _mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

      _rotationX -= _mouseY;
      _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);
      transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
      _playerBody.Rotate(Vector3.up * _mouseX);
   }
}
