using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreText;
    private int Lifes;
    public int maxLife=3;
    // Start is called before the first frame update
    void Start()
    {
        Lifes = maxLife;
        ScoreText.text = Lifes.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = Lifes.ToString();
    }
    public void Decrease()
    {
        Decrease(1);
    }
    public void Decrease(int x)
    {
        if (Lifes < x) Lifes = 0;
        else Lifes -= x;
        if(Lifes == 0)
        {
            Destroy(FindObjectOfType<Player>().gameObject);
        }
    }
    public void Increase()
    {
        Increase(1);
    }
    public void Increase(int x)
    {
        if (Lifes + x > maxLife) Lifes = maxLife;
        else Lifes += x;
    }
}
