import React from "react";
import { Modal, } from "react-bootstrap";

const Info = ({ category, handleClose }) => {
  return (
    <>
      <Modal
        show={true}
        onHide={handleClose}
        dialogClassName="modal-90w"
      >
        <Modal.Header closeButton>
          <Modal.Title id="login-modal">
            Detailed Category Infomation
          </Modal.Title>
        </Modal.Header>

        <Modal.Body>
          <div>
            <div className='row -intro-y'>
              <div className='col-4'>Id:</div>
              <div>{category.categoryId}</div>
            </div>

            <div className='row -intro-y'>
              <div className='col-4'>Name:</div>
              <div>{category.name}</div>
            </div>

            <div className='row -intro-y'>
              <div className='col-4'>Image:</div>
              <div>
                <img src={category.imagePath} className='object-center w-full rounded-md img-fluid' />
              </div>
            </div>

          </div>
        </Modal.Body>
      </Modal>
    </>
  );
}

export default Info;