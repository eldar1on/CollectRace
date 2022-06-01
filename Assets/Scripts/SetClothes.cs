using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetClothes : MonoBehaviour
{

    public PlayerCostume _pCostume;

    public void Awake()
    {
        _pCostume = GetComponent<PlayerCostume>();
    }


    public void ChangeCostume()
    {
        _pCostume.ChangeCostume();
    }
}
