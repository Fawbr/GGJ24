using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject bat;
    Animator animator;
    [SerializeField] InputReader input;
    // Start is called before the first frame update
    void Start()
    {
        bat = this.gameObject;
        animator = bat.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.Play("Swing", -1, 0f);
        }
    }
}
