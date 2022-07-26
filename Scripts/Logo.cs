using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class Logo : MonoBehaviour
{
    public VideoPlayer VideoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
        IEnumerator ExampleCoroutine()
        {
            //Print the time of when the function is first called.
            VideoPlayer.Play();

            //yield on a new YieldInstruction that waits for 10 seconds.
            yield return new WaitForSeconds(4);

            //After we have waited 5 seconds print the time again.
            SceneManager.LoadScene("TitleScreen");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
