using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject window;

    private SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();

       
    }

    // Update is called once per frame
    void Update()
    {
        if (window != null)
        {
            var wc = window.GetComponent<WindowMove>();
            if (wc.consertada == false)
            {
                spr.enabled = true;


                Vector3 direction = wc.transform.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                transform.rotation = Quaternion.Euler(0f, 0f, angle-90f);
            }
            else
            {
                spr.enabled = false;
            }

        }
    }
}
