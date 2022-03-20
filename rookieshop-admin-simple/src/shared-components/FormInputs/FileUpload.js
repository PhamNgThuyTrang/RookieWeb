import React, { InputHTMLAttributes, useState, useEffect } from 'react';
import { useField } from 'formik';
import { X } from 'react-feather';

import { resizeFileToBase64, resizeFileToBlob } from '../../services/resizeImage';

const FileUpload = (props) => {
    const [value, , { setValue }] = useField(props);
    const [review, setReview] = useState(props.image || '');

    const handleOnChange = async (e) => {
        e.preventDefault();
        if (e.target.files.length > 0) {
            await resizeFileToBlob(e.target.files[0], setValue);
            await resizeFileToBase64(e.target.files[0], setReview);
        }
    }

    const handleRemove = () => {
        setValue('');
        setReview('');
    }

    return (
        <div className='mb-3 row'>
            <label className="col-4 col-form-label d-flex">
                {props.label}
            </label>
            <div className="col-8">
                <input  type="file" 
                        onChange={handleOnChange} 
                        formEncType='multipart/form-data' 
                        name={props.name} />
                {
                    review && (
                        <div className='overflow-hidden mx-auto'>
                            <div className='mt-2 d-flex flex-column align-items-end'>
                                <button onClick={handleRemove} 
                                        type='button'
                                        className='btn btn-danger right-0 w-25'><X />
                                </button>
                                <img src={review} className='img-fluid' />
                            </div>
                        </div>
                    )
                }
            </div>
        </div>
    );
};

export default FileUpload;