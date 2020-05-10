using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 3;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip damagedBaseSFX;

    private void Start()
    {
        healthText.text = "Lives : 3";
    }

    private void OnTriggerEnter(Collider other)
    {
        health -= healthDecrease;
        healthText.text = "Lives : " + health.ToString();
        GetComponent<AudioSource>().PlayOneShot(damagedBaseSFX);
    }
}
