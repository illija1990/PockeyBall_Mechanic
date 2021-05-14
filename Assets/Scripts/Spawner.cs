using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Segment _segment;
    [SerializeField] private Block _block;
    [SerializeField] private Finish _finish;
    [SerializeField] private int _towerSize;

    private void Start()
    {
        TowerBild();
    }

    private void TowerBild()
    {
        GameObject currentPoint = gameObject;

        for(int i =0; i < _towerSize; i++)
        {
            currentPoint = BuildSegment(currentPoint, _segment.gameObject);
            currentPoint = BuildSegment(currentPoint, _block.gameObject);
        }

        BuildSegment(currentPoint, _finish.gameObject);
    }

    private GameObject BuildSegment(GameObject currentSegment, GameObject nextSegment)
    {
        return Instantiate(nextSegment, GetBuildPoint(currentSegment.transform, nextSegment.transform), Quaternion.identity, transform);
    }

    private Vector3 GetBuildPoint(Transform curentSegment, Transform nextSegment)
    {
        return new Vector3(transform.position.x, curentSegment.position.y + curentSegment.localScale.y / 2 + nextSegment.localScale.y / 2, transform.position.z);
    }

}
