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
          <Modal.Title id="login-modal" className="text-uppercase">
            Detailed Category Infomation
          </Modal.Title>
        </Modal.Header>

        <Modal.Body>
          <div>
            <div className='row -intro-y mb-3'>
              <div className='col-4 text-uppercase'><strong>Id</strong></div>
              <div className="col">{category.categoryId}</div>
            </div>

            <div className='row -intro-y mb-3'>
              <div className='col-4 text-uppercase'><strong>Name</strong></div>
              <div className="col">{category.name}</div>
            </div>

            <div className='row -intro-y mb-3'>
              <div className='col-4 text-uppercase'><strong>Image</strong></div>
              <div className="col">
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