using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    public AudioClip scream1;
    public AudioClip scream2;
    public AudioClip scream3;
    public AudioClip scream4;
    public AudioClip scream5;
    public AudioClip scream6;
    AudioClip randy;
    int num;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        num = Random.Range(1, 7);
        if (num == 1)
        {
            randy = scream1;
        }
        if (num == 2)
        {
            randy = scream2;
        }
        if (num == 3)
        {
            randy = scream3;
        }
        if (num == 4)
        {
            randy = scream4;
        }
        if (num == 5)
        {
            randy = scream5;
        }
        if (num == 6)
        {
            randy = scream6;
        }
    }

    public void Scream()
    {
        GetComponent<AudioSource>().PlayOneShot(randy);
    }

}
