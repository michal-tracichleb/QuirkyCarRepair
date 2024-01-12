export function prepareUserData(token){
    const tempData = JSON.parse(atob(token.split('.')[1]));
    const userData = {
        'id' : tempData.UserId,
        'role' : tempData.UserRole,
        'token': token,
    }
    sessionStorage.setItem('user', JSON.stringify(userData));
}