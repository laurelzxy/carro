using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyDistanceUI : MonoBehaviour
{
    public Transform player;         // referência ao player
    public Transform enemy;          // referência ao inimigo
    public TextMeshProUGUI distanceText;

    void Update()
    {
        if (enemy == null)
        {
            distanceText.text = "";
            return;
        }

        float dist = Vector2.Distance(player.position, enemy.position);

        distanceText.text = ((int)dist).ToString() + "m";
    }
}
