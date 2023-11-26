export function prepareUserData(token){
    const tempData = JSON.parse(atob(token.split('.')[1]));
    const userData = {
        'id' : tempData.UserId,
        'role' : tempData.Role,
        'userName' : tempData.UserName,
        'firstName' : tempData.FirstName,
        'lastName' : tempData.LastName,
        'email' : tempData.Email,
        'phoneNumber' : tempData.PhoneNumber,
    }
    sessionStorage.setItem('user', JSON.stringify(userData));
}