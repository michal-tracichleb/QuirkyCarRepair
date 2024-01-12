export function getCartItems(){
    return sessionStorage["cart"]
        ? JSON.parse(sessionStorage["cart"])
        : [];
}