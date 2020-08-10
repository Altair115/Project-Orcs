using UnityEngine;
using System.Collections;

public class OrcBehavior : MonoBehaviour {

    [Header ("Defaults")]
    Collider coll = null;                              
    public float startingHealth = 100;          // The amount of health the enemy starts the game with.
    public float currentHealth;                 // The current health the enemy has.
    public int panic;                           // When health is equal and or lower, enemies will panic and start to run for the objective
    public float sinkSpeed = 2.5f;              // The speed at which the enemy sinks through the floor when dead.
    public int scoreValue = 10;                 // The amount added to the player's score when the enemy dies.
    public int moneyValue = 50;                 // The amount added to the player's money when the enemy dies.
    public AudioClip deathClip;                 // The sound to play when the enemy dies.
    public UnityEngine.UI.Image healthbar;      // The Enemy healthbar

    [Header ("Anim")]
    Animator anim;                              // Reference to the animator.
    AudioSource enemyAudio;                     // Reference to the audio source.
    ParticleSystem hitParticles;                // Reference to the particle system that plays when the enemy is damaged.
    CapsuleCollider CapsuleCollider;            // Reference to the capsule collider.
    bool isDead;                                // Whether the enemy is dead.
    bool isSinking;                             // Whether the enemy has started sinking through the floor.

    [Header ("Navigation")]
    UnityEngine.AI.NavMeshAgent agent;          // A Reference to the Nav Agent
    public Transform[] waypoints;               // The Array of all destinations
    public Transform current;                   // Current destination
    public int destination = 0;                 // Selected destination

    float runSpeed = 3.0f;                      // Running speed
    float walkSpeed = 1.5f;                     // Walking speed

    [Header ("Dev Controls")]
    public bool control = false;
    public bool run = false;
    public GameObject enemyInfo;

    void Awake()
    {
        // Setting up the references.
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        //enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        CapsuleCollider = GetComponent<CapsuleCollider>();

        // Setting the current health when the enemy first spawns.
        currentHealth = startingHealth;
        agent.speed = walkSpeed;
        anim.SetBool("IsWalking", true);
        agent.SetDestination(waypoints[destination].position);
    }

    void Update()
    {
        coll = GetComponent<Collider>();
        current = waypoints[destination];

        if (control == true)
        {
            if (run == false)
                agent.speed = walkSpeed;
            else
                agent.speed = runSpeed;
        }

        // If the enemy should be sinking...
        if (isSinking)
        {
            // ... move the enemy down by the sinkSpeed per second.
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    
    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        // If the enemy is dead...
        if (isDead)
            // ... no need to take damage so exit the function.
            return;

        // Play the hurt sound effect.
        //enemyAudio.Play();
        currentHealth -= amount;
        healthbar.fillAmount = currentHealth / startingHealth;

        // Set the position of the particle system to where the hit was sustained.
        hitParticles.transform.position = hitPoint;

        // And play the particles.
        hitParticles.Play();

        if (currentHealth <= panic)
        {
            anim.SetBool("IsRunning", true);
            agent.speed = runSpeed;
        }

        if (currentHealth <= 0)
        {
            enemyInfo.SetActive(false);
            agent.enabled = false;
            Death();
        }

    }

    void Death()
    {
        isDead = true;
        run = false;
        CapsuleCollider.isTrigger = true;
        anim.SetTrigger("IsDead");
        CapsuleCollider.enabled = false;

        // Change the audio clip of the audio source to the death clip and play it.
        //enemyAudio.clip = deathClip;
        //enemyAudio.Play();
        StartSinking();
    }


    public void StartSinking()
    {
        // Find the rigidbody component and make it kinematic.
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;

        // Increase the score by the enemy's score value.
        ScoreManager.score += scoreValue;
        ScoreManager.money += moneyValue;

        // After 2 seconds destory the enemy.
        Destroy(gameObject, 2f);
    }


    /*
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Core") 
		{
			agent.speed = 0.0f;
			anim.SetTrigger ("Attack");
			destination ++;
			control = true;
		}
		if (other.gameObject.tag == "Extra") 
		{
			destination ++;
		}
		if (other.gameObject.tag == "Exit") 
		{
			Destroy (gameObject);
		}

        //hit reg Projectile
		if (other.gameObject.tag == "Arrow") 
		{
			Damage = 15;
			Health -= Damage;
			anim.SetTrigger("GotHit");
			Destroy (other.gameObject);
            if (Health <= panic)
            {
                PanicInstinct();
            }
            if (Health <= 0)
            {
                Death();
            }
        }
	}
    */
}