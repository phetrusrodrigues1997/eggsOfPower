using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InnerEnemyUI : MonoBehaviour
{
    [Tooltip("UI Slider to display Player's Health")]
    [SerializeField]
    private Slider enemyHealthSlider;

    [Tooltip("Enemy Script")]
    [SerializeField]
    private Health health;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealthSlider.value = health.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        enemyHealthSlider.value = health.GetHealth();
    }
}
