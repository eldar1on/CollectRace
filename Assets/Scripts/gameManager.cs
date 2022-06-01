using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class gameManager : MonoBehaviour
{
    public TargetSuit[] _target;
    public ModelAcitavor[] _Activator;
    public int completeSuits;

    public Animator _animController;

    public static gameManager instance;

    public TargetImage _targetImage;

    public delegate void OverAction();
    public static event OverAction OnWin;

    public bool roundStarted;
    public GameObject startUI;


    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        completeSuits = 0;
        for (int i = 0; i < _target.Length; i++)
        {
            if(i == 0)
            {
                continue;
            }
            _target[i].enabled = false;
        }

    }



    void Update()
    {
        if (!roundStarted & Input.GetKeyDown(KeyCode.Mouse0))
        {
            roundStarted = true;
            startUI.SetActive(false);
            _animController.SetTrigger("Show");
        }
    }

    public void NextTarget()
    {
        //completeSuits++;
        print(_target.Length + "  complete " + completeSuits);

        if(completeSuits == _Activator.Length)
        {
            OnWin();
            _animController.SetTrigger("Win");
            return;
        }

        for (int i = 0; i < _Activator.Length; i++)
        {
            _Activator[i].SetUp();
        }
        _Activator[completeSuits].Activate();
    }

    public void NextLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void Win()
    {
        completeSuits++;

        if (completeSuits < _Activator.Length)
        {
            _target[completeSuits].MakeActive();
            _targetImage.ChangeImage();

        }
        else
        {
            OnWin();
            _animController.SetTrigger("Win");
        }

        
    }
}
