using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinText : MonoBehaviour
{
    public GameObject ball;
    private Text text;  // using UnityEngine.UI;  eklemek laızm
    private int coins;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ball != null)
        {
            coins = ball.GetComponent<BallMove>().coinTotal;
        }
        text.text = ": " + coins;
    }
}
