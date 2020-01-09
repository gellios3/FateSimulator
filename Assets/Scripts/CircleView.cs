using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.ProceduralImage;

public class CircleView : MonoBehaviour
{
    [SerializeField] private ProceduralImage image;

    [SerializeField] private int time;

    // Update is called once per frame
    private void Update()
    {
        if (image.fillAmount < 1)
            image.fillAmount += Time.deltaTime / time;
        else
            image.fillAmount = 0;
    }
}