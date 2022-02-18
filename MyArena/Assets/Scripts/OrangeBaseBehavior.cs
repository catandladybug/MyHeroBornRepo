using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeBaseBehavior : MonoBehaviour
{
	public bool escorePoint = false;
	public bool hasFlag = false;
	public GameObject flag;
	private BlueFlagBehavior bool_script;
	private void Start()
	{
		bool_script = flag.GetComponent<BlueFlagBehavior>();
	}
	private void Update()
	{
		if (bool_script.hasBlueFlag == true)
		{
			hasFlag = true;
		}
	}

	void OnCollisionEnter(Collision collision)

	{
		if (collision.gameObject.name == "Enemy")
		{
			if (hasFlag == true)
			{
				Debug.Log("The Enemy scored a point!");

				escorePoint = true;

				hasFlag = false;
			}
		}
	}
}
