import {SUBPAGES} from "../constans/subpages.js";
export function getSubpages(){
    const user = sessionStorage["user"] ? JSON.parse(sessionStorage["user"]) : [];

    return SUBPAGES.filter((subpage) => {
        if(subpage.permission){
            if(user && user.role){
                return subpage.permission.includes(user.role.toLowerCase())
            }
        }else{
            return subpage
        }
    });
}