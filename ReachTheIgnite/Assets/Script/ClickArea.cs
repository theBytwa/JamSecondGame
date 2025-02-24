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
        if (miningMiniGameMovingObjectIsTriggering && Input.GetKeyDown(KeyCode.Space))
        {
           
        }
    }
}
