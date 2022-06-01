using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCostume : MonoBehaviour
{
    public BodyPart[] _parts;

    Obstacle _obstacle;

    public int[] _id;

    public bool compared;


    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            //print("Obs");
            //other.gameObject.GetComponent<BodyPart>();
            _obstacle = other.gameObject.GetComponent<Obstacle>();
            _obstacle._shrink = true;
            SetUpCostume(_obstacle);
        }

        if(other.gameObject.tag == "Check")
        {
            compared = true;
            SendClothes();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Check")
        {
            compared = false;
        }
    }

    public void ChangeCostume()
    {
        for (int i = 0; i < _parts.Length; i++)
        {
            _parts[i].ChangeSuit(_id[i]);
        }
    }

    public void ClearCostume()
    {
        for (int i = 0; i < _parts.Length; i++)
        {
            _parts[i].ChangeSuit(-1);
            _id[i] = -1;
        }
    }


    public void SendClothes()
    {
        //foreach (var element in _parts)
        //{
        //    element.Deliver();
        //}

        _parts[0].Deliver();
        _parts[1].Deliver();
        _parts[2].Deliver();
        _parts[3].Deliver();
        _parts[4].Deliver();
        ClearCostume();
    }

    void SetUpCostume(Obstacle _obs)
    {
        //print("Dress ID: " + _obs.dressID + " Name : " + _obstacle.myDress+ " myDress :" + _obs.myDress);

        switch (_obstacle.myDress)
        {

            case Obstacle.DressType.Top:

                //print("Top");
                _id[0] = _obs.dressID;
                _parts[0].ChangeSuit(_obs.dressID);

                ///Close Dresses
                _id[2] = -1;
                _parts[2].ChangeSuit(-1);

                break;

            case Obstacle.DressType.Bottom:

                //print("Bottom");
                _id[1] = _obs.dressID;
                _parts[1].ChangeSuit(_obs.dressID);

                ///Close Dresses in case 
                _id[2] = -1;
                _parts[2].ChangeSuit(-1);


                break;

            case Obstacle.DressType.Complete:

                //print("Complete");
                _id[2] = _obs.dressID;
                _parts[2].ChangeSuit(_obs.dressID);

                //Close Top & Bottom

                _id[0] = -1;
                _parts[0].ChangeSuit(-1);

                _id[1] = -1;
                _parts[1].ChangeSuit(-1);

                break;
            case Obstacle.DressType.Shoe:

                //print("Hair");
                _id[3] = _obs.dressID;
                _parts[3].ChangeSuit(_obs.dressID);

                break;
            case Obstacle.DressType.Hair:

                //print("shoe");
                _id[4] = _obs.dressID;
                _parts[4].ChangeSuit(_obs.dressID);

                break;
            default:
                print("Default");
                break;
        }
    }
}
