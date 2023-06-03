using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
	public Vector2 lastMovedVector { get; private set; }
	public bool isMoving { get; private set; }
	public List<Collider2D> maps;
	public Collider2D collider2d;

	private Vector2 movDir;

	//References
	Rigidbody2D rb;
	public CharacterScriptableObject characterData;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		collider2d= GetComponent<Collider2D>();
		maps = new List<Collider2D>();
		lastMovedVector = new Vector2(1, 0f);
		maps.AddRange(FindObjectsOfType<Tilemap>()?.Select(o => o.GetComponent<CompositeCollider2D>()));
		maps.Remove(null);
	}

	// Update is called once per frame
	//private void Update(){}

	private void FixedUpdate()
	{
		if (movDir != Vector2.zero)
		{
			lastMovedVector = movDir;
			isMoving = true;
		}
		else
		{
			isMoving = false;
		}
		rb.velocity = new Vector2(movDir.x * characterData.MoveSpeed, movDir.y * characterData.MoveSpeed);
		var newPos = rb.position + rb.velocity * Time.deltaTime;

		foreach (var map in maps)
		{
			if (!map.OverlapPoint(newPos))
			{
				var inbounds = map.ClosestPoint(newPos);
				var diff = newPos - inbounds;
				rb.velocity = rb.velocity - (diff / Time.deltaTime);
				break;
			}
		}
	}

	public void Move(Vector2 dir)
	{
		movDir = dir;
	}
}
