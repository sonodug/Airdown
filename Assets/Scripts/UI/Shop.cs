using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Shop : MonoBehaviour
{
    [Inject] private Player _player;

    [SerializeField] private List<Plane> _planes = new List<Plane> ();
    [SerializeField] private PlaneView _template;
    [SerializeField] private GameObject _itemContainer;

    private void Start()
    {
        foreach (Plane plane in _planes)
        {
            AddItem(plane);
        }
    }

    private void AddItem(Plane plane)
    {
        var view = Instantiate(_template, _itemContainer.transform);
        view.SellButtonClick += OnSellButtonClick;
        view.Render(plane);
    }

    private void OnSellButtonClick(Plane plane, PlaneView view)
    {
        TrySellPlane(plane, view);
    }

    private void TrySellPlane(Plane plane, PlaneView view)
    {
        if (plane.Price <= _player.Money)
        {
            
        }       
    }
}
