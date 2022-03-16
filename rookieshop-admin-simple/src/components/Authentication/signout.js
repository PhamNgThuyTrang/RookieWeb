import React, { useState, useEffect } from "react";
import userService from '../../services/userService'
import MessageModal from '../../shared-components/MessageModal'
import { useHistory } from "react-router";


export function Signout() {

  const history = useHistory;

  const [signinState, setSignin] = useState({
      isOpen: false,
      title: '',
      message: '',
      isDisable: true,
    });

  const handleShowSignOut =  () => {
    setSignin({
      isOpen: true,
      title: 'Attention',
      message: 'SignOut Successful',
      isDisable: true,
    });
  };

  const handleCloseSignOut = () => {
    setSignin({
      isOpen: false,
      title: '',
      message: '',
      isDisable: true,
    });
  };

  useEffect(() => {
      userService.SignOut();
      history.push("/");
  }, [history]);

  return(
      <MessageModal
      title={signinState.title}
      isShow={signinState.isOpen}
      onHide={handleCloseSignOut}
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
                onClick={handleCloseSignOut}
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