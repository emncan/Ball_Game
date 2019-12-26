﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player")
        {
            other.GetComponent<BallMove>().PickupCoin();

            Destroy(gameObject);
        }
    }
}