import React, { useState, useEffect } from "react";
import userService from '../../services/userService'
import MessageModal from '../../shared-components/MessageModal'
import Roles from "../../Constants/roles";
import { createBrowserHistory } from 'history';
import { useCookies } from "react-cookie";

export function SigninOidc() {

  const history = createBrowserHistory({forceRefresh:true});
  const [cookies, setCookie] = useCookies(['Token']);

  const [signinSuccessfulState, setSigninSuccessful] = useState({
      isOpen: false,
      title: '',
      message: '',
      isDisable: true,
    });

  const [signinFailedState, setSigninFailed] = useState({
    isOpen: false,
    title: '',
    message: '',
    isDisable: true,
  });

  const handleShowSigninSuccessful =  (name) => {
    setSigninSuccessful({
      isOpen: true,
      title: 'Sign in Successful',
      message: 'Hi ' + name + '!',
      isDisable: true,
    });
  };

  const handleShowSigninFailed =  () => {
    setSigninFailed({
      isOpen: true,
      title: 'Sign in Failed',
      message: "You don't allow to access this site",
      isDisable: true,
    });
  };

  const handleCloseSigninSuccessful = () => {
    setSigninSuccessful({
      isOpen: false,
      title: '',
      message: '',
      isDisable: true,
    });

    //redirect to homePage
    history.push("/");
  };

  const handleCloseSigninFalied = () => {
    setSigninFailed({
      isOpen: false,
      title: '',
      message: '',
      isDisable: true,
    });

    userService.Signout();
  };

  const cookieAuthentication = (token) => {
    setCookie("Token", token, {path : '/'});
  }

  useEffect(() => {
    userService.userManager.signinRedirectCallback().then(() => {
      userService.userManager.getUser().then( async (user) => {
        console.log(user.expired, user.expires_at, user.expires_in);
        if (user.profile.role === Roles.Admin){
          userService.IsAuthenticated();
          cookieAuthentication(user.token_type + " " + user.access_token);
          handleShowSigninSuccessful(user.profile.name);
        }
        else{
          handleShowSigninFailed();
        }
      });
    })
    .catch((e) => {
      console.error(e);
    });
  }, [signinFailedState.isOpen, signinSuccessfulState.isOpen]);

  return(
    <>
      <MessageModal
      title={signinSuccessfulState.title}
      isShow={signinSuccessfulState.isOpen}
      onHide={handleCloseSigninSuccessful}
      >
      <div>
        <div className="text-center">
          {signinSuccessfulState.message}
        </div>
        {
          signinSuccessfulState.isDisable && (
            <div className="text-center mt-3">
              <button
                className="btn btn-success"
                onClick={handleCloseSigninSuccessful}
                type="button"
              >
                OK
              </button>
            </div>
          )
        }
      </div>
      </MessageModal>

      <MessageModal
        title={signinFailedState.title}
        isShow={signinFailedState.isOpen}
        onHide={handleCloseSigninFalied}
      >
        <div>
          <div className="text-center">
            {signinFailedState.message}
          </div>
          {
            signinFailedState.isDisable && (
              <div className="text-center mt-3">
                <button
                  className="btn btn-success"
                  onClick={handleCloseSigninFalied}
                  type="button"
                >
                  OK
                </button>
              </div>
            )
          }
        </div>
      </MessageModal>
    </>
  );
}