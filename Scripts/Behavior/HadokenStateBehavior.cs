using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HadokenStateBehavior : FighterStateBehavior
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        float fighterX = fighter.transform.position.x;

        GameObject instance=(GameObject)Object.Instantiate(
            Resources.Load("sfx/hadoken_plane"),
            new Vector3(fighterX,1,0),
            Quaternion.Euler(0,0,0)
        ) as GameObject;

        Hadoken hadoken = instance.GetComponent<Hadoken>();
        hadoken.caster = fighter;

    }
}
