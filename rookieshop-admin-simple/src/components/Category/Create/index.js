import React, { useState } from "react";
import CategoryForm from "../CategoryForm";

const CreateCategoryForm = () => {

  return (
    <div className='ml-5'>
      <div className='primaryColor text-title intro-x'>
        Create New Category
      </div>

      <div className='row'>
        <CategoryForm />
      </div>

    </div>
  );
};

export default CreateCategoryForm;
