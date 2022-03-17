import { UserManager } from "oidc-client";
import RequestService from './request';

const config = {
    // the URL of our identity server
    authority: "https://localhost:44341", 
    // this ID maps to the client ID in the identity client configuration
    client_id: "admin", 
    // URL to redirect to after login
    redirect_uri: "http://localhost:3000/Authentication/signin-oidc", 
    response_type: "id_token token",
    // the scopes or resources we would like access to
    scope: "openid profile rookieshop.api", 
    // URL to redirect to after logout
    post_logout_redirect_uri: "http://localhost:3000/", 
  };
  

class userService {
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

    Signin() {
        this.userManager.signinRedirect();
    }

    Api() {
        this.userManager.getUser().then( (user) => {
            RequestService.setAuthentication(user.access_token);
        });
    }
    
    Signout() {
        this.userManager.signoutRedirect();
    }
}

export default new userService();
