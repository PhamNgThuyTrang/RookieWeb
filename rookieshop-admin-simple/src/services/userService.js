import { UserManager } from "oidc-client";
import RequestService from './request';

const config = {
    // the URL of our identity server
    authority: "https://localhost:44341", 
    // this ID maps to the client ID in the identity client configuration
    client_id: "admin", 
    // URL to redirect to after login
    redirect_uri: "http://localhost:3000", 
    response_type: "id_token token",
    // the scopes or resources we would like access to
    scope: "openid profile rookieshop.api", 
    // URL to redirect to after logout
    post_logout_redirect_uri: "http://localhost:3000", 
  };
  
// initialise!
const userManager = new UserManager(config);

class userService {
    IsAuthenticated(){
        userManager.getUser().then((user) => {
            if (user) {
                console.log("User logged in", user.profile);
                userManager.getUser().then(function (user) {
                    RequestService.setAuthentication(user.id_token)
                });
                return user;
            }
            else {
                console.log("User not logged in");
                return 0;
            }
        });
    }
    
    SignIn(){
        userManager.signinRedirect();
    }

    SignInAsync(){
        userManager.signinRedirectCallback()
        // redirect user to home page
    }
    
    SignOut(){
        userManager.signoutRedirect();
    }
}

export default new userService();
