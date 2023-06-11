using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShopUI))]
public class Shop : MonoBehaviour
{
    [SerializeField] private Skin[] _skins;
    [SerializeField] private MeshFilter _playerMesh;
    private ShopUI _shopUI;
    
    private void Awake()
    {
        _shopUI = GetComponent<ShopUI>();
        _shopUI.Init();
        _shopUI.MoveLeft(_skins);
        if (_shopUI.SelectedPosition != -1)
        {
            _playerMesh.mesh = _skins[_shopUI.SelectedPosition].SkinMesh;
        }
    }
    public void Buy()
    {
        float currentBalance = PlayerPrefs.GetInt("Coin", 0);
        Skin skin = _skins[_shopUI.CurrentPosition];
        
        if (currentBalance - skin.Cost >= 0 && skin.IsSold == false)
        {
            skin.Buy();
            _shopUI.Buy();
        }
    }

    public void Select()
    {
        Skin skin = _skins[_shopUI.CurrentPosition];
        if (skin.IsSold)
        {
            _playerMesh.mesh = skin.SkinMesh;
            _shopUI.Select();
        }
    }
    
    public void MoveRight()
    {
        _shopUI.MoveRight(_skins);
    }
    
    public void MoveLeft()
    {
        _shopUI.MoveLeft(_skins);
    }
}
