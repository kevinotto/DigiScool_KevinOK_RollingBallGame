using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public GameObject Wall1;
    public GameObject Wall2;
    private Rigidbody rb;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            if (count == 5)
            {
                Wall1.gameObject.SetActive(false);
            }

            if (count == 10)
            {
                Wall2.gameObject.SetActive(false);
            }

            if (other.gameObject.tag == "danger")
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    void SetCountText()
    {
        countText.text = "Count " + count.ToString();
        if (count == 15)
        {
            winText.text = "You win!! Press R to restart or ESC to exit";
        }
    }
}
