using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public enum PlayerType { 
        HUMAN, AI
    }
    public static float MAX_HEALTH = 100f;

    public float healt = MAX_HEALTH;
    public string fighterName;
    public Fighter oponent;

    public PlayerType player;
    public FighterStates currentState = FighterStates.IDLE;

    protected Animator animator;
    private Rigidbody myBody;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    public void UpdateHumanInput() {
        if (Input.GetAxis("Horizontal") > 0.1)
        {
            animator.SetBool("WALK", true);
        }
        else {
            animator.SetBool("WALK", false);
        }

        if (Input.GetAxis("Horizontal") < -0.1)
        {
            animator.SetBool("WALK_BACK", true);
        }
        else {
            animator.SetBool("WALK_BACK", false);
        }

        if (Input.GetAxis("Vertical") < -0.1)
        {
            animator.SetBool("DUCK", true);
        }
        else animator.SetBool("DUCK", false);

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            animator.SetTrigger("JUMP");
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            animator.SetTrigger("PUNCH");

        if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.Mouse1))
            animator.SetTrigger("KICK");

        if (Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.Mouse2))
            animator.SetTrigger("HADOKEN");

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("health", healtPercent);

        if (oponent != null)
        {
            animator.SetFloat("oponent_health", oponent.healtPercent);
        }
        else { 
            animator.SetFloat("oponent_health", 1);
        }

        if (player == PlayerType.HUMAN)
            UpdateHumanInput();

        if (healt <= 0 && currentState != FighterStates.DEAD) {
            animator.SetTrigger("DEAD");
        }
    }

    public virtual void hurt(float damage) {
        if (!invulnerable)
        {
            if (healt >= damage)
            {
                healt -= damage;
            }
            else healt = 0;

            if (healt > 0)
            {
                animator.SetTrigger("TAKE_HIT");
            }
        }
    }

    public bool invulnerable {
        get {
            return currentState == FighterStates.TAKE_HIT || currentState == FighterStates.TAKE_HIT_DEFEND || currentState == FighterStates.DEAD;
        }
    }

    public bool attacking {
        get {
            return currentState == FighterStates.ATTACK;
        }
    }

    public float healtPercent {
        get
        {
            return healt / MAX_HEALTH;
        }
    }

    public Rigidbody body
    {
        get
        {
            return this.myBody;
        }
    }
}
