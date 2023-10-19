using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToward : MonoBehaviour
{
    private GameObject question;
    [SerializeField] private float velocity;
    private float initialVelocity;
    private float multiply = 2f;
    private float demultiply = 0.5f;
    private float accelerate;
    public bool isQuesDone;
    private GameManager gameManager;

    public bool isAnswerRight;

   
    // Start is called before the first frame update
    void Start()
    {
        question = GameObject.Find("ques");
        accelerate = -Mathf.Pow(velocity, 2) / (2 * 150f);
        isQuesDone = false;
        initialVelocity = velocity;
        
    }

    // Update is called once per frame
    void Update()
    {
        TargetDirection();
        QuestionApproach();
        if (question)
            transform.position = Vector3.MoveTowards(transform.position, question.transform.position, velocity * Time.deltaTime);
        else
            question = GameObject.Find("ques");

        
        ChangeSpeed();
    }

    private void QuestionApproach()
    {
        if (question)
        {
            if (Vector3.Distance(transform.position, question.transform.position) <= 40f)
            {
                velocity = Mathf.Clamp(velocity += accelerate * Time.deltaTime, 15f, initialVelocity * multiply);
                
                if (Vector3.Distance(transform.position, question.transform.position) <= 3f)
                    velocity = 0;
            }
        }
    }

    private void TargetDirection()
    {
        if (question)
        {
            var lookAtTarget = Quaternion.LookRotation(question.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookAtTarget, 0.5f);
        }    
    }    

    private void ChangeSpeed()
    {
        if (isQuesDone)
        {
            if (isAnswerRight)
            {
                velocity = initialVelocity * multiply;
            }
            else
            {
                velocity = initialVelocity * demultiply;
            } 
            isQuesDone = false;
        }
    }    

}
