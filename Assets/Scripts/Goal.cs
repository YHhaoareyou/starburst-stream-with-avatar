using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject destroyEffectParticle;
    public GameObject dragonSpawner;
    public AudioClip explosionAudioClip;
    GameObject startTrigger;

    // Start is called before the first frame update
    void Start()
    {
        startTrigger = GameObject.FindGameObjectsWithTag("StartTrigger")[0];
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dragon"))
        {
            // Play destroy sound effect
            AudioSource.PlayClipAtPoint(explosionAudioClip, gameObject.transform.position);

            // Play destroy particle effect
            GameObject destroyEffect = Instantiate(destroyEffectParticle, transform.position, Quaternion.identity);
            Destroy(destroyEffect, 5);

            // Destroy dragons
            GameObject[] dragons = GameObject.FindGameObjectsWithTag("Dragon");
            for (var i = 0; i < dragons.Length; i++)
                Destroy(dragons[i]);
            Destroy(other.gameObject);

            // Stop dragon spawner
            dragonSpawner.GetComponent<DragonSpawner>().Stop();

            // Display start trigger
            startTrigger.SetActive(true);

            // Destroy goal itself
            // Destroy(gameObject);
        }
    }
}
