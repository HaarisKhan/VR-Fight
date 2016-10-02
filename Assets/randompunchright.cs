
using UnityEngine;
using System.Collections;

public class randompunchright : MonoBehaviour {
    public GameObject head;
    private IEnumerator routine;
    private IEnumerator delay;

    public GameObject left;
    public GameObject right;

    private bool hand;

    // Use this for initialization
    void Start () {
        //StartCoroutine(Delay1(Random.Range(1f, 2.5f)));
        //StartCoroutine(Delay2(Random.Range(1f, 2.5f)));
        StartCoroutine(PunchLocation(left));
        StartCoroutine(PunchLocation(right));

    }

    // Update is called once per frame
    void Update () {
        //GameObject punch1 = GameObject.Find("left");
        //GameObject punch2 = GameObject.Find("right");


	}

    IEnumerator PunchLocation(GameObject glove)
    {

        while (true)
        {
            float duration = 1.0f;
            Vector3 startPosition = glove.transform.position;

            Vector3 headPosition = head.transform.position;
            float width = glove.transform.localScale.z;
            Vector3 endPosition = new Vector3(headPosition.x + Random.Range(-4, 4), headPosition.y + Random.Range(-5, -2), headPosition.z - width);
            for (float i = 0; i < duration; i += Time.deltaTime)
            {
                Vector3 newPosition = Vector3.Lerp(startPosition, endPosition, i / duration);
                glove.transform.position = newPosition;
                yield return null;
            }
            glove.transform.position = endPosition;

            for (float i = 0; i < duration; i += Time.deltaTime)
            {
                Vector3 newPosition = Vector3.Lerp(endPosition, startPosition, i / duration);
                glove.transform.position = newPosition;
                yield return null;
            }
            
            glove.transform.position = startPosition;

            yield return new WaitForSeconds(Random.Range(1f, 2.5f));
        }
    }

    IEnumerator Delay1(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        StartCoroutine(PunchLocation(left));


    }

    IEnumerator Delay2(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        StartCoroutine(PunchLocation(right));


    }

}
