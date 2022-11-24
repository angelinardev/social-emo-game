using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{

    public TextMeshProUGUI textComp;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    public string[] Gplines;
    public string[] options;

    public float textSpeed;

    private int index;
    private int select;

    // Start is called before the first frame update
    void Start()
    {
        textComp.text = string.Empty;
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        startDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(textComp.text == Gplines[index])
            {
                nextLine();
            }
            else
            {
                StopAllCoroutines();
                textComp.text = Gplines[index];
            }
        }
    }

    void startDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    void nextLine()
    {
        if(index < Gplines.Length - 1)
        {
            index++;
            textComp.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }

    }

    public void Button1()
    {
        select = 1;
    }

   public void Button2()
    {
        select = 2;
    }

    public void Button3()
    {
        select = 3;
    }

    void Selection()
    {

        switch (select)
        {
            case 1:
                index +=1;
                break;
            case 2:
                index +=2;
                break;
            case 3:
                index +=3;
                break;

        }
    }

    IEnumerator TypeLine()
    {
        foreach(char c in Gplines[index].ToCharArray())
        {
            textComp.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
