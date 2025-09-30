using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Vector2 startpos;
    private Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startpos;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        transform.position = new Vector3(mousePos.x, startpos.y, -5f);
    }
}
