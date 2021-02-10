using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    Rigidbody projectilePrefab;
    [SerializeField]
    Transform firePoint;
    [SerializeField]
    float fireRate, launchForce;
    [SerializeField]
    ParticleSystem muzzleParticle;

    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate && SkillsClass.lockSkill == false)
        {
            if (Input.GetButton("Fire1"))
            {
                timer = 0f;
                Fire();
            }
        }
    }

    private void Fire()
    {
        Rigidbody projectileInstance = Instantiate(
            projectilePrefab,
            firePoint.transform.position,
            firePoint.transform.rotation);
        projectileInstance.AddForce(projectileInstance.transform.forward * launchForce);
        if (muzzleParticle != null)
            muzzleParticle.Play();
    }
}
