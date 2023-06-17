using UnityEngine;

[RequireComponent(typeof(ShopUI))]
public class Shop : MonoBehaviour
{
    [SerializeField] private Skin[] _skins;
    [SerializeField] private Player _player;
    private ShopUI _shopUI;
    
    private void Awake()
    {
        _shopUI = GetComponent<ShopUI>();
        _shopUI.Init(_skins);
        _shopUI.MoveLeft(_skins);
        if (_shopUI.SelectedPosition != -1)
        {
            _player.gameObject.GetComponentInChildren<MeshFilter>().mesh = _skins[_shopUI.SelectedPosition].SkinMesh;
        }
    }
    public void Buy()
    {
        int currentBalance = PlayerPrefs.GetInt("Coin", 0);
        Skin skin = _skins[_shopUI.CurrentPosition];
        
        if (currentBalance - skin.Cost >= 0 && skin.IsSold == false)
        {
            PlayerPrefs.SetInt("Coin", currentBalance - skin.Cost);
            PlayerPrefs.SetInt($"Skin-{_shopUI.CurrentPosition}", 1);
            skin.Buy();
            _shopUI.Buy();
        }
    }

    public void Select()
    {
        Skin skin = _skins[_shopUI.CurrentPosition];
        if (skin.IsSold)
        {
            _player.gameObject.GetComponentInChildren<MeshFilter>().mesh = skin.SkinMesh;
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
