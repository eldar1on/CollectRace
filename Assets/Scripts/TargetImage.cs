
using UnityEngine;
using UnityEngine.UI;

public class TargetImage : MonoBehaviour
{
    public Sprite[] _sprite;
    public Image _img;

    int i;

    public void ChangeImage()
    {
        i++;
        _img.sprite = _sprite[i];
    }
}
