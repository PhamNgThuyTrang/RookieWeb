import React, { useEffect, useState } from 'react'
import { Redirect, useParams, useLocation } from 'react-router';

import SubCategoryForm from '../SubCategoryForm';

const UpdateSubCategoryContainer = () => {
  const [subcategory, setSubCategory] = useState(undefined);
  const {state} = useLocation();
  const { existSubCategory } = state; // Read values passed on state
  
  useEffect(() => {
    if (existSubCategory) {
      setSubCategory({
        id: existSubCategory.id,
        name: existSubCategory.name,
        categoryId: existSubCategory.categoryId,
        imagePath: existSubCategory.imagePath,
        imageFile: existSubCategory.imageFile
      });
    }
  }, [existSubCategory]);

  return (
    <div className='ml-5'>
      <div className='primaryColor text-title intro-x'>
        Update SubCategory {existSubCategory?.name}
      </div>

      <div className='row justify-content-center form-group'>
        {
          subcategory && (<SubCategoryForm
            initialSubCategoryForm={subcategory}
  
          />)
        }
      </div>
    </div>
  )
};

export default UpdateSubCategoryContainer;
