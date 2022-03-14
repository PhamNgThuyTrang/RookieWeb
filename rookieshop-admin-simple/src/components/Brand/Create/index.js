import React, { useState } from "react";

import BrandForm from "../BrandForm";

const CreateBrandContainer = () => {

  return (
    <div className='ml-5'>
      <div className='primaryColor text-title intro-x'>
        Create New Brand
      </div>

      <div className='row'>
        <BrandForm />
      </div>

    </div>
  );
};

export default CreateBrandContainer;
