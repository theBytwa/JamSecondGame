using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningMiniGameMovingObject : MonoBehaviour
{
    [SerializeField] Transform Position1;
    [SerializeField] Transform Position2;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private float movingObjectSpeed;
    [SerializeField] MiningMiniGame miningGame;


    // Start is called before the first frame update
    void Start()
    {
        Position1 = GameObject.Find("Position1").GetComponent<Transform>();
        Position2 = GameObject.Find("Position2").GetComponent<Transform>();
        miningGame = GameObject.Find("MiningMiniGame").GetComponent<MiningMiniGame>();
        movingObjectSpeed = miningGame.movingObjectSpeed;
        MoveTheIndicator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Position1")
        {
            Destroy(gameObject);
            Debug.Log("ObjectDestroyed");
            miningGame.SpawnMovingObject();
        }
    }
    public void MoveTheIndicator()
    {
        rb.velocity = new Vector3(0f, Position1.position.y * movingObjectSpeed);

    }
}
