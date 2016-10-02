
    using UnityEngine;
    using System.Collections;
    using System.IO.Ports;


    public class punch2 : MonoBehaviour
    {
        // Use this for initialization
        SerialPort serial;
        private IEnumerator enumerator;
       
    void Start()
        {
            serial = new SerialPort("COM4", 9600);

        }

        // Update is called once per frame
        void Update()
        {

        }


        void OnTriggerExit(Collider other)
        {
        if (!serial.IsOpen)
            {
                serial.Open();
            }
            serial.Write("2");
            enumerator = ExecuteAfterTime(.25f);
            StartCoroutine(enumerator);

    

        }


        IEnumerator ExecuteAfterTime(float time)
        {
            yield return new WaitForSeconds(time);
         //   Debug.Log("Executing after .25 seconds");
            serial.Write("0");
        serial.Close();

        // Code to execute after the delay


    }

   

}






