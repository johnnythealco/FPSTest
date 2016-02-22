using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour 
{
	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float lookSensitivity = 5f;

	private PlayerMotor motor;

	void Start()
	{
		motor = GetComponent<PlayerMotor> ();
	}

	void Update()
	{
		// Calculate Movement Velocity as 3D Vector
		float _xMov = Input.GetAxisRaw("Horizontal");
		float _zMov = Input.GetAxisRaw ("Vertical");

		//Left Right Movement
		Vector3 _movHorizontal = transform.right * _xMov;
		//Forwards Backwards Movement
		Vector3 _movVertical = transform.forward * _zMov;

		//Combined Movement
		Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

		//Apply Movement
		motor.Move(_velocity);

		//Calculate Rotation as a 3D Vector (Truning around)
		float _yRot = Input.GetAxisRaw("Mouse X");
	

		Vector3 _rotation = new Vector3 (0f, _yRot, 0f) * lookSensitivity;


		motor.Rotate (_rotation);

		//Calculate Camera Rotation as a 3D Vector (Truning around)
		float _xRot = Input.GetAxisRaw("Mouse Y");


		Vector3 _cameraRotation = new Vector3 (_xRot, 0f, 0f) * lookSensitivity;


		motor.RotateCamera (_cameraRotation);

	}


}
