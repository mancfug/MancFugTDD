namespace MancFugTDD.Domain

// needs to be a class with a default constructor and properties for model binding to work
type BasketItemView(item: string,quantity: int,rule: string,description: string,cost: decimal) = 
    member val Item = item with get,set 
    member val Quantity = quantity with get,set 
    member val Rule = rule with get,set 
    member val Description = cost with get,set 
    member val Cost = cost with get,set 
    new() = BasketItemView("",0,"","",0m)

type BasketView = {
    Items: BasketItemView list
    Total: decimal
}