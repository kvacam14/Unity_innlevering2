using UnityEngine;


/// Handle hitpoints and damages

public class HealthScript : MonoBehaviour
{

	/// Total hitpoints

	public int hp = 1;
	

	/// Enemy or player?

	public bool isEnemy = true;
	

	/// Inflicts damage and check if the object should be destroyed

	/// <param name="damageCount"></param>
	public void Damage(int damageCount)
	{
		hp -= damageCount;
		
		if (hp <= 0)
		{
			// Dead! play deathanimation
			Destroy(gameObject, 1);//destroys gameobject after 1 second
		}
	}
}