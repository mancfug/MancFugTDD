namespace MancFugTDD.Domain

type ProductCode = private ProductCode of string

type Cost = private Cost of decimal
type UnitPrice = Cost
type Product = ProductCode * UnitPrice
type SpecialPrice = Cost
type Quantity = private Quantity of int
type Rule = {
    Item: ProductCode
    SpecialQuantity: Quantity
    SpecialPrice: Cost
}
type BasketItem = 
| ProductItem of ProductCode * Quantity * Cost
| DiscountItem of Rule * Cost
type Basket = {
    Items: BasketItem list
    Total: Cost
}

type Scan = ProductCode * Quantity * Basket -> Basket

type ValidationError = string

type InputGate = ProductCode * Quantity * BasketView -> BasketView * ValidationError list
type OutputGate = Basket -> BasketView * ValidationError list

module Things =
    let createProductCode = function
        | null -> Error "Product Code not found"
        | "" -> Error "Product Code is empty"
        | x when x.Length <> 1 -> Error "Product Code can only be 1 letter"
        | x when x < "A" || x > "Z" -> Error "Product Code must be uppercase letter"
        | x -> ProductCode x |> Ok 

    let createCost c = Cost c |> Ok 

    let createQuantity = function
        | x when x <= 0 -> Error "Quantity must be a positive number"
        | x when x > 10 -> Error "My word! You want to buy a lot of stuff"
        | x -> Quantity x |> Ok

    let createBasketItemFromView (i:BasketItemView): Result<BasketItem,string> =
        result {
            // TODO DiscountItem as well
            let! cost = createCost i.Cost
            let! productCode = createProductCode i.Item
            let! quantity = createQuantity i.Quantity
            let productItem = ProductItem(productCode,quantity,cost)
            return productItem
        }
