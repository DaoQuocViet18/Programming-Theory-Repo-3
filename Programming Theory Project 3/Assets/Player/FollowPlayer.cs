using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject camPosition;

    // Update is called once per frame
    void Update()
    {
        transform.position = camPosition.transform.position;
    }
}
