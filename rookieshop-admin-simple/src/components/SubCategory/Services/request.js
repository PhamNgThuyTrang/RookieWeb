import { AxiosResponse } from "axios";
import qs from 'qs';

import RequestService from '../../../services/request';
import EndPoints from '../../../Constants/endpoints';

export function createSubCategoryRequest(subCategoryForm) {
    const formData = new FormData();

    Object.keys(subCategoryForm).forEach(key => {
        formData.append(key, subCategoryForm[key]);
    });

    return RequestService.axios.post(EndPoints.postsubcategory, formData);
}

export function getSubCategoryRequest(query) {
    console.log(RequestService.axios.defaults.headers)
    return RequestService.axios.get(EndPoints.getsubcategories, {
        params: query,
        paramsSerializer: params => qs.stringify(params),
    });
}

export function UpdateSubCategoryRequest(subCategoryForm) {
    const formData = new FormData();

    Object.keys(subCategoryForm).forEach(key => {
        formData.append(key, subCategoryForm[key]);
    });

    return RequestService.axios.put(EndPoints.putsubcategory(subCategoryForm.id ?? - 1), formData);
}

export function DisableSubCategoryRequest(subCategoryId) {
    return RequestService.axios.delete(EndPoints.deletesubcategory(subCategoryId));
}