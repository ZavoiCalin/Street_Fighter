using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    public Fighter player1;
    public Fighter player2;


    public Scrollbar leftBar;
    public Scrollbar rightBar;

    public Text player1Tag;
    public Text player2Tag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (leftBar.size > player1.healtPercent) {
            leftBar.size -= 0.01f;
        }

        if (rightBar.size > player2.healtPercent) {
            rightBar.size -= 0.01f;
        }
    }
}
