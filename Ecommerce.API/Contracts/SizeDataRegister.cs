namespace Ecommerce.API.Contracts;

public record Stock(int count);

public record SizeDataRegister(
    int Stock,
    int XS,
    int S,
    int M,
    int L,
    int XL,
    int XXL,
    int XXXL
);