using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersoAgricultureScript : MonoBehaviour
{
    //Variable
    public float VitesseMarche = 1.5f;
    public int CoeffRot = 60;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * CoeffRot * Time.deltaTime);

        // deplacement avec animation
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * VitesseMarche * Time.deltaTime);
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);

        }
    }

}
