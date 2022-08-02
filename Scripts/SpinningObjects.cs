using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningObjects : MonoBehaviour
{
    [SerializeField] float spinXValue = 0f;
    [SerializeField] float spinYValue = 0f;
    [SerializeField] float spinZValue = 0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(spinXValue, spinYValue, spinZValue);
    }
}
