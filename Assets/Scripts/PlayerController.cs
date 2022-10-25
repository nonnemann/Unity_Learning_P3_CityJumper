using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isGameOver = false;
    public ParticleSystem explosionParticles;
    public ParticleSystem dirtParticles;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private float gravityModifier = 1.0f;
    [SerializeField] private bool isGrounded = true;

    private Rigidbody _playerRidgidbody;
    private Animator _playerAnimator;
    private AudioSource _playerAudio;

    private void Start()
    {
        _playerRidgidbody = GetComponent<Rigidbody>();
        _playerAnimator = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isGameOver)
        {
            _playerRidgidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            dirtParticles.Stop();
            _playerAudio.PlayOneShot(jumpSound, 1.0f);
            _playerAnimator.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision otherObject)
    {
        if (otherObject.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            dirtParticles.Play();
        }
        else if (otherObject.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            Debug.Log("Game Over!");
            dirtParticles.Stop();
            _playerAudio.PlayOneShot(crashSound, 1.0f);
            explosionParticles.Play();
            _playerAnimator.SetBool("Death_b", true);
            _playerAnimator.SetInteger("DeathType_int", 1);
        }
    }
}
