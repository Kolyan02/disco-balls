using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private float speed = 2.7f;
    public int originPoint;
    private GameObject CatchPointL, CatchPointR, center;
    private Info infoScript;
    private ChangeColorOfPimples changeColorOfPimplesScript;
    private void Start()
    {
        center = GameObject.Find("CenterBall");
        CatchPointL = GameObject.Find("catchPointL");
        CatchPointR = GameObject.Find("catchPointR");
        infoScript = Camera.main.GetComponent<Info>();
        changeColorOfPimplesScript = Camera.main.GetComponent<ChangeColorOfPimples>();
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, center.transform.position, speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, center.transform.position) <= 0.08f)
        {
            changeColorOfPimplesScript.ChangePimpleColor(originPoint, Color.red);
            infoScript.HP--;
            Destroy(gameObject);
        }
        //Next. If instantiated ball is within the catcher, then delete it.
        if (Vector3.Distance(transform.position, CatchPointL.transform.position) <= 0.045f ||
            Vector3.Distance(transform.position, CatchPointR.transform.position) <= 0.045f)
        {
            changeColorOfPimplesScript.ChangePimpleColor(originPoint, Color.green);
            infoScript.CatchedBalls++;
            Destroy(gameObject);
        }
    }

}
