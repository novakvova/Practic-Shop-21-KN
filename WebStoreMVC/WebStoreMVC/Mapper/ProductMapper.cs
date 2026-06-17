namespace WebStoreMVC.Mapper;

using Riok.Mapperly.Abstractions;
using System.Globalization;
using WebStoreMVC.Areas.Admin.Models.Product;
using WebStoreMVC.Data.Entities.Catalog;
using WebStoreMVC.Models.Product;
using WebStoreMVC.Models.Seeder;

[Mapper]
public partial class ProductMapper
{
    [MapperIgnoreTarget(nameof(ProductEntity.Id))]
    [MapperIgnoreTarget(nameof(ProductEntity.Category))]
    [MapperIgnoreTarget(nameof(ProductEntity.ProductImages))]
    public partial ProductEntity SeederProductModelToProductEntity(SeederProductModel model);

    [MapProperty(nameof(ProductEntity.Category.Name), nameof(ProductItemModel.CategoryName))]
    [MapProperty(nameof(ProductEntity.Category.Slug), nameof(ProductItemModel.CategorySlug))]
    [MapProperty(nameof(ProductEntity.ProductImages), nameof(ProductItemModel.Images))]
    public partial ProductItemModel ProductEntityToProductItemModel(ProductEntity entity);

    public partial List<ProductItemModel> ListProductEntityToItemModels(IEnumerable<ProductEntity> entities);

    private List<string> MapImages(ICollection<ProductImageEntity>? images)
    {
        return images?
            .OrderBy(x => x.Priority)
            .Select(x => x.Name)
            .ToList()
            ?? [];
    }

    [MapperIgnoreTarget(nameof(ProductEntity.CategoryId))]
    [MapperIgnoreTarget(nameof(ProductEntity.ProductImages))]
    public partial ProductEntity CreateProductToProductEntity(CreateProductViewModel model);

    [UserMapping(Default = true)]
    private static decimal MapPriceToDecimal(string price)
    {
        if (string.IsNullOrWhiteSpace(price))
            throw new FormatException("Ціна не може бути порожньою");

        price = price.Trim()
                      .Replace(" ", string.Empty)
                      .Replace("\u00A0", string.Empty); // прибираємо звичайні та нерозривні пробіли (тисячні розділювачі)

        var lastComma = price.LastIndexOf(',');
        var lastDot = price.LastIndexOf('.');

        string normalized;

        if (lastComma >= 0 && lastDot >= 0)
        {
            // Якщо є і кома, і крапка — той символ, що йде останнім, є десятковим розділювачем
            normalized = lastComma > lastDot
                ? price.Replace(".", string.Empty).Replace(',', '.')   // "1.234,56" -> "1234.56"
                : price.Replace(",", string.Empty);                    // "1,234.56" -> "1234.56"
        }
        else if (lastComma >= 0)
        {
            normalized = price.Replace(',', '.');                     // "1234,56" -> "1234.56"
        }
        else
        {
            normalized = price;                                       // "1234.56" або "1234"
        }

        if (!decimal.TryParse(normalized, NumberStyles.Number, CultureInfo.InvariantCulture, out var result))
            throw new FormatException($"Не вдалося перетворити значення ціни '{price}' у число.");

        return result;
    }
}
