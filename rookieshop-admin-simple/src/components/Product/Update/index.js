import React, { useEffect, useState } from 'react'
import {useLocation } from 'react-router';

import ProductForm from '../ProductForm';

const UpdateProductContainer = () => {
  const [product, setProduct] = useState(undefined);
  const {state} = useLocation();
  const { existProduct } = state; // Read values passed on state
  
  useEffect(() => {
    if (existProduct) {
      setProduct({
        id: existProduct.id,
        name: existProduct.name,
        color: existProduct.color,
        listedPrice: existProduct.listedPrice,
        sellingPrice: existProduct.sellingPrice,
        productModelId: existProduct.productModelId,
        imagePath: existProduct.imagePath,
        imageFile: existProduct.imageFile
      });
    }
  }, [existProduct]);

  return (
    <div className='ml-5'>
      <div className='primaryColor text-title intro-x'>
        Update Product {existProduct?.name}
      </div>

      <div className='row justify-content-center form-group'>
        {
          product && (<ProductForm
            initialProductForm={product}
  
          />)
        }
      </div>
    </div>
  )
};

export default UpdateProductContainer;
