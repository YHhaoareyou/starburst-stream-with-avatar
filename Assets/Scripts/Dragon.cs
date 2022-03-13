using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dragon : MonoBehaviour
{
    public GameObject destroyEffectParticle;
    public AudioClip destroyAudioClip;
    public AudioClip howlingAudioClip;

    private GameObject goal;
    private float speedOffset;

    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.FindGameObjectsWithTag("Goal")[0];
        speedOffset = 10;
        AudioSource.PlayClipAtPoint(howlingAudioClip, gameObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = Vector3.Normalize(goal.transform.position - transform.position);
        transform.position += moveDir * Time.deltaTime * (speedOffset + DragonSpawner.level);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Sword"))
        {
            // Play destroy sound effect
            AudioSource.PlayClipAtPoint(destroyAudioClip, gameObject.transform.position);

            // Destroy particle effect
            GameObject destroyEffect = Instantiate(destroyEffectParticle, transform.position, Quaternion.identity);
            Destroy(destroyEffect, 3);

            // Score + 10
            DragonSpawner.score += 10;

            // Destroy the dragon
            Destroy(gameObject);
        }
    }
}
