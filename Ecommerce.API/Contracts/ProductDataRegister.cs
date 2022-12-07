using Ecommerce.API.Models;

namespace Ecommerce.API.Contracts;

public record ProductDataRegister
(
    string Name,
    string Brand,
    string Color,
    string Description,
    double Price,
    string PicturePath,
    long Stock,
    string CategoryName
);