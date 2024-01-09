using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampTitleToGameObject : MonoBehaviour
{
    public Text titleLabel;

    void Start()
    {
        Vector3 titlePos = Camera.main.WorldToScreenPoint(this.transform.position);
        titleLabel.transform.position = titlePos;
    }
}
