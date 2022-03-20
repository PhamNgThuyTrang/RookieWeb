import React, { useState } from "react";
import SubCategoryForm from "../SubCategoryForm";

const CreateSubCategoryForm = () => {

  return (
    <div className='ml-5'>
      <div className='primaryColor text-title intro-x'>
        Create New SubCategory
      </div>

      <div className='row justify-content-center form-group'>
        <SubCategoryForm />
      </div>

    </div>
  );
};

export default CreateSubCategoryForm;
