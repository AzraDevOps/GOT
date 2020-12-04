using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraChauffeur : MonoBehaviour
{
    public Text azimut;
    public Text vitesseKMH;

    public RectTransform tankDirection;
    public PlayerController player;

    public GameObject tourelleTank;

    private void Start()
    {
        player = GetComponentInChildren<PlayerController>();
    }

    void Update()
    {
        azimut.text = Mathf.RoundToInt(transform.eulerAngles.y) + " °";

        vitesseKMH.text = player.moveSpeedChar + " KM/h";

        tankDirection.rotation = Quaternion.Euler(0, 0, Mathf.RoundToInt(tourelleTank.transform.eulerAngles.y) * -1);

    }
}
