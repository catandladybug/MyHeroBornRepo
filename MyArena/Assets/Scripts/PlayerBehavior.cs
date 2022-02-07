using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
	//1
	public float moveSpeed = 10f;
	public float rotateSpeed = 75f;
	
	//2
	private float vInput;
	private float hInput;
	
	//1b
	private Rigidbody _rb;
	
	//2b
	void Start ()
	{
		//3b
		_rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
    void Update()
    {
        //3
		vInput = Input.GetAxis("Vertical") * moveSpeed;
		
		//4
		hInput = Input.GetAxis("Horizontal") * rotateSpeed;
		
		/* 4
		//5
		this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
		
		//6
		this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);
		*/
	
    }
	
	void FixedUpdate()
	{
		Vector3 rotation = Vector3.up * hInput;
		
		Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
		
		_rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);
		
		_rb.MoveRotation(_rb.rotation * angleRot);
	}
}
