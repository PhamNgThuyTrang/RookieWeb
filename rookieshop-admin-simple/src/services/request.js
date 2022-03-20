import axios, { AxiosInstance, AxiosRequestConfig } from "axios";
import { UrlBackEnd } from "../Constants/oidc-config";
const config = {
    baseURL: UrlBackEnd
}

class RequestService {
    axios;

    constructor() {
        this.axios = axios.create(config);
        this.setAuthentication();
    }

    setAuthentication(){
        const cookies = document.cookie.split('; ');
        const tokenCookie = cookies.find(row => row.startsWith('Token='));
        console.log(cookies);
        console.log(tokenCookie);
        if(tokenCookie){
            this.axios.defaults.headers.common['Authorization'] = tokenCookie.split('=')[1].replace("%20", " ");
        }
    }
}
export default new RequestService();


