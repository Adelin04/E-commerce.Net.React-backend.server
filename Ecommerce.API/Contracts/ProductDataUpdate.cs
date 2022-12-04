﻿namespace Ecommerce.API.Contracts;

public record ProductDataUpdate(
    string Name,
    string Brand,
    string Color,
    string Description,
    double Price,
    string PicturePath,
    long Stock,
    string Category
);