import React, { useState, useEffect } from "react";
import userService from '../../services/userService'
import MessageModal from '../../shared-components/MessageModal'
import { useHistory } from "react-router";


export function SigninOidc() {

  const history = useHistory;

  const [signinState, setSignin] = useState({
      isOpen: false,
      title: '',
      message: '',
      isDisable: true,
    });

  const handleShowLogin =  () => {
    setSignin({
      isOpen: true,
      title: 'Attention',
      message: 'Login Successful',
      isDisable: true,
    });
  };

  const handleCloseLogin = () => {
    setSignin({
      isOpen: false,
      title: '',
      message: '',
      isDisable: true,
    });
  };

  useEffect(() => {
      userService.SignIn();
      history.push("/");
  }, [history]);

  return(
      <MessageModal
      title={signinState.title}
      isShow={signinState.isOpen}
      onHide={handleCloseLogin}
    >
      <div>
        <div className="text-center">
          {signinState.message}
        </div>
        {
          signinState.isDisable && (
            <div className="text-center mt-3">
              <button
                className="btn btn-success"
                onClick={handleCloseLogin}
                type="button"
              >
                OK
              </button>
            </div>
          )
        }
      </div>
    </MessageModal>

  );
}