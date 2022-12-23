using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public Transform Start;
    public Transform Goal;
    public GameObject targetObject;
    int ugoku;

    private Vector3 speed = new Vector3(1000, 1000, 0);

    public void OnClickStartButton()
    {
        ugoku = 1;

        FadeManager.Instance.LoadScene("SubScene", 5.0f);
    }

    private void Update()
    {
        if (ugoku == 1)
        {
            transform.position = Vector3.MoveTowards(Start.position, Goal.position, 3000.0f * Time.deltaTime);
            Vector3 Button = Start.transform.position;
            float dis = Vector3.Distance(Button, this.transform.position);
            if (dis < 1.0f)
            {
                Invoke("zoom", 0.3f);
            }
        }
    }

    void zoom()
    {
        targetObject.transform.localScale += speed * Time.deltaTime;
    }
}