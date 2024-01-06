export function getCartPrice(cart){
    let total = 0;
    cart.map((item) => {
        total += item.price
    })
    total = parseFloat(total.toFixed(2));
    return total;
}