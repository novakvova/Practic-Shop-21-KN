namespace WebStoreMVC.Mapper;

using Riok.Mapperly.Abstractions;
using WebStoreMVC.Data.Entities.Catalog;
using WebStoreMVC.Models.Seeder;

[Mapper]
public partial class ProductMapper
{
    [MapperIgnoreTarget(nameof(ProductEntity.Id))]
    [MapperIgnoreTarget(nameof(ProductEntity.Category))]
    [MapperIgnoreTarget(nameof(ProductEntity.ProductImages))]
    public partial ProductEntity SeederProductModelToProductEntity(SeederProductModel model);
}
