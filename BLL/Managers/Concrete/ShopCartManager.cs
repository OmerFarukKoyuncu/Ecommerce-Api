using AutoMapper;
using BLL.Managers.Abstract;
using BLL.Managers.Concrete;
using DAL.Entities;
using DAL.Repositories.Concrete;

public class ShopCartManager : Manager<ShopCartDto, ShopCart>, IShopCartManager
{
    private readonly IMapper _mapper;
    private readonly Repository<ShopCart> _repository;
    private readonly Repository<ShopCartItem> _itemRepository;

    public ShopCartManager(IMapper mapper, Repository<ShopCart> repository, Repository<ShopCartItem> itemRepository) : base(repository, mapper)
    {
        _mapper = mapper;
        _repository = repository;
        _itemRepository = itemRepository;
    }

    public void AddItemById(int id, int productId, int quantity)
    {
        var cart = _repository.GetById(id);
        if (cart == null) { return; }

        var newItem = new ShopCartItem
        {
            ProductId = productId,
            ShopCartId = cart.Id,
            Quantity = Math.Max(quantity,1)
        };

        var existingItem = _itemRepository.GetWhere(x => x.ProductId == productId && x.ShopCartId == id).FirstOrDefault();
        if (existingItem == null)
        {
            _itemRepository.Add(newItem);
        }
        else
        {
            existingItem.Quantity+=Math.Max(quantity,1);
            _itemRepository.Update(existingItem);
        }
    }

    public void DecrementItemById(int id, int itemId)
    {
        var cart = _repository.GetById(id);
        if (cart == null) { return; }

        var existingItem = _itemRepository.GetById(itemId);
        if (existingItem == null)
        {
            return;
        }

        if (existingItem.Quantity <= 1)
        {
            _itemRepository.Remove(existingItem);
        }
        else
        {
            existingItem.Quantity--;
            _itemRepository.Update(existingItem);
        }
    }

    public void EmptyById(int id)
    {
        var cart = _repository.GetById(id);
        if (cart == null) { return; }

        var cartItems = _itemRepository.GetWhere(x => x.ShopCartId == id).ToList();

        foreach (var cartItem in cartItems)
        {
            _itemRepository.Remove(cartItem);
        }
    }

    public ShopCartDto GetByUserId(string userId)
    {
        var shopCarts = _repository.GetAll().Where(x => x.UserId == userId);
        var cart = _mapper.ProjectTo<ShopCartDto>(shopCarts).FirstOrDefault();

        if (cart == null)
        {
            var newCart = new ShopCart { UserId = userId };
            _repository.Add(newCart);
            return _mapper.Map<ShopCartDto>(newCart);
        }

        return cart;
    }

    public void IncrementItemById(int id, int itemId)
    {
        var cart = _repository.GetById(id);
        if (cart == null) { return; }

        var existingItem = _itemRepository.GetById(itemId);
        if (existingItem == null)
        {
            return;
        }

        existingItem.Quantity++;
        _itemRepository.Update(existingItem);
    }

    public void RemoveItemById(int id, int itemId)
    {
        var cart = _repository.GetById(id);
        if (cart == null) { return; }

        var existingItem = _itemRepository.GetById(itemId);
        if (existingItem == null)
        {
            return;
        }

        _itemRepository.Remove(existingItem);
    }

    public int GetIdByUserId(string userId)
    {
        var shopCarts = _repository.GetAll().Where(x => x.UserId == userId);
        var id = shopCarts.Select(x => x.Id).FirstOrDefault();

        if (id == 0)
        {
            var newCart = new ShopCart { UserId = userId };
            _repository.Add(newCart);
            return newCart.Id;
        }

        return id;
    }

    public List<string> CheckStock(ShopCartDto shopCart)
    {
            List<string> errorMessages = new List<string>();

            foreach (var item in shopCart.Items)
            {
                if (item.Quantity>item.Product.Stock)
                {
                    errorMessages.Add($"{item.Product.Name} stokta yok.");
                }
            }

            return errorMessages; 
        

    }
}
