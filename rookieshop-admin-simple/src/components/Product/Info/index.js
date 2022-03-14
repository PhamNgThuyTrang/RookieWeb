import React from "react";
import { Modal, } from "react-bootstrap";

const Info = ({ product, handleClose }) => {
  return (
    <>
      <Modal
        show={true}
        onHide={handleClose}
        dialogClassName="modal-90w"
      >
        <Modal.Header closeButton>
          <Modal.Title id="login-modal">
            Detailed Product Infomation
          </Modal.Title>
        </Modal.Header>

        <Modal.Body>
          <div>
            <div className='row -intro-y'>
              <div className='col-4'>Id:</div>
              <div>{product.productId}</div>
            </div>

            <div className='row -intro-y'>
              <div className='col-4'>Name:</div>
              <div>{product.name}</div>
            </div>

            <div className='row -intro-y'>
              <div className='col-4'>Color:</div>
              <div>{product.color}</div>
            </div>

            <div className='row -intro-y'>
              <div className='col-4'>Listed Price:</div>
              <div>{product.listedPrice}</div>
            </div>

            <div className='row -intro-y'>
              <div className='col-4'>Selling Price:</div>
              <div>{product.sellingPrice}</div>
            </div>

            <div className='row -intro-y'>
              <div className='col-4'>ProductModelId:</div>
              <div>{product.productModelId}</div>
            </div>

            <div className='row -intro-y'>
              <div className='col-4'>Image:</div>
              <div>
                <img src={product.imagePath} className='object-center w-full rounded-md' />
              </div>
            </div>

          </div>
        </Modal.Body>
      </Modal>
    </>
  );
}

export default Info;