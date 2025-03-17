using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level1Shop : MonoBehaviour
{
    public bool fire1Collected;
    public bool fire2Collected;
    public bool fire3Collected;
    public bool fire4Collected;
    public bool Key1Collected;
    public bool Key2Collected;
    public bool Key3Collected;
    public bool sopIsUsable;
    public TMP_Text Key1CollectedText;
    public TMP_Text Key2CollectedText;
    public TMP_Text Key3CollectedText;
    [SerializeField] CharacterMovement characterMovement;
    [SerializeField] GameObject Level_1Shop;
    [SerializeField] MiningMiniGame miningMiniGame;
    [SerializeField] GameObject youCanJumpHigherNowText;


    // Start is called before the first frame update
    void Start()
    {
        fire1Collected = false;
        fire2Collected = false;
        fire3Collected = false;
        fire4Collected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitShop()
    {
        Level_1Shop.SetActive(false);
        characterMovement.canMove = true;
    }

    public void BuyKey1()
    {
        if (Key1Collected && !Key2Collected&& !Key3Collected)
        {


          //  miningMiniGame.canPlayTheMiniGame = true;
            Key1CollectedText.SetText("0");
            characterMovement.jumpingPower = characterMovement.jumpingPower + 2;
            miningMiniGame.movingObjectSpeed = miningMiniGame.movingObjectSpeed + 1;
            StartCoroutine(youCanJumpHigherNowTextDisappearDelay());
            Key1Collected = false;
        }


    }
    public void BuyKey2()
    {
        if (fire2Collected&&Key2Collected)
        {

           // miningMiniGame.canPlayTheMiniGame = true;
            Key2CollectedText.SetText("0");
            characterMovement.jumpingPower = characterMovement.jumpingPower + 2;
            miningMiniGame.movingObjectSpeed = miningMiniGame.movingObjectSpeed + 1;
            StartCoroutine(youCanJumpHigherNowTextDisappearDelay());
            Key2Collected = false;

        }

    }
    public void BuyKey3()
    {
            if (fire3Collected&&Key3Collected)
            {

              //  miningMiniGame.canPlayTheMiniGame = true;
                Key3CollectedText.SetText("0");
                characterMovement.jumpingPower = characterMovement.jumpingPower + 2;
                miningMiniGame.movingObjectSpeed = miningMiniGame.movingObjectSpeed + 1;
            StartCoroutine(youCanJumpHigherNowTextDisappearDelay());
            Key3Collected = false;

        }

    }
    IEnumerator youCanJumpHigherNowTextDisappearDelay()
    {
        youCanJumpHigherNowText.SetActive(true);
        yield return new WaitForSeconds(3f);
        youCanJumpHigherNowText.SetActive(false);

    }
}
