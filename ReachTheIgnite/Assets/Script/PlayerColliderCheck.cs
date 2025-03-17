using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerColliderCheck : MonoBehaviour
{
    [SerializeField] private MiningMiniGame miningMiniGame;
    [SerializeField] private GameObject MiningMiniGame;
    private bool miniMiningGameTriggering = false;
    private bool level1ShopTriggering = false;
    [SerializeField] private Level1Shop level1Shop;
    [SerializeField] private GameObject Level1Shop;
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private GameObject ForgotToBuySomethingText;
    [SerializeField] private GameObject GoStoneClickE;
    [SerializeField] private GameObject EndScreen;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ActivateCOlliderTriggerEvents();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "MiningMiniGameCollider")
        {
            miniMiningGameTriggering = true;
        }
        if (other.gameObject.name == "ShopCollider")
        {
            level1ShopTriggering = true;
        }
        if (other.gameObject.name == "Ignite1")
        {
            Destroy(other.gameObject);
            level1Shop.fire1Collected = true;
            miningMiniGame.canPlayTheMiniGame = true;
            StartCoroutine(GoStoneClickEDelay());



        }
        if (other.gameObject.name == "Ignite2")
        {
            Destroy(other.gameObject);
            level1Shop.fire2Collected = true;
            miningMiniGame.canPlayTheMiniGame = true;



        }
        if (other.gameObject.name == "Ignite3")
        {
            Destroy(other.gameObject);
            level1Shop.fire3Collected = true;
            miningMiniGame.canPlayTheMiniGame = true;


        }
        if (other.gameObject.name == "Ignite4")
        {
            level1Shop.fire4Collected = true;
            miningMiniGame.canPlayTheMiniGame = true;
            EndScreen.SetActive(true);


            Debug.Log("Game Over!");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "MiningMiniGameCollider")
        {
            miniMiningGameTriggering = false;
        }
        if (other.gameObject.name == "ShopCollider")
        {
            level1ShopTriggering = false;
        }

    }

    void ActivateCOlliderTriggerEvents()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (miniMiningGameTriggering)
            {
                if (miningMiniGame.canPlayTheMiniGame)
                {

                    MiningMiniGame.SetActive(true);
                    miningMiniGame.doAfterActivation();
                }
                else 
                {
                    BuySomethingTextDisappearDelay();
                }
            }
            if (level1ShopTriggering)
            {
                Level1Shop.SetActive(true);
                characterMovement.canMove = false;

            }


        }
    }

    IEnumerator BuySomethingTextDisappearDelay()
    {
        ForgotToBuySomethingText.SetActive(true);
        yield return new WaitForSeconds(3f);
        ForgotToBuySomethingText.SetActive(false);


    }
    IEnumerator GoStoneClickEDelay() 
    { 
       GoStoneClickE.SetActive(true);   
        yield return new WaitForSeconds(3f);
        GoStoneClickE.SetActive(false);




    }
}
