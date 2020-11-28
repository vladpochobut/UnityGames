using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> trees;
    [SerializeField]
    private Transform startPosition;
    private float BoxWidthX;
    private float BoxWidthZ;

    private void Start()
    {
        BoxWidthX = trees[1].GetComponent<BoxCollider>().size.x;
        BoxWidthZ = trees[1].GetComponent<BoxCollider>().size.z;

        for (int i = 0; i < trees.Count; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                GameObject tree = Instantiate(trees[i]);
                tree.transform.position = new Vector3(startPosition.position.x, startPosition.position.y, startPosition.position.z + (j * (BoxWidthZ / 2)));
            }
            startPosition.position = new Vector3(startPosition.position.x + ((BoxWidthX / 2)), startPosition.position.y, startPosition.position.z);
        }
    }
}
