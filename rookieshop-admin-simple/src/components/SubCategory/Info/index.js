import React from "react";
import { Modal, } from "react-bootstrap";

const Info = ({ subcategory, handleClose }) => {
  return (
    <>
      <Modal
        show={true}
        onHide={handleClose}
        dialogClassName="modal-90w"
      >
        <Modal.Header closeButton>
          <Modal.Title id="login-modal">
            Detailed SubCategory Infomation
          </Modal.Title>
        </Modal.Header>

        <Modal.Body>
          <div className="row justify-content-center form-group">
            <div className='row -intro-y'>
              <div className='col-4'>Id:</div>
              <div>{subcategory.subcategoryId}</div>
            </div>

            <div className='row -intro-y'>
              <div className='col-4'>Name:</div>
              <div>{subcategory.name}</div>
            </div>

            <div className='row -intro-y'>
              <div className='col-4'>Category Id:</div>
              <div>{subcategory.categoryId}</div>
            </div>

            <div className='row -intro-y'>
              <div className='col-4'>Image:</div>
              <div>
                <img src={subcategory.imagePath} className='object-center w-full rounded-md img-fluid' />
              </div>
            </div>

          </div>
        </Modal.Body>
      </Modal>
    </>
  );
}

export default Info;