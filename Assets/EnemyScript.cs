using UnityEngine;

/// <summary>
/// Enemy generic behavior
/// </summary>
public class EnemyScript : MonoBehaviour
{
	private bool hasSpawn;
	private moveScript moveScript;
	
	void Awake()
	{
		// Retrieve scripts to disable when not spawn
		moveScript = GetComponent<moveScript>();
	}
	
	// 1 - Disable everything
	void Start()
	{
		hasSpawn = false;
		//disable stuff
		// -- Moving
		moveScript.enabled = false;
	
	}
	
	void Update()
	{
		// 2 - Check if the enemy has spawned.
		if (hasSpawn == false)
		{
			if (GetComponent<Renderer>().IsVisibleFrom(Camera.main))
			{
				Spawn();
			}
		}

	}
	
	// 3 - Activate itself.
	private void Spawn()
	{
		hasSpawn = true;

		// -- Moving
		moveScript.enabled = true;

	}
}