import React from "react";

import BrandForm from "../BrandForm";

const CreateBrandContainer = () => {

  return (
    <div className='ml-5'>
      <div className='primaryColor text-title intro-x'>
        Create New Brand
      </div>

      <div className='row justify-content-center form-group'>
        <BrandForm />
      </div>

    </div>
  );
};

export default CreateBrandContainer;
