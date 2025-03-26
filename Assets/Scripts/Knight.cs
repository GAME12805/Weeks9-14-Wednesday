using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    Animator animator;
    SpriteRenderer sr;
    public float speed = 2;
    public bool canRun = true;
    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float direction = Input.GetAxis("Horizontal");

        sr.flipX = (direction < 0);
        animator.SetFloat("movement", Mathf.Abs(direction));

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
            canRun = false;
        }

        if(canRun == true)
        {
            transform.position += transform.right * direction * speed * Time.deltaTime;
        }
        
    }

    public void AttackHasFinished()
    {
        Debug.Log("Ready to run again!");
        canRun = true;
    }
}
