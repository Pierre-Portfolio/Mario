using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaMove : MonoBehaviour {


	public float rcTaille = 0.35f;
    // starting value for the Lerp
	public float taille =0.2f;

	private Animator anim;

    private float speed = 1.0f;
    bool movingRight = true;

    private bool isMort = false;

    public bool test = false;

    void Start(){

		anim = GetComponent<Animator> ();
     //   origin = this.transform.position;
	
	}



    void TurnLeft()
    {
        transform.Rotate(0, 180, 0, Space.World);
        movingRight = false;
    }

    void TurnRight()
    {
        transform.Rotate(0, 180, 0, Space.World);
        movingRight = true;
    }


    public void KillGoomba()
    {
        isMort = true;
        Debug.Log("Le Goomba Meurt");
        anim.SetBool("isMort", true);
        StartCoroutine(attenteFinAnimation());

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isMort)
        {
            other.transform.GetComponent<mvt>().degat();
        }
    }

    void CheckCollision()
    {
        Vector3 addV;
        if (movingRight)
        {
            addV = Vector3.right;
        }
        else
        {
            addV = Vector3.left;
        }

        RaycastHit hit;
        Vector3 dir = transform.position + addV*0.2f;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(dir + new Vector3(0,0.5f,0), addV, out hit, 0.2f))
        {
            if (hit.collider.tag != "Player")
            {
                if (test)
                    Debug.Log("ENTER COLLISION WITH WALL");
                if (movingRight)
                    TurnLeft();
                else
                    TurnRight();
            }
        }
        Debug.DrawRay(dir + new Vector3(0, 0.5f, 0), addV * 0.2f, Color.yellow);
        RaycastHit hitGround;

        Debug.DrawRay(transform.position + Vector3.up + addV, transform.TransformDirection(Vector3.down) * 1.5f, Color.yellow);
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position + Vector3.up + addV, transform.TransformDirection(Vector3.down), out hitGround, 1.5f))
        {
        }
        else
        {
            if (movingRight)
                TurnLeft();
            else
                TurnRight();
        }

    }


    void FixedUpdate()
    {


        if (!isMort)
        {


            Vector3 pos = transform.position;

            if (movingRight)
            {
                    pos.x += Time.deltaTime * speed;
                    transform.position = pos;
            }
            else
            {
                    pos.x -= Time.deltaTime * speed;
                    transform.position = pos;
            }
            CheckCollision();

        }


    }


    IEnumerator attenteFinAnimation() {

        yield return new WaitForSeconds(1);

        Destroy(this.gameObject);


    }

    }