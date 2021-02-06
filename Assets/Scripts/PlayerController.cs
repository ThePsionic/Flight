using UnityEngine;
using UnityEngine.SceneManagement;
using Leap;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public int sensitivity = 90;
    public GameObject planeMinimapObj;

    private Controller con;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        con = new Controller(2759);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("_Scenes/MainMenu");
    }

    void OnApplicationQuit()
    {
        con.StopConnection();
    }

    void FixedUpdate()
    {
        if (con.IsConnected)
        {
            Frame fr = con.Frame();
            if (fr.Hands.Count > 0)
            {
                Hand firstHand = fr.Hands[0];
                if (firstHand.Fingers.Count > 0)
                {
                    Finger thumb = firstHand.Fingers[0];
                    speed = thumb.IsExtended ? 10 : 35;
                }
                rb.transform.rotation = Quaternion.Euler(new Vector3(-firstHand.Direction.Pitch * sensitivity, rb.transform.rotation.eulerAngles.y, firstHand.PalmNormal.Roll * sensitivity));
                rb.transform.Rotate(new Vector3(0, firstHand.Direction.Yaw, 0));
            }
        }

        rb.transform.position += transform.forward * Time.deltaTime * speed;
        planeMinimapObj.transform.position = rb.transform.position;
        planeMinimapObj.transform.rotation = rb.transform.rotation;
    }
}