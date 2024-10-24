using ConsoleApp.PetStore.Classes;
using System.Xml.Linq;

namespace ConsoleApp.PetStore;

public class ProductLogic
{
    public ProductLogic()
    {
        _products = new List<Product>();
        _dogLeashes = new Dictionary<string, DogLeash>();
        _catFood = new Dictionary<string, CatFood>();
    }

    private List<Product>? _products;
    private Dictionary<string, DogLeash>? _dogLeashes;
    private Dictionary<string, CatFood>? _catFood;

    public void AddProduct(Product product)
    {
        if (product is DogLeash)
        {
            _dogLeashes?.Add(product.Name, product as DogLeash);
        }

        if (product is CatFood)
        {
            _catFood?.Add(product.Name, product as CatFood);
        }

        _products?.Add(product);
    }

    public List<Product> GetAllProducts()
    {
        return _products ?? (_products = new List<Product>());
    }

    public DogLeash GetDogLeashByName(string name)
    {
        return _dogLeashes[name];
    }
}
