using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    private Rigidbody _rigid;
    [SerializeField]
    private float _speed = 5.0f;
    public int coinTotal = 0;
    float vertical, horizontal;
    public ParticleSystem particle;
   
    private bool isOnAir;
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
        _speed = 30;
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        if (!isOnAir)
        {
            _rigid.AddForce(transform.right * _speed * horizontal);
            _rigid.AddForce(transform.up * _speed * vertical);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            particle.transform.position = transform.position;
            particle.Play();
            isOnAir = false;
        }
        

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            particle.Stop();
            isOnAir = true;
        }
    }
    public void PickupCoin()
    {
        coinTotal += 1;

    }

    //public void Particle()
    //{
    //    particle.transform.position = transform.position;
    //    particle.Play();
    //}

}
