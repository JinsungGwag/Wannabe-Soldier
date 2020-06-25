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
    public Text loading;

    // Start is called before the first frame update
    void Start()
    {
        loading.gameObject.SetActive(false);
        StartCoroutine(FadeIn());

        if (dataMananger.LoadInformation())
            next = "Main";
        else
            next = "Profile";
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

        loading.gameObject.SetActive(true);
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(next);
        op.allowSceneActivation = false;
        
        for (float i = 1f; i >= 0f; i -= 0.01f)
        {
            foreach (Image obj in UIImage)
                obj.color = new Color(obj.color.r, obj.color.g, obj.color.b, i);
            foreach (Text obj in UIText)
                obj.color = new Color(obj.color.r, obj.color.g, obj.color.b, i);
            loading.color = new Color(loading.color.r, loading.color.g, loading.color.b, i);

            yield return new WaitForSeconds(0.01f);
        }

        op.allowSceneActivation = true;
    }
}
