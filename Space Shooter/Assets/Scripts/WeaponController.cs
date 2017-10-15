using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;
    public AudioClip[] clips;

    private AudioSource audioSorce;

	// Use this for initialization
	void Start ()
    {
        audioSorce = GetComponent<AudioSource>();
        InvokeRepeating("Fire", delay, fireRate);
	}

    void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        AudioClip clip = clips[Random.Range(0, clips.Length)];
        audioSorce.clip = clip;
        audioSorce.Play();
    }
}
