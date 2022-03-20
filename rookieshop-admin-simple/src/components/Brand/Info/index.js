import React from "react";
import { Modal, } from "react-bootstrap";

import { 
  NormalBrandType,
  NormalBrandTypeLabel,
  LuxuryBrandType, 
  LuxyryBrandTypeLabel 
} from "../../../Constants/Brand/BrandConstants";

const Info = ({ brand, handleClose }) => {
  const getBrandTypeName = (id) => {
    return id === LuxuryBrandType ? LuxyryBrandTypeLabel : NormalBrandTypeLabel;
  }

  return (
    <>
      <Modal
        show={true}
        onHide={handleClose}
        dialogClassName="modal-90w"
      >
        <Modal.Header closeButton>
          <Modal.Title id="login-modal" className="text-uppercase">
            Detailed Brand Infomation
          </Modal.Title>
        </Modal.Header>

        <Modal.Body>
          <div>
            <div className='row -intro-y mb-3'>
              <div className='col-4 text-uppercase'><strong>Id</strong></div>
              <div className="col">{brand.brandId}</div>
            </div>

            <div className='row -intro-y mb-3'>
              <div className='col-4 text-uppercase'><strong>Name</strong></div>
              <div className="col">{brand.name}</div>
            </div>

            <div className='row -intro-y mb-3'>
              <div className='col-4 text-uppercase'><strong>Type</strong></div>
              <div className="col">{getBrandTypeName(brand.type)}</div>
            </div>

            <div className='row -intro-y mb-3'>
              <div className='col-4 text-uppercase'><strong>Image</strong></div>
              <div className="col">
                <img src={brand.imagePath} className='object-center w-full rounded-md img-fluid' />
              </div>
            </div>

          </div>
        </Modal.Body>
      </Modal>
    </>
  );
}

export default Info;