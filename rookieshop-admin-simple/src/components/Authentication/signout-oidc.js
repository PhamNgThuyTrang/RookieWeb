import React, { useState, useEffect } from "react";
import MessageModal from '../../shared-components/MessageModal';
import userService from '../../services/userService';
import { useHistory } from "react-router";

export function SignoutOidc() {

  const history = useHistory();

  const [signoutSuccessfulState, setSignoutSuccessful] = useState({
      isOpen: false,
      title: '',
      message: '',
      isDisable: true,
    });

  const handleShowSignoutSuccessful =  (name) => {
    setSignoutSuccessful({
      isOpen: true,
      title: 'Sign out Successful',
      message: 'Bye!',
      isDisable: true,
    });
  };

  const handleCloseSignoutSuccessful = () => {
    setSignoutSuccessful({
      isOpen: false,
      title: '',
      message: '',
      isDisable: true,
    });

    //redirect to homePage
    history.push("/");
  };

  useEffect(() => {
    userService.userManager.signoutCallback();
    handleShowSignoutSuccessful();
  }, [signoutSuccessfulState.isOpen]);

  return(
    <>
      <MessageModal
      title={signoutSuccessfulState.title}
      isShow={signoutSuccessfulState.isOpen}
      onHide={handleCloseSignoutSuccessful}
      >
      <div>
        <div className="text-center">
          {signoutSuccessfulState.message}
        </div>
        {
          signoutSuccessfulState.isDisable && (
            <div className="text-center mt-3">
              <button
                className="btn btn-success"
                onClick={handleCloseSignoutSuccessful}
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