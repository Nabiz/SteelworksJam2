using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinSticksController : MonoBehaviour
{
	[SerializeField] private Entity entity;
	[SerializeField] private Rigidbody rb;
	
	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	public void Move (Vector2 vector2) {
		rb.MovePosition(transform.position + new Vector3(vector2.x, 0f, vector2.y));
	}
	
	public void Rotate (Vector2 vector2) { 
		rb.MoveRotation(Quaternion.Euler(vector2));
	}
	
	public void Fire()
	{
		entity.Fire();
	}
}
