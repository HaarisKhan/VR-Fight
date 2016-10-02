
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class randompunchscript : MonoBehaviour {
    public GameObject head;
    private IEnumerator routine;
    private IEnumerator delay;
    int myHealth = 100;
    public bool isGoodPunch = true;
    public bool hit = false;

    public Text myHealthText;
    public GameObject caesar;
    public Text result;

    // GameObject fist;
    //public GameObject right;

    //private bool hand;

    // Use this for initialization
    void Start () {
        StartCoroutine(Delay(Random.Range(0.5f, 1.5f)));
        myHealthText.text = "My health: " + myHealth.ToString();

    }

    // Update is called once per frame
    void Update () {
        
        if(myHealth <= 0)
        {
            // Debug.Log("Caesar lives another day");
            myHealthText.text = "Caesar lives another day!  ";
             Destroy(caesar);
            result.text = "You lose!";
            StartCoroutine(Restart());
        }

        myHealthText.text = "My health: " + myHealth.ToString();



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
            isGoodPunch = true;
            hit = false;
            for (float i = 0; i < duration && isGoodPunch; i += Time.deltaTime)
            {
                Vector3 newPosition = Vector3.Lerp(startPosition, endPosition, i / duration);
                glove.transform.position = newPosition;
                yield return null;
            }

            if (isGoodPunch)
            {
                glove.transform.position = endPosition;
                myHealth -= 10;                 
            }

            else
            {
                endPosition = glove.transform.position;
                myHealth -= 5;
            }

            for (float i = 0; i < duration; i += Time.deltaTime)
            {
                Vector3 newPosition = Vector3.Lerp(endPosition, startPosition, i / duration);
                glove.transform.position = newPosition;
                yield return null;
            }
          
            
            glove.transform.position = startPosition;

            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
            Debug.Log(myHealth);
        }
    }

    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        StartCoroutine(PunchLocation(this.gameObject));


    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2.0f);

        // Code to execute after the delay
        SceneManager.LoadScene(0);


    }

   
}
