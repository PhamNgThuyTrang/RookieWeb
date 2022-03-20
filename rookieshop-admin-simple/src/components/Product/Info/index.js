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
          <Modal.Title id="login-modal" className="text-uppercase">
            Detailed Product Infomation
          </Modal.Title>
        </Modal.Header>

        <Modal.Body>
          <div className="row justify-content-center form-group">
            <div className='row -intro-y mb-3'>
              <div className='col-5 text-uppercase'><strong>Id</strong></div>
              <div className="col">{product.productId}</div>
            </div>

            <div className='row -intro-y mb-3'>
              <div className='col-5 text-uppercase'><strong>Name</strong></div>
              <div className="col">{product.name}</div>
            </div>

            <div className='row -intro-y mb-3'>
              <div className='col-5 text-uppercase'><strong>Color</strong></div>
              <div className="col">{product.color}</div>
            </div>

            <div className='row -intro-y mb-3'>
              <div className='col-5 text-uppercase'><strong>Listed Price</strong></div>
              <div className="col">{product.listedPrice}</div>
            </div>

            <div className='row -intro-y mb-3'>
              <div className='col-5 text-uppercase'><strong>Selling Price</strong></div>
              <div className="col">{product.sellingPrice}</div>
            </div>

            <div className='row -intro-y mb-3'>
              <div className='col-5 text-uppercase'><strong>ProductModel Id</strong></div>
              <div className="col">{product.productModelId}</div>
            </div>

            <div className='row -intro-y mb-3'>
              <div className='col-5 text-uppercase'><strong>Image</strong></div>
              <div className="col">
                <img src={product.imagePath} className='object-center w-full rounded-md img-fluid' />
              </div>
            </div>

          </div>
        </Modal.Body>
      </Modal>
    </>
  );
}

export default Info;