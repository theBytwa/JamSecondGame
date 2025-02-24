using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningMiniGame : MonoBehaviour
{
    [SerializeField] GameObject MovingObject;
    [SerializeField] Rigidbody2D MovingObjectRb;
    [SerializeField] Transform Position1;
    [SerializeField] Transform Position2;
    [SerializeField] public float movingObjectSpeed = 5f;
    public int currentScore;
    public int currentClickedMovingObject;
    public bool ignite1Collected;
    public bool ignite2Collected;
    public bool ignite3Collected;
    public bool canPlayTheMiniGame;
    [SerializeField] CharacterMovement characterMovement;
    [SerializeField] Level1Shop level1;


   

    // Start is called before the first frame update
    void Start()
    {
        canPlayTheMiniGame = true;
          currentClickedMovingObject =0;
        currentScore = 0;
        SpawnMovingObject();
        characterMovement.canMove = false;

    }
    GameObject spawnedItem;
    // Update is called once per frame
    void Update()
    {
        if (!canPlayTheMiniGame)
        {
            Destroy(spawnedItem);
            spawnedItem = null;
        }


    }
    public void doAfterActivation()
    {
        canPlayTheMiniGame = true;
        currentClickedMovingObject = 0;
        currentScore = 0;
        SpawnMovingObject();
        characterMovement.canMove = false;
    }
   public void SpawnMovingObject()
    {
        var spawnMovingObject = Instantiate(MovingObject);
        spawnMovingObject.transform.position = Position2.position;
        spawnedItem = spawnMovingObject.gameObject;

    }

    public void SetCurrentScoreToOneOn3CurrentClickedMovingObject()
    {
        if (currentClickedMovingObject >= 3)
        {
            currentScore = currentScore + 1;
            currentClickedMovingObject = 0;
            if (currentScore >= 2) 
            {
                if (ignite1Collected && ignite2Collected && !ignite3Collected)
                {
                    canPlayTheMiniGame = false;
                    ignite3Collected = true;
                    level1.Key3Collected = true;
                    level1.Key3CollectedText.SetText("1");
                    gameObject.SetActive(false);
                    characterMovement.canMove = true;
                }
                
                if (ignite1Collected && !ignite2Collected && !ignite3Collected)
                {
                    canPlayTheMiniGame = false;
                    Debug.Log("collected");
                    ignite2Collected = true;
                    level1.Key2Collected = true;
                    level1.Key2CollectedText.SetText("1");
                    gameObject.SetActive(false);
                    characterMovement.canMove = true;




                }
                if (!ignite1Collected && !ignite2Collected && !ignite3Collected)
                {
                    canPlayTheMiniGame = false;

                    ignite1Collected = true;
                    level1.Key1Collected = true;
                    level1.Key1CollectedText.SetText("1");
                    gameObject.SetActive(false);
                    characterMovement.canMove = true;




                }

            }
          
        }
    }
}
