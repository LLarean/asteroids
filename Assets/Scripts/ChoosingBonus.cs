using System.Collections.Generic;
using EventBusSystem;
using UnityEngine;

public class ChoosingBonus : MonoBehaviour
{
    [SerializeField]
    private List<BonusCard> _bonuses;

    private void Start()
    {
        foreach (var bonuse in _bonuses)
        {
            bonuse.OnButtonClick += AddBonus;
        }
    }

    private void OnDestroy()
    {
        foreach (var bonuse in _bonuses)
        {
            bonuse.OnButtonClick -= AddBonus;
        }
    }

    private void AddBonus()
    {
        EventBus.RaiseEvent<IGameHandler>(handler => handler.HandleBonusAdd());
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}