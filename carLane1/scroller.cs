using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scroller : MonoBehaviour
{
    [SerializeField] private RawImage img;

    // Update is called once per frame
    void Update()
    {
        img.uvRect = new Rect(img.uvRect.position + new Vector2(1, 0) * Time.deltaTime/7.5f, img.uvRect.size);
    }
}
