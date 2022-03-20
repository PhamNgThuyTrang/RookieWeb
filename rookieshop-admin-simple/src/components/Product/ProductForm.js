import React, { useEffect, useState } from 'react';
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import { Link, useHistory } from 'react-router-dom';
import { NotificationManager } from 'react-notifications';

import TextField from '../../shared-components/FormInputs/TextField';
import { PRODUCT } from '../../Constants/pages';
import FileUpload from '../../shared-components/FormInputs/FileUpload';
import { createProductRequest, UpdateProductRequest } from "./Services/request";

const initialFormValues = {
    name: '',
    color: '',
    listedPrice: 0,
    sellingPrice: 0,
    productModelId: 0,
    imageFile: undefined
};

const validationSchema = Yup.object().shape({
    name: Yup.string().required('Required'),
    color: Yup.string().required('Required'),
    listedPrice: Yup.number().required('Required'),
    sellingPrice: Yup.number().required('Required'),
    productModelId: Yup.number().required('Required'),
});

const ProductFormContainer = ({ initialProductForm = {
    ...initialFormValues
} }) => {
    const [loading, setLoading] = useState(false);

    const isUpdate = initialProductForm.id ? true : false;

    const history = useHistory();

    const handleResult = (result, message) => {
        if (result) {
            NotificationManager.success(
                `${isUpdate ? 'Updated' : 'Created'} Successful Product ${message}`,
                `${isUpdate ? 'Update' : 'Create'} Successful`,
                2000,
            );

            setTimeout(() => {
                history.push(PRODUCT);
            }, 1000);

        } 
        
        else {
            NotificationManager.error(message, 'Create failed', 2000);
        }
    }

    const updateProductAsync = async (form) => {
        console.log('update product async');
        let data = await UpdateProductRequest(form.formValues);
        if (data)
        {
            handleResult(true, data.name);
        }
    }

    const createProductAsync = async (form) => {  
        console.log('create product async');
        let data = await createProductRequest(form.formValues);
        if (data)
        {
            handleResult(true, data.name);
        }
    }

    return (
        <Formik
            initialValues={initialProductForm}
            enableReinitialize
            validationSchema={validationSchema}
            onSubmit={(values) => {
                setLoading(true);

                setTimeout(() => {
                    if (isUpdate) {
                        updateProductAsync({ formValues: values });
                    }
                    else {
                        createProductAsync({ formValues: values });
                    }

                    setLoading(false);
                }, 1000);
            }}
        >
            {(actions) => (
                <Form className='intro-y col-lg-6 col-12'>
                    <TextField 
                        name="name" 
                        label="Name" 
                        placeholder="input product name" 
                        isrequired 
                        disabled={isUpdate ? true : false} />

                    <TextField 
                        name="color" 
                        label="Color" 
                        placeholder="input product color" 
                        isrequired 
                        disabled={isUpdate ? true : false} />

                    <TextField 
                        name="listedPrice" 
                        label="Listed Price" 
                        placeholder="input product listed price" 
                        isrequired 
                        disabled={isUpdate ? true : false} />

                    <TextField 
                        name="sellingPrice" 
                        label="Selling Price" 
                        placeholder="input product selling price" 
                        isrequired 
                        disabled={isUpdate ? true : false} />

                    <TextField 
                        name="productModelId" 
                        label="ProductModelId" 
                        placeholder="input product ProductModelId" 
                        isrequired 
                        disabled={isUpdate ? true : false} />

                    <FileUpload 
                        name="imageFile" 
                        label="Image" 
                        image={actions.values.imagePath} />

                    <div className='mt-3 text-center'>
                            <Link to={PRODUCT} className="btn btn-outline-secondary m-2">
                                Cancel
                            </Link>
                            <button className="btn btn-primary m-2"
                                type="submit" disabled={loading}>
                                Save
                            </button>
                    </div>
                </Form>
            )}
        </Formik>
    );
}

export default ProductFormContainer;
