namespace MancFugTDD.Domain

module Api =
    let inputGate : InputGate = fun (code, quantity, basket) ->
        {
            Items = []
            Total = 0m
        }, []