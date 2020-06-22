using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    private string next;

    public DataMananger dataMananger;
    public Image[] UIImage;
    public Text[] UIText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());

        if (dataMananger.LoadInformation())
            next = "Main";
        else
            next = "Main";

        StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn()
    {
        for (float i = 0f; i <= 1f; i += 0.01f)
        {
            foreach (Image obj in UIImage)
                obj.color = new Color(obj.color.r, obj.color.g, obj.color.b, i);
            foreach (Text obj in UIText)
                obj.color = new Color(obj.color.r, obj.color.g, obj.color.b, i);

            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(2f);

        AsyncOperation op = SceneManager.LoadSceneAsync(next);
        op.allowSceneActivation = false;
        yield return new WaitUntil(() => op.isDone);
        
        for (float i = 1f; i >= 0f; i -= 0.01f)
        {
            foreach (Image obj in UIImage)
                obj.color = new Color(obj.color.r, obj.color.g, obj.color.b, i);
            foreach (Text obj in UIText)
                obj.color = new Color(obj.color.r, obj.color.g, obj.color.b, i);

            yield return new WaitForSeconds(0.01f);
        }

        op.allowSceneActivation = true;
        SceneManager.LoadScene(next);
    }
}
