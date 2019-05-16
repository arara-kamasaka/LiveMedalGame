using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class MedalProvider : MonoBehaviour
{
    [SerializeField] private GameObject[] medals;
    [SerializeField] private Transform mt;
    [SerializeField] private Text mText;
    
    public int initMedalNumber;
    private ReactiveProperty<int> currentMedalNumber = new ReactiveProperty<int>();
//    private int currentMedalNumber;
    private int getMedalNumber;
    
    void Start()
    {
        currentMedalNumber.Value = initMedalNumber;
        getMedalNumber = 0;

        currentMedalNumber.Subscribe(n =>
        {
            mText.text = n.ToString();
        }).AddTo(this);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentMedalNumber.Value > 0)
        {
            var mousePos = Input.mousePosition;
            var worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 5));
            var m = Instantiate(medals[0] ,worldPos, Quaternion.identity);
            var direction = new Vector3(0, 1, 2).normalized;
            m.GetComponent<Rigidbody>().AddForce(direction * 50, ForceMode.Impulse);
            currentMedalNumber.Value--;
        }
    }

    public void Get(int n)
    {
        currentMedalNumber.Value+=n;
        getMedalNumber++;
        if (getMedalNumber % 10 == 0)
        {
            Instantiate(medals[1], mt.position, Quaternion.identity);
        }
    }

    public void Check()
    {
        Instantiate(medals[0], mt.position, Quaternion.identity);
    }
}
