using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    [SerializeField][Range(1, 20)] int snapFactor = 10;

    TextMesh label;

    void Update()
    {
        Vector3 snapPosition;
        snapPosition.x = Mathf.RoundToInt(transform.position.x / snapFactor) * snapFactor;
        snapPosition.z = Mathf.RoundToInt(transform.position.z / snapFactor) * snapFactor;
        transform.position = new Vector3(snapPosition.x, 0f, snapPosition.z);

        label = GetComponentInChildren<TextMesh>();
        label.text = snapPosition.x/snapFactor + "," + snapPosition.z/snapFactor;
    }
}
