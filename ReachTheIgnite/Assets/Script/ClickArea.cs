using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickArea : MonoBehaviour
{
    [SerializeField] private MiningMiniGame miningMiniGame;
    public bool miningMiniGameMovingObjectIsTriggering;
    // Start is called before the first frame update
    void Start()
    {
       
        miningMiniGameMovingObjectIsTriggering = false;
    }

    // Update is called once per frame
    void Update()
    {
        MiningMiniGameClickEvent();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "MiningMiniGameMovingObject")
        {
            miningMiniGameMovingObjectIsTriggering =true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "MiningMiniGameMovingObject")
        {
            miningMiniGameMovingObjectIsTriggering = false;
        }
    }

    void MiningMiniGameClickEvent()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {


            if (miningMiniGameMovingObjectIsTriggering)
            {
                miningMiniGame.currentClickedMovingObject = miningMiniGame.currentClickedMovingObject + 1;

                miningMiniGame.SetCurrentScoreToOneOn3CurrentClickedMovingObject();
            }
            else
            {
                miningMiniGame.currentClickedMovingObject = miningMiniGame.currentClickedMovingObject - 1;
                if (miningMiniGame.currentClickedMovingObject <= 0)
                {
                    miningMiniGame.currentClickedMovingObject = 0;
                }

            }
        }
    }
}
