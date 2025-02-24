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

   

    // Start is called before the first frame update
    void Start()
    {
        currentClickedMovingObject =0;
        currentScore = 0;
        SpawnMovingObject();

    }

    // Update is called once per frame
    void Update()
    {



    }
   public void SpawnMovingObject()
    {
        var spawnMovingObject = Instantiate(MovingObject);
        spawnMovingObject.transform.position = Position2.position;

    }


}
