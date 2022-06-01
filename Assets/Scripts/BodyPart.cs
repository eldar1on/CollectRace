using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{

    public List<GameObject> bodyParts;

    public List<ClothObject> _meshList;
    public ClothObject _mesh;
    public ClothObject _cloth;

    public Transform _target;

    public int openSection;
    public int currentSuitID;

    void Awake()
    {
        //currentSuitID = -1;

        float childCount = transform.childCount;
        //print(childCount);
        for (int i = 0; i < transform.childCount; i++)
        {
            bodyParts.Add(transform.GetChild(i).gameObject);
            bodyParts[i].SetActive(false);
        }

    }

    public void ChangeSuit(int newSuitID)
    {
        //print("Helloooo");

        if (newSuitID == -1 )
        {
            //print("ChangeSuitID -1");
            for (int i = 0; i < bodyParts.Count; i++)
            {
                bodyParts[i].SetActive(false);
            }
            currentSuitID = newSuitID;
            //currentSuitID = newSuitID;
            //return;
        }
        else
        {
            //print("ChangeSuitID > 0");

            if(currentSuitID > 0)
            {
                bodyParts[currentSuitID].SetActive(false);
            }
            bodyParts[newSuitID].SetActive(true);
            currentSuitID = newSuitID;
        }
    }


    public void Deliver()
    {
        if(currentSuitID != -1)
        {
            _mesh = _meshList[currentSuitID];
            _cloth = Instantiate(_mesh, transform.position, Quaternion.identity) as ClothObject;
            _cloth._endPos = _target.position;
            _cloth._target = _target;
            _cloth._ID = currentSuitID;


        }
        else
        {
            //print(-1f);
        }
    }
}
