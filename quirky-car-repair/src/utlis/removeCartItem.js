import {getCartItems} from "./getCartItems.js";

export function removeCartItem(id){
    const cart = JSON.parse(sessionStorage.getItem('cart')) || [];

    const indexToRemove = cart.findIndex(product => product.id === id);

    if (indexToRemove !== -1) {
        cart.splice(indexToRemove, 1);

        sessionStorage.setItem('cart', JSON.stringify(cart));
        return {success: true, data: getCartItems()}
    } else {
        return {success: false}
    }
}