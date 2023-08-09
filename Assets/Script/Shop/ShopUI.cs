using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [Header("Mesh")]
    [SerializeField] private MeshFilter _firstItem;
    [SerializeField] private MeshFilter _mainItem;
    [SerializeField] private MeshFilter _thirdItem;
    [Space]
    [SerializeField] private GameObject _parentItem;
    [Header("Images for button")]
    [SerializeField] private Image _IconSprite;
    [Space]
    [SerializeField] private Sprite _notBuySprite;
    [SerializeField] private Sprite _buySprite;
    [SerializeField] private Sprite _ApplySprite;
    [Header("Display UI")]
    [SerializeField] private Text _costText;
    [SerializeField] private Text _balanceText;
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _descriptionText;
    [Header("Others")]
    [SerializeField] private GameObject[] _hideObjects;

    private int _currentPosition = 1;
    private int _selectPosition;
    
    public int CurrentPosition => _currentPosition;
    public int SelectedPosition => _selectPosition;

    public void Init(Skin[] skins)
    {
        _selectPosition = PlayerPrefs.GetInt("SelectedSkin", 0);
        _balanceText.text = PlayerPrefs.GetInt("Coin", 0) + "$";
        ShopEvents.Instance.BuyEvent.AddListener(Buy);
        ShopEvents.Instance.SelectEvent.AddListener(Select);
        
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

    public void ShowSkin(Skin[] skins)
    {
        Skin skin = skins[_currentPosition];
        SetText(skin);
        
        _IconSprite.sprite = skin.IsSold ? _buySprite : _notBuySprite;
        
        if (_currentPosition == _selectPosition)
        {
            _IconSprite.sprite = _ApplySprite;
        }

        _firstItem.gameObject.SetActive(HasFirstItem());
        _thirdItem.gameObject.SetActive(HasSecondItem(skins));
        
        if (HasFirstItem())
        {
            _firstItem.mesh = skins[_currentPosition - 1].SkinMesh;
        }

        if (HasSecondItem(skins))
        {
            _thirdItem.mesh = skins[_currentPosition + 1].SkinMesh;
        }
    }

    private bool HasFirstItem()
    {
        return _currentPosition - 1 >= 0;
    }

    private bool HasSecondItem(Skin[] skins)
    {
        return _currentPosition + 1 < skins.Length;
    }
    
    private void SetText(Skin skin)
    {
        _mainItem.mesh = skin.SkinMesh;
        _costText.text = skin.Cost + " $";
        _nameText.text = skin.Name;
        _descriptionText.text = skin.Description;
    }
    
    public void Buy()
    {
        _balanceText.text = PlayerPrefs.GetInt("Coin", 0) + "$";
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
        foreach (var obj in _hideObjects)
        {
            obj.SetActive(false);
        }
        
        _parentItem.SetActive(true);
    }

    public void Close()
    {
        foreach (var obj in _hideObjects)
        {
            obj.SetActive(true);
        }
        
        _parentItem.SetActive(false);
    }
}
