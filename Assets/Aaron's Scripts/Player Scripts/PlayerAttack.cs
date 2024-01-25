using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject bat;
    Animator animator;
    Transform batTransform;
    BoxCollider collider;
    float time = 1f;
    [SerializeField] InputReader input;
    // Start is called before the first frame update
    void Start()
    {
        bat = this.gameObject;
        animator = bat.GetComponent<Animator>();
        batTransform = bat.transform;
        collider = bat.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("attacking", true);
            time += Time.deltaTime;
            if (time <= 3f)
            {
                bat.transform.localScale = new Vector3(batTransform.localScale.x + (time / 600), batTransform.localScale.y + (time / 600), batTransform.localScale.z + (time / 600));
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("continueSwing", true);
            collider.enabled = true;
            time = 1f;
            //bat.transform.localScale = new Vector3(1f, 1f, 1f);
            //time = 1f;
        }
    }

    public void Hold()
    {
        animator.SetBool("holding", true);
    }

    public void FinishAttack()
    {
        animator.SetBool("attacking", false);
        animator.SetBool("continueSwing", false);
        animator.SetBool("holding", false);
        collider.enabled = false;
        bat.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }
}
