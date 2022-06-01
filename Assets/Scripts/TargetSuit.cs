using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSuit : MonoBehaviour
{

    public BodyPart[] _parts;

    public bool[] _dressed;
    public int[] _correctIndex;

    public int correctCount;
    public int lastCorrectCount;

    public Animator _animator;

    public GameObject[] _particle;

    public GameObject _dispersion;

    public void MakeActive()
    {
        print("Activated");
        StartCoroutine("CatWalkOut", 1f);
    }

    public void ChangePart(ClothObject _clothObj)
    {
        switch (_clothObj._style)
        {
            case ClothObject.DressType.Top:
                _parts[0].ChangeSuit(_clothObj._ID);

                _parts[2].ChangeSuit(-1);
                break;
            case ClothObject.DressType.Bottom:
                _parts[1].ChangeSuit(_clothObj._ID);

                _parts[2].ChangeSuit(-1);
                break;
            case ClothObject.DressType.Complete:
                _parts[0].ChangeSuit(-1);
                _parts[1].ChangeSuit(-1);

                _parts[2].ChangeSuit(_clothObj._ID);
                break;
            case ClothObject.DressType.Shoe:
                _parts[3].ChangeSuit(_clothObj._ID);
                break;
            case ClothObject.DressType.Hair:
                _dispersion.SetActive(false);
                _parts[4].ChangeSuit(_clothObj._ID);
                break;
            default:
                break;
        }
        if (correctSuitCombination())
        {
            print("WinCondition");
            gameManager.instance.Win();
        }
        else print("No Win Yet");
    }


    IEnumerator CatWalkOut(float time)
    {
        Vector3 startingPos = transform.position;
        Vector3 finalPos = transform.position + new Vector3(0,0,5f);
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    bool correctSuitCombination()
    {
        correctCount = 0;

        for (int i = 0; i < _correctIndex.Length; i++)
        {
            _dressed[i] = _correctIndex[i] == _parts[i].currentSuitID ? true : false;
            if (_dressed[i] == false)
            {
                correctCount--;
            }
            else correctCount++;
        }

        if (correctCount == 5)
        {
            _particle[0].SetActive(true);
            _animator.SetTrigger("Walk");
            return true;
        }
        else if(correctCount > lastCorrectCount)
        {
            lastCorrectCount = correctCount;
            //_animator.SetTrigger("Happy");
            _animator.Play("Win");
            _particle[0].SetActive(true);
            return false;
        }
        else
        {
            lastCorrectCount = correctCount;
            _particle[1].SetActive(true);
            //_animator.SetTrigger("Sad");
            _animator.Play("Lose");
            return false;
        }
    }

    public void AnimationEvent()
    {
        gameObject.SetActive(false);
        gameManager.instance.NextTarget();
    }
}
