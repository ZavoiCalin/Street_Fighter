using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public Fighter player1;
    public Fighter player2;

    public bool battleEnded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.healtPercent <= 0) {
            battleEnded = true;
        }
        else if (player2.healtPercent <= 0) {
            battleEnded = true;
        }
        
    }
}
