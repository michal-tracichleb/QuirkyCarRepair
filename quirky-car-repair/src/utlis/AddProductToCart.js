export function AddProductToCart(id, name, price, quantity = 1){
    let cart=[]
    if(sessionStorage.cart){
        cart = JSON.parse(sessionStorage.getItem('cart'))
    }
    const newItem = { id: id, name: name, price: price, quantity: quantity};
    let existingItemId = cart.findIndex(item => item.id === newItem.id);

    if(existingItemId !== -1){
        cart[existingItemId].quantity += quantity;
    } else {
        cart.push(newItem);
    }
    sessionStorage.setItem('cart', JSON.stringify(cart));
    window.dispatchEvent(new Event('storage'))
}