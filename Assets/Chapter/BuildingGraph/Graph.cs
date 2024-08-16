using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] Transform pointPrefab;
    [SerializeField, Range(10, 100)] int resolution = 10;
    [SerializeField] private FUNCTION_CHOICE functionChoice;
    [SerializeField] private float functionDuration;
    [SerializeField] private float duration;
    Transform[] points;
    float step;
    int choice;

    void Awake()
    {
        GraphDraw();
    }
    void Update()
    {
        duration += Time.deltaTime;
        if (duration >= functionDuration)
        {
            duration -= functionDuration;
            choice++;
            SetFunctionChoice(choice);
        }

        AnimGraphSineGraph();
    }
    private void AnimGraphSineGraph()
    {
        float time = Time.time;
        float v = 0.5f * step - 1f;
        FunctionLibrary.Function function = functionChoice switch
        {
            FUNCTION_CHOICE.WAVE => FunctionLibrary.Wave,
            FUNCTION_CHOICE.MULTIWAVE => FunctionLibrary.MultiWave,
            FUNCTION_CHOICE.SINEGRAPH => FunctionLibrary.SineGraph,
            FUNCTION_CHOICE.RIPPLE => FunctionLibrary.Ripple,
            FUNCTION_CHOICE.SPHERE => FunctionLibrary.Sphere,
            FUNCTION_CHOICE.TORUS => FunctionLibrary.Torus,
            _ => FunctionLibrary.Wave,
        };
        for (int i = 0, x = 0, z = 0; i < points.Length; i++, x++)
        {
            if (x == resolution)
            {
                x = 0;
                z += 1;
                v = (z + 0.5f) * step - 1f;
            }
            float u = (x + 0.5f) * step - 1f;
            points[i].localPosition = function(u, v, time);
        }
    }
    private void GraphDraw()
    {
        step = 2f / resolution;
        var scale = Vector3.one * step;
        points = new Transform[resolution * resolution];

        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i] = Instantiate(pointPrefab);
            point.localScale = scale;
            points[i] = point;
            point.SetParent(transform, false);
        }

    }
    private void SetFunctionChoice(int number)
    {
        if (Enum.IsDefined(typeof(FUNCTION_CHOICE), number))
        {
            functionChoice = (FUNCTION_CHOICE)number;
        }
        else
        {
            Debug.LogWarning("Invalid function choice number");
        }
    }
    private enum FUNCTION_CHOICE
    {
        WAVE,
        MULTIWAVE,
        SINEGRAPH,
        RIPPLE,
        SPHERE,
        TORUS
    }
}
