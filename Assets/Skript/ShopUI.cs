using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private MeshFilter _firstItem;
    [SerializeField] private MeshFilter _mainItem;
    [SerializeField] private MeshFilter _thirdItem;
    
    [SerializeField] private GameObject[] _objects;
    [SerializeField] private GameObject _parentItem;
    [SerializeField] private Text _buyText;
    [SerializeField] private Text _costText;
    [SerializeField] private Text _balanceText;
    
    private int _currentPosition = 1;
    private int _selectPosition = 0;
    
    private const string SOLD = "куплено";
    private const string NOT_SOLD = "купить";
    private const string SELECTED = "выбрано";
    public int CurrentPosition => _currentPosition;
    public int SelectedPosition => _selectPosition;

    public void Init()
    {
        _selectPosition = PlayerPrefs.GetInt("SelectedSkin", -1);
        _balanceText.text = PlayerPrefs.GetInt("Coin", 0).ToString() + "$";
    }

    public void MoveRight(Skin[] skins)
    {
        if (_currentPosition + 1 >= skins.Length)
        {
            return;
        }

        _currentPosition++;
        
        ShowSkin(skins);
    }

    public void MoveLeft(Skin[] skins)
    {
        if (_currentPosition - 1 < 0)
        {
            return;
        }
        
        _currentPosition--;
        ShowSkin(skins);
    }

    private void ShowSkin(Skin[] skins)
    {
        Skin skin = skins[_currentPosition];
        _mainItem.mesh = skin.SkinMesh;
        _costText.text = skin.Cost.ToString() + " $";
        _buyText.text = skin.IsSold ? SOLD : NOT_SOLD;
        
        if (_currentPosition == _selectPosition)
        {
            _buyText.text = SELECTED;
        }
        
        bool hasFirstItem = _currentPosition - 1 >= 0;
        bool hasSecondItem = _currentPosition + 1 < skins.Length;
        
        _firstItem.gameObject.SetActive(hasFirstItem);
        _thirdItem.gameObject.SetActive(hasSecondItem);
        
        if (hasFirstItem)
        {
            _firstItem.mesh = skins[_currentPosition - 1].SkinMesh;
        }

        if (hasSecondItem)
        {
            _thirdItem.mesh = skins[_currentPosition + 1].SkinMesh;
        }
    }
    
    public void Buy()
    {
        _balanceText.text = PlayerPrefs.GetInt("Coin", 0).ToString() + "$";
        _buyText.text = SOLD;
    }

    public void Select()
    {
        PlayerPrefs.SetInt("SelectedSkin", _currentPosition);
        _selectPosition = _currentPosition;
        _buyText.text = SELECTED;
    }
    public void Show()
    {
        foreach (var obj in _objects)
        {
            obj.SetActive(false);
        }
        _parentItem.SetActive(true);
    }

    public void Close()
    {
        foreach (var obj in _objects)
        {
            obj.SetActive(true);
        }
        _parentItem.SetActive(false);
    }
}
