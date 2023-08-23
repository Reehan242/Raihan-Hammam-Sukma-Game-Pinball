using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider Bola;
    public float multiplier;
    public Color color;
    public float score;

    private new Renderer renderer;
    private Animator animator;

    public AudioManager audioManager;
    public VFXManager vFXManager;
    public ScoreManager scoreManager;
    private void Start()
    {
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();


        renderer.material.color = color;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == Bola) 
        {
            Rigidbody bolaRig = Bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;

            //animation
            animator.SetTrigger("hit");
            //play sfx
            audioManager.PlaySFX(collision.transform.position);
            //play vfx
            vFXManager.PlayVFX(collision.transform.position);
            //score add
            scoreManager.AddScore(score);
        }
    }
}
