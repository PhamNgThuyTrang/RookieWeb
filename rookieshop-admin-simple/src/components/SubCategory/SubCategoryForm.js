import React, { useEffect, useState } from 'react';
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import { Link, useHistory } from 'react-router-dom';
import { NotificationManager } from 'react-notifications';

import TextField from '../../shared-components/FormInputs/TextField';
import { PRODUCT } from '../../Constants/pages';
import FileUpload from '../../shared-components/FormInputs/FileUpload';
import { createSubCategoryRequest, UpdateSubCategoryRequest } from "./Services/request";

const initialFormValues = {
    name: '',
    categoryId: 0,
    imageFile: undefined
};

const validationSchema = Yup.object().shape({
    name: Yup.string().required('Required'),
    categoryId: Yup.number().required('Required'),
});

const SubCategoryFormContainer = ({ initialSubCategoryForm = {
    ...initialFormValues
} }) => {
    const [loading, setLoading] = useState(false);

    const isUpdate = initialSubCategoryForm.id ? true : false;

    const history = useHistory();

    const handleResult = (result, message) => {
        if (result) {
            NotificationManager.success(
                `${isUpdate ? 'Updated' : 'Created'} Successful SubCategory ${message}`,
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

    const updateSubCategoryAsync = async (form) => {
        console.log('update subcategory async');
        let data = await UpdateSubCategoryRequest(form.formValues);
        if (data)
        {
            handleResult(true, data.name);
        }
    }

    const createSubCategoryAsync = async (form) => {  
        console.log('create subcategory async');
        let data = await createSubCategoryRequest(form.formValues);
        if (data)
        {
            handleResult(true, data.name);
        }
    }

    return (
        <Formik
            initialValues={initialSubCategoryForm}
            enableReinitialize
            validationSchema={validationSchema}
            onSubmit={(values) => {
                setLoading(true);

                setTimeout(() => {
                    if (isUpdate) {
                        updateSubCategoryAsync({ formValues: values });
                    }
                    else {
                        createSubCategoryAsync({ formValues: values });
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
                        placeholder="input subcategory name" 
                        isrequired 
                        disabled={isUpdate ? true : false} />

                    <TextField 
                        name="categoryId" 
                        label="categoryId" 
                        placeholder="input categoryId" 
                        isrequired 
                        disabled={isUpdate ? true : false} />

                    <FileUpload 
                        name="imageFile" 
                        label="Image" 
                        image={actions.values.imagePath} />

                    <div className='mt-3 text-center'>
                            <Link to={PRODUCT} className="btn btn-outline-secondary">
                                Cancel
                            </Link>
                            <button className="btn btn-primary mx-3"
                                type="submit" disabled={loading}>
                                Save
                            </button>
                    </div>
                </Form>
            )}
        </Formik>
    );
}

export default SubCategoryFormContainer;
