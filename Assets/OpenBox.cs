using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : MonoBehaviour
{
    private bool boxOpened;
    private bool coroutineAllowed;
    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        boxOpened = false;
        coroutineAllowed = true;
        initialPosition = transform.position;
        
    }

    private void OnMouseDown()
    {
        if(coroutineAllowed) Invoke("RunCoroutine", 0f);
    }

    private void RunCoroutine()
    {
        StartCoroutine("OpenThatDoor");
    }
    private IEnumerator OpenThatDoor()
    {
        coroutineAllowed = false;
        if(!boxOpened)
        {
            for(float i = 0f; i<=2f; i += 0.1f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, 
                    transform.localPosition.y, transform.localPosition.z + 0.1f);
                yield return new WaitForSeconds(0.05f);
            }
            boxOpened = true;
        }
        else
        {
            for(float i = 2f; i >= 0f; i -= 0.1f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x,
                    transform.localPosition.y, transform.localPosition.z - 0.1f);
                yield return new WaitForSeconds(0.05f);
            }
            transform.position = initialPosition;
            boxOpened = false;
        }
        coroutineAllowed = true;
    }
}
