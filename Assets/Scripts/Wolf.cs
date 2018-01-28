using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour {

    public GameObject objectToMove;
    public Transform StartPoint;
    public Transform EndPoint;

    public float movingSpeed;
    private Vector3 actualTarget;

    public Animator anim;

	void Start ()
    {
        actualTarget = EndPoint.position;
        anim = GetComponent<Animator>();
    }
	
	void Update ()
    {
        objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, actualTarget, movingSpeed * Time.deltaTime);
        if (objectToMove.transform.position == EndPoint.position)
        {
            actualTarget = StartPoint.position;
            objectToMove.transform.localScale = new Vector3(-2f, 2f, 2f);
        }
        else if (objectToMove.transform.position == StartPoint.position)
        {
            actualTarget = EndPoint.position;
            objectToMove.transform.localScale = new Vector3(2f, 2f, 2f);
        }
    }
 }

