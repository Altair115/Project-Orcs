using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Behavior editable for turrets 
public class TurretBehavior : MonoBehaviour {

    //Variables
    public GameObject barrel;

    //Detection
    public Collider[] targets;                      // array of all spotted targets
    static public Collider enemyOne;                // first detected enemy
    public float radius = 12;                       // Base radius editable in editor


    public int damagePerShot = 20;                  // The damage inflicted by each bullet.
    public float fireRate = 0.15f;                  // The time between each shot.
    public float range = 100f;                      // The distance the gun can fire.


    // Bullet/Arrow Based Weapons A.K.A Straight Shooters
    float timer;                                    // A timer to determine when to fire.
    Ray shootRay;                                   // A ray from the gun end forwards.
    RaycastHit shootHit;                            // A raycast hit to get information about what was hit.
    int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.
    ParticleSystem gunParticles;                    // Reference to the particle system.
    LineRenderer gunLine;                           // Reference to the line renderer.
    //AudioSource gunAudio;                         // Reference to the audio source.
    Light gunLight;                                 // Reference to the light component.
    float effectsDisplayTime = 0.2f;                // The proportion of the fireRate that the effects will display for.

    void Awake()
    {
        // Create a layer mask for the Shootable layer.
        shootableMask = LayerMask.GetMask("Enemies");

        // Set up the references.
        gunParticles = barrel.GetComponent<ParticleSystem>();
        gunLine = barrel.GetComponent<LineRenderer>();
        //gunAudio = barrel.GetComponent<AudioSource>();
        gunLight = barrel.GetComponent<Light>();
    }

    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        //seperating layers so not everything is seen by the overlap sphere
        int layerMask = 1 << 8;
        targets = Physics.OverlapSphere(transform.position, radius, layerMask);

        //foreach object in the overlap sphere look at the first One
        foreach (Collider Colls in targets)
        {
            Vector3 Rpos = targets[0].transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(Rpos);
            transform.rotation = rotation;

            //Spawning Projectiles
            if (timer >= fireRate)
                Shoot();

            if (timer >= fireRate * effectsDisplayTime)
            {
                // ... disable the effects.
                DisableEffects();
            }

            enemyOne = targets[0];
        }
        if (enemyOne == null)
            DisableEffects();
    }

    public void DisableEffects()
    {
        // Disable the line renderer and the light.
        gunLine.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot()
    {
        timer = 0f;

        // Play the gun shot audioclip.
        //gunAudio.Play();

        // Enable the light.
        gunLight.enabled = true;

        // Stop the particles from playing if they were, then start the particles.
        gunParticles.Stop();
        gunParticles.Play();

        // Enable the line renderer and set it's first position to be the end of the gun.
        gunLine.enabled = true;
        gunLine.SetPosition(0, barrel.transform.position);

        // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        // Perform the raycast against gameobjects on the shootable layer and if it hits something...
        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            // Try and find an EnemyHealth script on the gameobject hit.
            OrcBehavior enemyHealth = shootHit.collider.GetComponent<OrcBehavior>();

            if (enemyHealth != null)
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            

            // Set the second position of the line renderer to the point the raycast hit.
            gunLine.SetPosition(1, shootHit.point);
        }
        // If the raycast didn't hit anything on the shootable layer...
        else
        {
            // ... set the second position of the line renderer to the fullest extent of the gun's range.
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
        foreach (Collider colls in targets)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, colls.transform.position);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(colls.transform.position, 0.5f);
        }
    }
}
