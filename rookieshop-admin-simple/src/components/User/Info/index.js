import React from "react";
import { Modal, } from "react-bootstrap";

const Info = ({ user, handleClose }) => {
  return (
    <>
      <Modal
        show={true}
        onHide={handleClose}
        dialogClassName="modal-90w"
      >
        <Modal.Header closeButton>
          <Modal.Title id="login-modal" className="text-uppercase">
            Detailed User Infomation
          </Modal.Title>
        </Modal.Header>

        <Modal.Body>
          <div className="row justify-content-center form-group">
            <div className='row -intro-y mb-3'>
              <div className='col-4 text-uppercase'><strong>Username</strong></div>
              <div className="col">{user.userName}</div>
            </div>

            <div className='row -intro-y mb-3'>
              <div className='col-4 text-uppercase'><strong>Full Name</strong></div>
              <div className="col">{user.fullName}</div>
            </div>

            <div className='row -intro-y mb-3'>
              <div className='col-4 text-uppercase'><strong>Email</strong></div>
              <div className="col">{user.email}</div>
            </div>

            <div className='row -intro-y mb-3'>
              <div className='col-4 text-uppercase'><strong>Phone Number</strong></div>
              <div className="col">{user.phoneNumber}</div>
            </div>
          </div>
        </Modal.Body>
      </Modal>
    </>
  );
}

export default Info;