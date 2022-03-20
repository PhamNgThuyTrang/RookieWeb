import { AxiosResponse } from "axios";
import qs from 'qs';

import RequestService from '../../../services/request';
import EndPoints from '../../../Constants/endpoints';

export function createProductRequest(productForm) {
    const formData = new FormData();

    Object.keys(productForm).forEach(key => {
        formData.append(key, productForm[key]);
    });

    return RequestService.axios.post(EndPoints.createproduct, formData);
}

export function getProductRequest(query) {
    return RequestService.axios.get(EndPoints.getproducts, {
        params: query,
        paramsSerializer: params => qs.stringify(params),
    });
}

export function UpdateProductRequest(productForm) {
    const formData = new FormData();

    Object.keys(productForm).forEach(key => {
        formData.append(key, productForm[key]);
    });

    return RequestService.axios.put(EndPoints.putproduct(productForm.id ?? - 1), formData);
}

export function DisableProductRequest(productId) {
    return RequestService.axios.delete(EndPoints.deleteproduct(productId));
}