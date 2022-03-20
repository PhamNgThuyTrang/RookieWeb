import React, { useState } from "react";
import ProductForm from "../ProductForm";

const CreateProductForm = () => {

  return (
    <div className='ml-5'>
      <div className='primaryColor text-title intro-x'>
        Create New Product
      </div>

      <div className='row justify-content-center form-group'>
        <ProductForm />
      </div>

    </div>
  );
};

export default CreateProductForm;
