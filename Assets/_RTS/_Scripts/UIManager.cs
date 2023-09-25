using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public Text txtResource;
    public GameObject messagePopup;
    public Text txtMessage;

    IEnumerator DelayedHideMessage(float s)
    {
        yield return new WaitForSeconds(s);
        messagePopup.SetActive(false);
    }

    public void ShowMessage(string t, float time)
    {
        txtMessage.text = t;
        messagePopup.SetActive(true);
        StartCoroutine(DelayedHideMessage(time));
    }   

    public void ShowResources(int n)
    {
        txtResource.text = n.ToString();
    }
}
