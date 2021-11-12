using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUV : MonoBehaviour {

    public float parralaxX;
    public float parralaxY;

    public Vector2 offset;

    // Update is called once per frame
    void Update()
    {

        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;

        offset = mat.mainTextureOffset;

        offset.x = transform.position.x / transform.localScale.x / parralaxX;
        offset.y = transform.position.y / transform.localScale.y / parralaxY;

        if(offset.y >= 0.095)
        {
            offset.y = 0.1f;
        }
        if (offset.y <= -0.1)
        {
            offset.y = -0.095f;
        }

        mat.mainTextureOffset = offset;
    }
}

