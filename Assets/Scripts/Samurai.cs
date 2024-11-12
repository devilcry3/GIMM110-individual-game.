using System.Collections;
using UnityEngine;

public class Samurai : MonoBehaviour
{
	// Regions help to visually organize your code into sections.
	#region Variables
	// Headers are like titles for the Unity Inspector.
	[Header("Samurai Settings")]
	// SerializeField allows you to see private variables in the inspector while keeping them private
	[SerializeField] float speed;
	[SerializeField] float attackRange = 0.5f;
	[SerializeField] LayerMask enemyLayer;
	[SerializeField] int attackDamage = 50;
	FillMeter coolDown;

	/* In C# if you do not specify a variable modifier (i.e. public, private, protected), it defaults to private
	The private variable modifier stops other scripts from accessing those variables */
	Animator anim;
	GameObject enemy;
	Rigidbody2D characterRB;
	#endregion // Marks the end of the region

	#region Unity Methods
	// Start is called before the first frame update
	private void Start()
	{
		// Gets the animator and rigidbody components from the object
		anim = GetComponent<Animator>();
		characterRB = GetComponent<Rigidbody2D>();
        coolDown = FindObjectOfType<FillMeter>(); // coolDown being FillMeter's local name within Samurai
    }

	// FixedUpdate is called at a fixed interval. Good for physics calculations
	private void FixedUpdate()
	{
		AttackEnemy(); // Calls the AttackEnemy method
		Move(); // Calls the Move method
	}
	#endregion

	#region Custom Methods
	/// <summary>
	/// Attacks the enemy if they are in range
	/// </summary>
	private void AttackEnemy()
	{
		// Casts a ray to check if an enemy is in range, utilizes the player or enemy layer to determine if a unit or base is nearby
		RaycastHit2D enemyCheck = Physics2D.Raycast(transform.position, transform.right, attackRange, enemyLayer);

		// If there is no enemy in range, set the Attack parameter to false and exit the method
		if (enemyCheck.collider == null)
		{
			anim.SetBool("Attack", false);
			return;
		}

		// If there is an enemy in range, set the Attack parameter to true and set the enemy object
		anim.SetBool("Attack", true);
		enemy = enemyCheck.collider.gameObject;
	}

   

    /// <summary>
    /// Moves the character forward
    /// </summary>
    private void Move()
	{
		// If the character is not attacking, move the character forward
		// Else make the character stand still
		if (!anim.GetBool("Attack"))
		{
				
			
			if (coolDown.goGo == true && gameObject.CompareTag("Player"))
			{
                characterRB.velocity = new Vector2(transform.forward.z * speed, characterRB.velocity.y)*2;
                // when the goGo bullein in the FillMeter class is set to true it double's allie Samurai movement
            }
           else
			{
            characterRB.velocity = new Vector2(transform.forward.z * speed, characterRB.velocity.y);
			}
        }
		else
		{
			characterRB.velocity = Vector2.zero;
		}
	}

	/// <summary>
	/// Deals damage to the enemy
	/// </summary>
	public void Hit()
	{
		// If the enemy object is null, exit the method
		if (enemy == null)
		{
			return;
		}

		enemy.TryGetComponent(out Health enemyHealth); // Tries to get the Health component from the enemy object

		// If the enemy does not have a Health script, log a warning and exit the method
		if (enemyHealth == null)
		{
			Debug.LogWarning("This collider does not have a health script");
			return;
		}

		enemyHealth.TakeDamage(attackDamage); // Calls the TakeDamage method from the Health script
	}

	/// <summary>
	/// Draws a gizmo to show the attack range
	/// </summary>
	private void OnDrawGizmos() // Gizmos create a visual element, but it can only be viewed in the scene viewwer but not in the builder or any builds
	{
		// If the animator is null, exit the method
		if (anim == null)
			return;

		Gizmos.color = anim.GetBool("Attack") ? Color.green : Color.red; // Sets the gizmo color based on the Attack parameter

		Gizmos.DrawRay(transform.position, transform.right * attackRange); // Draws a ray in the direction of the attack range
	}
	#endregion
}