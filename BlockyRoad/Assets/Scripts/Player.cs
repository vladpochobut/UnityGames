using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float blocksToTree;


    public GameObject player;
    Timer pushTimer;
    Timer objectsAround;
    public static bool isItMove = false;
    Rigidbody rb;
    RaycastHit hit;
    public int distance;
    public int coins;

    bool isRigth = false;
    bool isLeft = false;
    bool isTop = false;

    
    private void Awake()
    {
        HUD.ResetDistance();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        pushTimer = gameObject.AddComponent<Timer>();
        pushTimer.Duration = ConfigurationData.PUSH_TIMER_DURATION;

        objectsAround = gameObject.AddComponent<Timer>();
        objectsAround.Duration = ConfigurationData.OBJECTS_AROUND_DURATION;

    }
    

    // Update is called once per frame
    void FixedUpdate()
    {

        Move();

    }
    private void Update()
    {

        TreesCheck();
        
    }

    void Move()
    {
        isItMove = false;
        if (Input.GetKeyDown(KeyCode.W) && !pushTimer.Running && !isTop)
        {

            HUD.AddDistance();
            distance++;
            isItMove = true;
            pushTimer.Run();
            player.transform.DORotateQuaternion(Quaternion.AngleAxis(-90, Vector3.up), ConfigurationData.ROTATE_DURATION);
            player.transform.DOJump(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), 
                ConfigurationData.JUMP_POWER, 
                ConfigurationData.NUM_JUMPS,
                ConfigurationData.JUMP_DURATION, false);
        }
        if (Input.GetKeyDown(KeyCode.A) && !pushTimer.Running && !isLeft)
        {
            isItMove = true;
            pushTimer.Run();
            player.transform.DORotateQuaternion(Quaternion.AngleAxis(-180, Vector3.up), ConfigurationData.ROTATE_DURATION);
            player.transform.DOJump(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), 
                ConfigurationData.JUMP_POWER,
                ConfigurationData.NUM_JUMPS,
                ConfigurationData.JUMP_DURATION, false);
        }
        if (Input.GetKeyDown(KeyCode.D) && !pushTimer.Running && !isRigth)
        {
            isItMove = true;
            pushTimer.Run();
            player.transform.DORotateQuaternion(Quaternion.AngleAxis(0, Vector3.up), ConfigurationData.ROTATE_DURATION);
            player.transform.DOJump(new Vector3(transform.position.x, transform.position.y, transform.position.z - 1),
                ConfigurationData.JUMP_POWER,
                ConfigurationData.NUM_JUMPS,
                ConfigurationData.JUMP_DURATION, false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<VehicleScript>() != null)
        {
            if (collision.gameObject.tag == "Board")
            {
                transform.parent = collision.collider.transform;

            }
        }
        else 
        {
            transform.parent = null;
        }
    }

    void TreesCheck()
    {

        Ray landingRayRight = new Ray(transform.position,new Vector3(0,0,-1));
        Ray landingRayTop = new Ray(transform.position, new Vector3(1,0,0));
        Ray landingRayLeft = new Ray(transform.position, new Vector3(0,0,1));


        if (Physics.Raycast(landingRayLeft, out hit, blocksToTree))
        {
            if (hit.collider.tag == "tree")
            {
                objectsAround.Run();
                isLeft = true;
            }
        
        }
        else if (Physics.Raycast(landingRayRight, out hit, blocksToTree))
        {
            if (hit.collider.tag == "tree")
            {
                isRigth = true;
            }

        }
        else if (Physics.Raycast(landingRayTop, out hit, blocksToTree))
        {
            if (hit.collider.tag == "tree")
            {
                isTop = true;
            }

        }
        else 
        {
            isTop = false;
            isLeft = false;
            isRigth = false;

        }

    }

}
