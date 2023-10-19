using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<Transform> quesPlaces;
    public GameObject question;

    private int nextQuestion;
    public bool isNext;
         
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(Instance);
        }    
    }

    private void Start()
    {
        nextQuestion = 0;
    }

    private void Update()
    {
        if (isNext)
        {
            isNext = false;
            if (nextQuestion == quesPlaces.Count) return;
            var newQuestion = Instantiate(question);
            newQuestion.transform.position = quesPlaces[nextQuestion].transform.position;
            nextQuestion++;
            
        }
    }




}
