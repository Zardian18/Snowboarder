using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    [SerializeField]
    private float delay = 1f;
    [SerializeField]
    private ParticleSystem crashEffect;
    [SerializeField]
    private AudioClip crashSFX;
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if (player == null)
        {
            //error
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            Debug.Log("U died");
            crashEffect.Play();
            if (!GetComponent<AudioSource>().isPlaying && player.canMove)
            {
                GetComponent<AudioSource>().PlayOneShot(crashSFX, 0.7f);
            }
            player.canMove = false;
            Invoke("ReloadScene", delay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    
}
