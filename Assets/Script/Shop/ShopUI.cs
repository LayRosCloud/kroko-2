using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private MeshFilter _firstItem;
    [SerializeField] private MeshFilter _mainItem;
    [SerializeField] private MeshFilter _thirdItem;
    
    [SerializeField] private GameObject[] _objects;
    [SerializeField] private GameObject _parentItem;
    
    
    [SerializeField] private Image _IconSprite;
    
    [SerializeField] private Sprite _notBuySprite;
    [SerializeField] private Sprite _buySprite;
    [SerializeField] private Sprite _ApplySprite;
    
    [SerializeField] private Text _costText;
    [SerializeField] private Text _balanceText;
    
    private int _currentPosition = 1;
    private int _selectPosition;
    

    public int CurrentPosition => _currentPosition;
    public int SelectedPosition => _selectPosition;

    public void Init(Skin[] skins)
    {
        _selectPosition = PlayerPrefs.GetInt("SelectedSkin", 0);
        _balanceText.text = PlayerPrefs.GetInt("Coin", 0) + "$";
        
        for (int i = 0; i < skins.Length; i++)
        {
            if (PlayerPrefs.GetInt($"Skin-{i}", 0) == 1)
            {
                skins[i].Buy();
            }
        }
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
        _IconSprite.sprite = skin.IsSold ? _buySprite : _notBuySprite;
        
        if (_currentPosition == _selectPosition)
        {
            _IconSprite.sprite = _ApplySprite;
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
        _IconSprite.sprite = _buySprite;
    }

    public void Select()
    {
        PlayerPrefs.SetInt("SelectedSkin", _currentPosition);
        _selectPosition = _currentPosition;
        _IconSprite.sprite = _ApplySprite;
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
