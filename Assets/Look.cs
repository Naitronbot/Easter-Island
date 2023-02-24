using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
	
	public float sens = 100f;
	public Transform player;
	public bool keyboardLook = true;
	float lookY = 0f;
	float currentLookY;
	
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
		if (!keyboardLook) {
			float mX = sens * Input.GetAxis("Mouse X") * Time.deltaTime;
			float mY = sens * Input.GetAxis("Mouse Y") * Time.deltaTime;

			lookY -= mY;
			if (lookY > 90f) {
				lookY = 90f;
			} else if (lookY < -90f) {
				lookY = -90f;
			}
			player.Rotate(Vector3.up * mX);
			transform.localRotation = Quaternion.Euler(lookY, 0f, 0f);
		} else {
			currentLookY -= Input.GetAxis("LookY");
			if (currentLookY > 90f) {
				currentLookY = 90f;
			} else if (currentLookY < -90f) {
				currentLookY = -90f;
			}
			player.Rotate(Vector3.up * Input.GetAxis("LookX"));
			transform.localRotation = Quaternion.Euler(currentLookY, 0f, 0f);
		}
    }
}
