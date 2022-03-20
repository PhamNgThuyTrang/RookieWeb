import { UserManager } from "oidc-client";
import {UrlBackEnd, RedirectUri, ClientId, PostLogoutRedirectUri, Scope,ResponseType} from '../Constants/oidc-config'

const config = {
    // the URL of our identity server
    authority: UrlBackEnd, 
    // this ID maps to the client ID in the identity client configuration
    client_id: ClientId, 
    // URL to redirect to after login
    redirect_uri: RedirectUri, 
    response_type: ResponseType,
    // the scopes or resources we would like access to
    scope: Scope, 
    // URL to redirect to after logout
    post_logout_redirect_uri: PostLogoutRedirectUri, 
};



class userService{
    userManager;

    constructor() {
        // initialise!
        this.userManager = new UserManager(config);
    }

    IsAuthenticated(){
        this.userManager.getUser().then((user) => {
            if (user) {
                console.log("User logged in", user.profile);
            }
            else {
                console.log("User not logged in");
            }
        });
    }

    Signin(){
        this.userManager.signinRedirect();
    }
    
    Signout(){
        this.userManager.signoutRedirect();
    }
}

export default new userService();
